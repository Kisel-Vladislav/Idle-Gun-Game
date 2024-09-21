using CodeBase.Enemy;
using System;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private RagdollHandler _ragdollHandler;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerMove _playerMove;

        private Health _health;
        private PlayerAnimator _playerAnimator;

        public event Action OnDie;

        public void Construct(Health health, PlayerAnimator playerAnimator)
        {
            _health = health;
            _playerAnimator = playerAnimator;
        }

        private void Start() =>
            _health.HealthChanged += HealthChanged;
        private void OnDestroy() =>
            _health.HealthChanged -= HealthChanged;
        private void HealthChanged(float current)
        {
            if (current <= 0)
                Die();
        }
        private void Die()
        {
            _playerMove.enabled = false;
            _playerAttack.enabled = false;
            Destroy(_playerAttack.WeaponParent.gameObject);
            _ragdollHandler.Enable();
            _playerAnimator.Disable();
            OnDie?.Invoke();
        }
    }
}
