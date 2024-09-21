using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.States;
using CodeBase.UI.Window;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class LobbyController : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _exitButton;

        [SerializeField] private AudioClip _playButtonPress;
        [SerializeField] private AudioClip _defaultButtonPress;

        private GameStateMachine _gameStateMachine;
        private WeaponSelectWindow _weaponSelectWindow;
        private IAudioService _audioService;

        public void Construct(GameStateMachine gameStateMachine, WeaponSelectWindow weaponSelectWindow, IAudioService audioService)
        {
            _gameStateMachine = gameStateMachine;
            _weaponSelectWindow = weaponSelectWindow;
            _audioService = audioService;
        }
        public void Initialize()
        {
            SetupButtons();
            _weaponSelectWindow.gameObject.SetActive(false);
        }

        private void SetupButtons()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnExitButtonClick()
        {
            _audioService.Play(_defaultButtonPress);
            Application.Quit();
        }

        private async void OnPlayButtonClick()
        {
            _audioService.Play(_playButtonPress);
            var result = await _weaponSelectWindow.InitAndShow();
            if (result)
                _gameStateMachine.Enter<LoadLevelState>();
        }
    }
}