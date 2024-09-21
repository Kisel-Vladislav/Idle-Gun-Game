using UnityEngine;

namespace CodeBase.Enemy.Attack
{
    public class EnemyOverlapAttack : EnemyAttack
    {
        private Transform _target;

        public override void Attack(Transform target)
        {
            _target = target;
            transform.LookAt(_target);
            _animatorController.PlayAttack();
        }
        public override void OnAttack() =>
            _overlapAttack.Attack();
    }
}