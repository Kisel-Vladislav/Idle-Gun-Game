using CodeBase.Weapons.AttackBehaviour;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyOverlapAttack : MonoBehaviour
    {
        private Transform _attackStartPoint;
        private EnemyAttackData _attackData;
        private float _lastAttackTime;
        private Vector3 _offset;
        private float _sphereRadius;
        private Collider[] _overlapResult = new Collider[8];
        private LayerMask _searchLayerMask;

        public void Construct(Transform attackStartPoint, EnemyAttackData attackData)
        {
            _attackStartPoint = attackStartPoint;
            _attackData = attackData;
        }

        public void Attack()
        {
            if (Time.time > _attackData.FireRate + _lastAttackTime)
            {
                _lastAttackTime = Time.time;
                Overlap();
            }
        }

        private void Overlap()
        {
            var position = _attackStartPoint.TransformPoint(_offset);

            var collidersCount = Physics.OverlapSphereNonAlloc(position, _sphereRadius, _overlapResult, _searchLayerMask.value);
            for (var i = 0; i < collidersCount; i++)
            {
                if (_overlapResult[i].TryGetComponent<IDamageable>(out var damageable))
                    damageable.TakeDamage(_attackData.Damage);
            }
        }
        private void OnDrawGizmos()
        {
            var position = _attackStartPoint.TransformPoint(_offset);

            Gizmos.DrawSphere(position, _sphereRadius);
        }
    }
}
