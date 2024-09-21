using CodeBase.Infrastructure.Services.Pause;
using UnityEngine;

namespace CodeBase.Logic
{
    public class AnimatorController : MonoBehaviour, IPauseHandler
    {
        protected Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public virtual void PlayAttack() { }
        public virtual void PlayDie() { }
        public virtual void PlayMove() { }
        public virtual void StopMove() { }
        public void SetPaused(bool isPaused)
        {
            _animator.speed = isPaused ? 0 : 1;
        }
    }
}
