using CodeBase.Infrastructure.Services.Level;
using CodeBase.Logic.Spawner;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform PlayerInitialPoint;
        public EnemyWaveSpawner EnemyWaveSpawner;
        public ModifierSystemController ModifierSystem;
        public LevelProgressWatcher ProgressWatcher;

        public override void InstallBindings()
        {
            var levelService = Container.Resolve<ILevelService>();

            levelService.WordObjectCollector = new WordObjectCollector()
            {
                SpawnPoint = PlayerInitialPoint,
                EnemyWaveSpawner = EnemyWaveSpawner,
                ModifiersSystem = ModifierSystem,
            };
            levelService.ProgressWatcher = ProgressWatcher;

            WaveGenerator waveGenerator = new WaveGenerator(Container.Resolve<IStaticDataService>().ForLevel(EnemyWaveTypeId.All).Enemy);
            Container.Bind<WaveGenerator>().FromInstance(waveGenerator);
        }
    }
}
