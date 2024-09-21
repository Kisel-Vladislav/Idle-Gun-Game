using CodeBase.StaticData.Weapon;
using CodeBase.Weapons.AttackBehaviour;

namespace CodeBase.Weapons
{
    public class Weapon : IWeapon
    {
        private readonly WeaponStaticData _weaponStats;
        private readonly IAttackBehaviour _attackBehaviour;
        public Weapon(IAttackBehaviour attackBehaviour)
        {
            _attackBehaviour = attackBehaviour;
        }

        public void Attack()
        {
            _attackBehaviour.Attack();
        }
    }

}