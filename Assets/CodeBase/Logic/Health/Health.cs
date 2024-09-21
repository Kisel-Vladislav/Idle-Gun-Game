using System;

namespace CodeBase.Enemy
{
    public class Health : IDamageable
    {
        private float _current;
        private float _max;

        public float Current { get => _current; set => _current = value; }
        public float Max { get => _max; set => _max = value; }

        public event Action<float> HealthChanged;

        public void TakeDamage(float damage)
        {
            _current -= damage;
            HealthChanged?.Invoke(_current);
        }
    }
}