using CodeBase.Infrastructure.Service.InputService;
using CodeBase.Player;
using CodeBase.Weapons;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;

        private IWeapon _weapon;
        private IInputService _inputService;

        public Transform WeaponParent;

        public void Construct(IInputService inputService) => _inputService = inputService;
        
        private void Update()
        {

            if (_inputService.IsAttacking())
            {
                _animator.StartAttack();
                _weapon.Attack();
            }
            else
                _animator.StopAttack();
        }

        public void SetUpWeapon(IWeapon weapon) => _weapon = weapon;

    }
}