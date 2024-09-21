using CodeBase.StaticData.Enemy;
using UnityEngine;

namespace CodeBase.Enemy.Attack.AttackBehevior
{
    public class EnemyExplosionAttackBehaviour : EnemyOverlapAttackBase
    {
        private readonly Health _enemyHealth;
        private readonly EnemyExploreAttackData _attackData;

        private bool _isExplosion;
        // TODO to static data
        public float SphereRadius = 1;

        public EnemyExplosionAttackBehaviour(Transform attackStartPoint, EnemyExploreAttackData attackData, Health enemyHealth)
            : base(attackStartPoint)
        {
            _enemyHealth = enemyHealth;
            _attackData = attackData;
        }

        public override void Attack()
        {
            if (!_isExplosion)
            {
                _isExplosion = true;
                Explode();
                Suicide();
            }
        }

        private void Explode()
        {
            var colliders = Physics.OverlapSphere(_attackStartPoint.position, SphereRadius, _attackData.SearchLayerMask.value);

            foreach (var collider in colliders)
                TryTakeDamage(collider);
        }
        private void TryTakeDamage(Collider collider)
        {
            if (collider.TryGetComponent<IDamageable>(out var damageable))
                damageable.TakeDamage(_attackData.Damage);
        }
        private void Suicide() =>
            _enemyHealth.TakeDamage(_enemyHealth.Max);
    }
}
