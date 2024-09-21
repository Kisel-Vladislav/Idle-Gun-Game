using UnityEngine;

namespace CodeBase.Enemy.Attack.AttackBehevior
{
    public abstract class EnemyOverlapAttackBase : IEnemyAttackBehevior
    {
        protected readonly Transform _attackStartPoint;

        public EnemyOverlapAttackBase(Transform attackStartPoint) => 
            _attackStartPoint = attackStartPoint;

        public abstract void Attack();
    }
}