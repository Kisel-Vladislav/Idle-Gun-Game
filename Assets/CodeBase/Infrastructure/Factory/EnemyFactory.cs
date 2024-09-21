using CodeBase.Enemy;
using CodeBase.Enemy.Attack.AttackBehevior;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Pause;
using CodeBase.Infrastructure.Services.Player;
using CodeBase.StaticData;
using CodeBase.StaticData.Enemy;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
        private readonly IPlayerProvider _playerProvider;
        private readonly PauseService _pauseService;

        public EnemyFactory(IAssetProvider assetProvider, IStaticDataService staticData, IPlayerProvider playerProvider, PauseService pauseService)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
            _playerProvider = playerProvider;
            _pauseService = pauseService;
        }

        public EnemyBase Create(EnemyTypeId id, Vector3 position, Quaternion rotation)
        {
            var enemyData = GetEnemyData(id);

            var enemy = InstanceEnemy(position, rotation, enemyData);
            RegisterForPause(enemy);

            ConfigureEnemy(enemyData, enemy);

            return enemy;
        }

        private EnemyBase InstanceEnemy(Vector3 position, Quaternion rotation, EnemyStaticData enemyData)
        {
            return _assetProvider.Instance(enemyData.Prefab, position, rotation)
                            .GetComponent<EnemyBase>();
        }
        private EnemyStaticData GetEnemyData(EnemyTypeId id)
        {
            return _staticData.ForEnemy(id);
        }
        private void RegisterForPause(EnemyBase enemy)
        {
            foreach (var pauseHandler in enemy.GetComponentsInChildren<IPauseHandler>())
                _pauseService.Register(pauseHandler);
            enemy.Death.OnDie += UnRegister;
        }
        private void UnRegister(EnemyDeath death)
        {
            foreach (var pauseHandler in death.gameObject.GetComponentsInChildren<IPauseHandler>())
                _pauseService.UnRegister(pauseHandler);

            death.OnDie -= UnRegister;
        }
        private void ConfigureAttack(EnemyBase enemy, EnemyStaticData enemyStaticData)
        {
            EnemyOverlapAttackBase enemyAttack = enemyStaticData.AttackType switch
            {
                EnemyAttackType.Overlap => new EnemyOverlapAttackBehaviour(enemy.transform, enemyStaticData.OverlapAttackData),
                EnemyAttackType.Explore => new EnemyExplosionAttackBehaviour(enemy.transform, enemyStaticData.ExploreAttackData, enemy.Health),
                _ => throw new System.NotImplementedException(),
            };

            enemy.Attack.Construct(enemyAttack);
        }
        private void ConfigureEnemy(EnemyStaticData enemyData, EnemyBase enemy)
        {
            ConfigureMove(enemy, enemyData);
            ConfigureHealth(enemy, enemyData);
            ConfigureDeath(enemy, enemyData);
            ConfigureAttack(enemy, enemyData);
        }
        private void ConfigureDeath(EnemyBase enemy, EnemyStaticData enemyData)
        {   
            enemy.Death.Construct(enemy.Animator, enemy.Health, enemyData.ExperienceReward);
        }
        private void ConfigureHealth(EnemyBase enemy, EnemyStaticData enemyData)
        {
            enemy.Health = new Health
            {
                Current = enemyData.MaxHealth,
                Max = enemyData.MaxHealth,
            };
        }
        private void ConfigureMove(EnemyBase enemy, EnemyStaticData enemyStaticData)
        {
            enemy.Move.Construct(enemy.Animator, _playerProvider.Player.gameObject.transform);
            enemy.Move.Speed = enemyStaticData.MoveSpeed;
        }
    }
}

