using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Level;
using CodeBase.Infrastructure.Services.Player;
using CodeBase.Player;
using CodeBase.Player.Data;
using CodeBase.Weapons.Modifiers;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly ILevelService _levelService;
        private readonly PersistentProgress _persistentProgress;
        private readonly PauseService _pauseService;
        private readonly IPlayerProvider _playerProvider;
        private readonly ModifiersService _modifiersService;
        private readonly LevelProgression _levelProgression;
        public GameLoopState(PersistentProgress persistentProgress, PauseService pauseService, LevelProgression levelProgression, IPlayerProvider playerProvider, ModifiersService modifiersService, ILevelService levelService)
        {
            _levelService = levelService;
            _persistentProgress = persistentProgress;
            _pauseService = pauseService;
            _playerProvider = playerProvider;
            _modifiersService = modifiersService;
            _levelProgression = levelProgression;
        }

        public void Enter()
        {
            _levelService.ProgressWatcher.StartLevel();
        }

        public void Exit()
        {
            _persistentProgress.Player.WaveCount = _levelService.ProgressWatcher.WaveNumber - 1;

            _pauseService.CleanUp();
            _playerProvider.CleanUp();
            _modifiersService.CleanUp();
            _levelProgression.Reset();
        }
    }
}