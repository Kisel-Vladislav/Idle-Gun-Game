using CodeBase.Logic;
using System;
using UnityEngine;

namespace CodeBase.Enemy
{

    public class EnemyDeath : MonoBehaviour
    {
        private int _experienceReward;

        public Health Health;
        public GameObject DeathFx;
        public AnimatorController _enemyAnimator;

        public int ExperienceReward => _experienceReward;

        public event Action<EnemyDeath> OnDie;

        public void Construct(AnimatorController enemyAnimator, Health health, int experienceReward)
        {
            _enemyAnimator = enemyAnimator;
            Health = health;
            _experienceReward = experienceReward;
        }

        private void Start() =>
            Health.HealthChanged += HealthChanged;
        private void OnDestroy() =>
            Health.HealthChanged -= HealthChanged;

        private void HealthChanged(float current)
        {
            if (current <= 0)
                Die();
        }
        private void Die()
        {
            if (DeathFx != null)
                SpawnDeathFx();

            OnDie?.Invoke(this);
        }
        private void SpawnDeathFx() =>
            Instantiate(DeathFx, transform.position, Quaternion.identity);
    }
}
