using CodeBase.Infrastructure.States;
using CodeBase.Logic.Spawner;
using CodeBase.Player.Data;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.Level
{
    public class LevelProgressWatcher : MonoBehaviour
    {
        [SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;

        private GameStateMachine _stateMachine;
        private readonly PersistentProgress _persistentProgress;

        public int WaveNumber;

        [Inject]
        public void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void StartLevel()
        {
            _enemyWaveSpawner.StartWave(WaveNumber);
            _enemyWaveSpawner.WaveCompleted += NextWave;
        }
        public async void EndLevel()
        {
            await Task.Delay(5000);
            _stateMachine.Enter<LobbyState>();
            _enemyWaveSpawner.WaveCompleted -= NextWave;
        }
        private void NextWave()
        {
            _enemyWaveSpawner.StartWave(WaveNumber++);
        }
    }
}