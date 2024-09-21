using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.Player;
using CodeBase.Infrastructure.States;
using CodeBase.Player;
using CodeBase.Player.Data;
using CodeBase.StaticData;
using CodeBase.UI;
using CodeBase.UI.Window;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly LevelProgression _levelProgression;
        private readonly PersistentProgress _persistentProgress;
        private readonly IAudioService _audioService;

        private Canvas _uiRoot;

        public UIFactory(GameStateMachine gameStateMachine, IAssetProvider assetProvider, IPlayerProvider playerProvider, IStaticDataService staticDataService, LevelProgression levelProgression, PersistentProgress persistentProgress, IAudioService audioService)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
            _playerProvider = playerProvider;
            _staticDataService = staticDataService;
            _levelProgression = levelProgression;
            _persistentProgress = persistentProgress;
            _audioService = audioService;
        }

        public void CreateUIRoot() =>
            _uiRoot = _assetProvider.Instance<Canvas>(AssetsPath.UIRoot);
        public LobbyController CreateLobby()
        {
            var lobbyController = _assetProvider.Instance<LobbyController>(AssetsPath.Lobby, _uiRoot.transform);
            lobbyController.Construct(_gameStateMachine, CreateWeaponSelectWindow(), _audioService);
            lobbyController.Initialize();
            return lobbyController;
        }
        public void CreateHUD()
        {
            var hud = _assetProvider.Instance<ActorUI>(AssetsPath.HUDPath, _uiRoot.transform);
            hud.Construct(_levelProgression);
        }
        public WeaponSelectWindow CreateWeaponSelectWindow()
        {
            var weaponSelectWindow = _assetProvider.Instance<WeaponSelectWindow>(AssetsPath.WeaponSelectWindow, _uiRoot.transform);
            ConstructOneButtonWindow(weaponSelectWindow);
            weaponSelectWindow.Construct(_staticDataService, _persistentProgress);
            weaponSelectWindow._contentController.Construct(new WeaponSelectPanelItemFactory(_assetProvider, _audioService), _staticDataService);
            return weaponSelectWindow;
        }

        private void ConstructOneButtonWindow(OneButtonWindow oneButtonSelectWindow) =>
            oneButtonSelectWindow.Construct(_audioService);
    }
}