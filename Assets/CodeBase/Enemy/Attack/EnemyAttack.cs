using CodeBase.Enemy.Attack.AttackBehevior;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy.Attack
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] protected AnimatorController _animatorController;

        protected EnemyOverlapAttackBase _overlapAttack;

        public void Construct(EnemyOverlapAttackBase overlapAttack) => 
            _overlapAttack = overlapAttack;

        public virtual void Attack(Transform target)
        {
            transform.LookAt(target);
            _animatorController.PlayAttack();
            _overlapAttack.Attack();
        }
        public virtual void OnAttack() { }
    }
}