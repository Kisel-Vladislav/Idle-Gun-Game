using CodeBase.Enemy;
using CodeBase.Extensions;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData.Enemy;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace CodeBase.Logic.Spawner
{
    public class EnemyPoolSpawner : MonoBehaviour
    {
        private IEnemyFactory _enemyFactory;
        private ObjectPool<EnemyBase> _pool;
        private Transform PoolParent;
        public void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _pool = new ObjectPool<EnemyBase>(Create, ResetState, null, Destory);

            var poolParent = new GameObject("[EnemyPool]");
            PoolParent = poolParent.transform;
        }

        public IEnumerator SpawnCorutine(float delay, int spawnCount)
        {
            var waitForSeconds = new WaitForSeconds(delay);
            while (spawnCount > 0)
            {
                yield return waitForSeconds;
                Spawn();
                spawnCount--;
            }
        }
        private void Spawn()
        {
            var enemy = _pool.Get();
            enemy.gameObject.SetActive(true);
        }
        public EnemyBase Create()
        {
            var enemy = _enemyFactory.Create(EnemyTypeId.Witch, SpawnPosition(), Quaternion.identity);
            enemy.GetComponent<EnemyDeath>().OnDie += ReturnToPool;
            enemy.gameObject.transform.SetParent(PoolParent.transform, false);
            return enemy;
        }
        private void ResetState(EnemyBase enemy)
        {
            //enemy.Health.ResetToMax();

            enemy.transform.position = SpawnPosition();
            enemy.transform.rotation = Quaternion.identity;
        }
        private void Destory(EnemyBase enemy) =>
            enemy.Death.OnDie -= ReturnToPool;
        private void ReturnToPool(EnemyDeath enemyDeath)
        {
            enemyDeath.gameObject.SetActive(false);
            _pool.Release(enemyDeath.gameObject.GetComponent<EnemyBase>());
        }
        private Vector3 SpawnPosition() =>
            gameObject.transform.position.RandomPointInAnnulus(1, 5);
    }
}
