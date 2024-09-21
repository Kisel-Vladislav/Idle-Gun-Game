using CodeBase.Enemy.Attack;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public EnemyDeath Death;
        public AnimatorController Animator;
        public EnemyMoveToTarget Move;
        public EnemyAttack Attack;

        // TO DOO Add separate class HitBox
        public Health Health;
        public void TakeDamage(float damage) =>
            Health.TakeDamage(damage);
    }
}
