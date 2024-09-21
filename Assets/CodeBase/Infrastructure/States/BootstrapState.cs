using CodeBase.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IAudioService _audioService;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, IStaticDataService staticDataService, IAudioService audioService)
        {
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _audioService = audioService;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            InitializeServices();
            _stateMachine.Enter<LoadProgressState>();
        }
        public void Exit()
        {
        }

        private void InitializeServices()
        {
            InitStaticData();
            _audioService.Init();
        }
        private void InitStaticData()
        {
            _staticDataService.LoadModifier();
            _staticDataService.LoadWeapon();
            _staticDataService.LoadEnemy();
            _staticDataService.LoadEnemyWave();
            _staticDataService.LoadWeaponSelectItems();
        }

    }
}