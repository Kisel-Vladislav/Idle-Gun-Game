using System;
using UnityEngine;

namespace CodeBase.StaticData.Enemy
{
    [Serializable]
    public class EnemyOverlapAttackData
    {
        public float FireRate;
        public float Damage;
        public LayerMask SearchLayerMask;
    }
}