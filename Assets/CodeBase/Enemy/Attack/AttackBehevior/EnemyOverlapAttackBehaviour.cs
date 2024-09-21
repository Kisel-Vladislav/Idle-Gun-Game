using CodeBase.StaticData.Enemy;
using UnityEngine;

namespace CodeBase.Enemy.Attack.AttackBehevior
{
    public class EnemyOverlapAttackBehaviour : EnemyOverlapAttackBase
    {
        // TODO to static data
        public Vector3 Offset = new Vector3(0, 0, 3);
        public float SphereRadius = 5;
        // maybe also
        private Collider[] _overlapResult = new Collider[8];

        private float _lastAttackTime;
        private readonly EnemyOverlapAttackData _attackData;

        public EnemyOverlapAttackBehaviour(Transform attackStartPoint, EnemyOverlapAttackData attackData)
            : base(attackStartPoint)
        {
            _attackData = attackData;
        }

        public override void Attack()
        {
            if (CanAttack())
            {
                _lastAttackTime = Time.time;
                Overlap();
            }
        }

        private void Overlap()
        {
            var collidersCount = SphereCast();
            DealDamage(collidersCount);
        }
        private int SphereCast()
        {
            var position = _attackStartPoint.TransformPoint(Offset);
            return Physics.OverlapSphereNonAlloc(position, SphereRadius, _overlapResult, _attackData.SearchLayerMask.value);
        }
        private void DealDamage(int collidersCount)
        {
            for (var i = 0; i < collidersCount; i++)
                if (_overlapResult[i].TryGetComponent<IDamageable>(out var damageable))
                    damageable.TakeDamage(_attackData.Damage);
        }
        private bool CanAttack() => 
            Time.time > _attackData.FireRate + _lastAttackTime;
    }
}
