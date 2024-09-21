using CodeBase.Infrastructure.Service.InputService;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private PlayerAnimator _animator;

        private IInputService _inputService;

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.X == 0)
            {
                _animator.StopMove();
                return;
            }

            var newPossition = new Vector3(_inputService.X, 0);
            _animator.PlayMove(_inputService.X);
            newPossition *= _speed * Time.deltaTime;
            transform.Translate(newPossition);
        }
    }
}