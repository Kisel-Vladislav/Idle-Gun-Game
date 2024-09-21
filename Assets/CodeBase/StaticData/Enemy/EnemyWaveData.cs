using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Enemy
{
    [CreateAssetMenu(fileName = "EnemyWaveData", menuName = "StaticData/👿 Enemy/WaveEnemy")]
    public class EnemyWaveData : ScriptableObject
    {
        public EnemyWaveTypeId Id;
        public List<EnemyWave> Enemy;
    }

    [Serializable]
    public class EnemyWave
    {
        public EnemyTypeId Id;
        public int cost;
    }
}
