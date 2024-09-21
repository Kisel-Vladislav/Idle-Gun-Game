using CodeBase.StaticData.Enemy;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Logic.Spawner
{
    public class WaveGenerator
    {
        public List<EnemyWave> enemies;

        public WaveGenerator(List<EnemyWave> enemies)
        {
            this.enemies = enemies;
        }
        public Queue<EnemyTypeId> Generate(int waveNumber)
        {
            var wave = new Queue<EnemyTypeId>();
            var waveCost = waveNumber * 100;

            var minEnemyCost = enemies.Min(x => x.cost);

            while (waveCost > minEnemyCost)
            {
                var i = Random.Range(0, enemies.Count);

                if (waveCost - enemies[i].cost > 0)
                {
                    wave.Enqueue(enemies[i].Id);
                    waveCost -= enemies[i].cost;
                }
            }
            return wave;
        }
    }
}
