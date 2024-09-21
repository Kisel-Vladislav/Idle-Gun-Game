using CodeBase.StaticData.Weapon;
using CodeBase.Weapons.Modifiers;
using UnityEngine;

namespace CodeBase.Weapons.AttackBehaviour
{
    public abstract class AttackBehaviour : IAttackBehaviour
    {
        protected readonly Transform _attackStartPoint;
        protected readonly WeaponAttackData _attackData;
        protected readonly ModifiersService Modifiers;
        public AttackBehaviour(Transform attackStartPoint, WeaponAttackData attackData, ModifiersService modifiersMediator)
        {
            _attackStartPoint = attackStartPoint;
            _attackData = attackData;

            Modifiers = modifiersMediator;
        }

        public abstract void Attack();
    }
}
