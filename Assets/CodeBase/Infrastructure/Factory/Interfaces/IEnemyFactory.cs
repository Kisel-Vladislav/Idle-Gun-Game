using CodeBase.Enemy;
using CodeBase.StaticData.Enemy;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IEnemyFactory
    {
        EnemyBase Create(EnemyTypeId id, Vector3 position, Quaternion rotation);
    }
}