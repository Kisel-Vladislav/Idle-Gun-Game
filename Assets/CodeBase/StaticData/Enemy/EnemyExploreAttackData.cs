using System;
using UnityEngine;

namespace CodeBase.StaticData.Enemy
{
    [Serializable]
    public class EnemyExploreAttackData
    {
        public float Damage;
        public LayerMask SearchLayerMask;
    }
}