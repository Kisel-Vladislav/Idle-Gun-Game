using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Level;
using CodeBase.Player;
using CodeBase.Player.Data;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerFactory _playerFactory;
        private readonly WeaponFactory _weaponFactory;
        private readonly PersistentProgress _persistentProgress;
        private readonly ILevelService _levelService;
        private readonly PauseService _pauseService;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, PersistentProgress persistentProgress, IUIFactory uiFactory, IPlayerFactory playerFactory, WeaponFactory weaponFactory, ILevelService levelService, PauseService pauseService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _playerFactory = playerFactory;
            _weaponFactory = weaponFactory;
            _persistentProgress = persistentProgress;
            _levelService = levelService;
            _pauseService = pauseService;
        }

        public void Enter()
        {
            _sceneLoader.Load("Game", OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InitUI();
            RegisterOnPauseService();

            _levelService.ProgressWatcher.WaveNumber = _persistentProgress.Player.WaveCount;

            _stateMachine.Enter<GameLoopState>();
        }

        private void RegisterOnPauseService()
        {
            _pauseService.Register(_levelService.WordObjectCollector.EnemyWaveSpawner);
        }

        private void InitGameWorld()
        {
            InitPlayer();
            _levelService.WordObjectCollector.ModifiersSystem.Initialize();
        }

        private void InitPlayer()
        {
            var player = _playerFactory.Create(at: _levelService.WordObjectCollector.SpawnPoint.position);
            player.Attack.SetUpWeapon(_weaponFactory.Create(_persistentProgress.Player.SelectWeapon, player.Attack.WeaponParent));
            SubscribeToPlayerEvents(player);
        }

        private void SubscribeToPlayerEvents(PlayerBase player)
        {
            player.Death.OnDie += _levelService.ProgressWatcher.EndLevel;
            player.Death.OnDie += () => _pauseService.SetPaused(true);
        }

        private void InitUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateHUD();
        }

        public void Exit()
        {

        }
    }
}