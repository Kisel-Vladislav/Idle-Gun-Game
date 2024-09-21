using CodeBase.Logic;
using System;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour, IAnimationStateReader
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");
        private static readonly int Blend = Animator.StringToHash("Blend");

        private Animator _animator;
        public AnimatorState State => throw new NotImplementedException();

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayMove(float horizontal)
        {
            _animator.SetBool(IsMoving, true);
            _animator.SetFloat(Blend, Math.Clamp(horizontal, 0, 1));
        }
        public void StopMove() => _animator.SetBool(IsMoving, false);
        public void StartAttack() => _animator.SetBool(IsAttack, true);
        public void StopAttack() => _animator.SetBool(IsAttack, false);
        public void EnteredState(int stateHash)
        {
        }
        public void ExitedState(int stateHash)
        {
        }
        public void Disable() => _animator.enabled = false;
        public void SetSpeed(int v) => _animator.speed = v;
    }
}
