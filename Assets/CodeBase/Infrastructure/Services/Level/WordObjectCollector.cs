using CodeBase.Logic.Spawner;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Level
{
    public class WordObjectCollector
    {
        public Transform SpawnPoint;
        public EnemyWaveSpawner EnemyWaveSpawner { get; set; }
        public ModifierSystemController ModifiersSystem { get; set; }
    }
}