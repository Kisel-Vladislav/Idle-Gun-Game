using CodeBase.Logic;
using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : AnimatorController, IAnimationStateReader
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _movingStateHash = Animator.StringToHash("Move");
        private readonly int _startStateHash = Animator.StringToHash("Start");

        public event Action<AnimatorState> SateEntered;
        public event Action<AnimatorState> SateExited;

        public AnimatorState State => AnimatorState.Start;

        public override void PlayMove() =>
            _animator.SetBool(IsMoving, true);
        public override void StopMove() =>
            _animator.SetBool(IsMoving, false);

        public override void PlayDie() { }

        public void EnteredState(int stateHash)
        {
        }

        public void ExitedState(int stateHash)
        {
        }
    }
}
