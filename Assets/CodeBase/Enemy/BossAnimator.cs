using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class BossAnimator : AnimatorController, IAnimationStateReader
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _movingStateHash = Animator.StringToHash("Move");
        private readonly int _wakeUpStateHash = Animator.StringToHash("WakeUp");
        private readonly int _attackStateHash = Animator.StringToHash("Attack");
        private readonly int _dieStateHash = Animator.StringToHash("Die");

        public AnimatorState State => AnimatorState.Start;

        public override void PlayAttack() =>
            _animator.SetTrigger(Attack);
        public override void PlayDie() =>
            _animator.SetTrigger(Die);
        public override void PlayMove() =>
            _animator.SetBool(IsMoving, true);
        public override void StopMove() =>
            _animator.SetBool(IsMoving, false);

        public void EnteredState(int stateHash)
        {
        }

        public void ExitedState(int stateHash)
        {
        }
    }
}
