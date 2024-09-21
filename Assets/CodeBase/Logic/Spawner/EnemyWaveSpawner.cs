using CodeBase.Enemy;
using CodeBase.Extensions;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.Pause;
using CodeBase.Player;
using CodeBase.StaticData.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Spawner
{
    public class EnemyWaveSpawner : MonoBehaviour, IPauseHandler
    {
        private IEnemyFactory _enemyFactory;
        private LevelProgression _levelProgression;

        private WaveGenerator _waveGenerator;
        private bool _isPaused;
        private int _enemyCount;

        public event Action WaveCompleted;

        [Inject]
        public void Construct(IEnemyFactory enemyFactory, LevelProgression levelProgression, WaveGenerator waveGenerator)
        {
            _enemyFactory = enemyFactory;
            _levelProgression = levelProgression;
            _waveGenerator = waveGenerator;
        }
        public void StartWave(int waveNumber)
        {
            var enemiesId = _waveGenerator.Generate(waveNumber);
            StartCoroutine(Spawn(enemiesId));
        }
        public IEnumerator Spawn(Queue<EnemyTypeId> queue)
        {
            var waitForSecond = new WaitForSeconds(1);
            while (queue.TryDequeue(out var enemiId))
            {
                while (_isPaused)
                    yield return waitForSecond;

                var enemy = _enemyFactory.Create(enemiId, SpawnPosition(), Quaternion.identity);
                enemy.Death.OnDie += Slay;
                _enemyCount++;
                yield return waitForSecond;
            }

            while (_enemyCount > 0)
                yield return null;

            WaveCompleted?.Invoke();
        }

        private Vector3 SpawnPosition() =>
            gameObject.transform.position.RandomPointInAnnulus(minRadius: 1, maxRadius: 5);
        private void Slay(EnemyDeath death)
        {
            _levelProgression.AddExperience(death.ExperienceReward);
            Destroy(death.gameObject);
            _enemyCount--;
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}
