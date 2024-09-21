using CodeBase.Infrastructure.Services.Pause;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyMoveToTarget : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private float MinimalDistance = 0.1f;
        [SerializeField] private Transform _target;
        [SerializeField] private AnimatorController _animator;

        private float _tempSpeedFactor;

        public float Speed;

        private bool TargetNotReached => Vector3.Distance(_target.position, transform.position) >= MinimalDistance;

        public void Construct(AnimatorController enemyAnimator, Transform target)
        {
            _animator = enemyAnimator;
            _target = target;
        }

        private void Update()
        {
            if (TargetNotReached)
            {
                var dir = transform.position - _target.position;
                transform.LookAt(_target.position);
                transform.Translate(dir.normalized * Speed * Time.deltaTime);
                _animator.PlayMove();
            }
            else
                _animator.StopMove();
        }

        public void SetPaused(bool isPaused)
        {
            if (isPaused)
                _tempSpeedFactor = Speed;
            Speed = isPaused ? 0 : _tempSpeedFactor;
        }
    }
}
