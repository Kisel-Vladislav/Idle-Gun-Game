using CodeBase.Enemy;
using CodeBase.Infrastructure.Services.Pause;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerBase : MonoBehaviour, IDamageable, IPauseHandler
    {
        public PlayerMove Move;
        public PlayerAttack Attack;
        public Health Health;
        public PlayerDeath Death;
        public PlayerAnimator Animator;

        public void TakeDamage(float damage) => 
            Health.TakeDamage(damage);
        public void SetPaused(bool isPaused)
        {
            Attack.enabled = !isPaused;
            Move.enabled = !isPaused;
            Animator.SetSpeed(isPaused ? 0 : 1);
        }
    }
}