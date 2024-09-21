using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.InputService;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.Level;
using CodeBase.Infrastructure.Services.Player;
using CodeBase.Player;
using CodeBase.Player.Data;
using CodeBase.StaticData;
using CodeBase.Weapons.Modifiers;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindingPlayerService();
            BindingAssetManagementService();
            BindingCoreService();
            BindingDataService();
        }

        private void BindingDataService()
        {
            BindingPersistentProgress();
        }
        private void BindingCoreService()
        {
            BindingCoroutineRunner();
            BindingModifiersService();
            BindingPauseService();
            BindingLevelService();

            BindingAudioService();
        }
        private void BindingAssetManagementService()
        {
            BindingSceneLoader();
            BindingAssetProvider();
            BindingStataDataService();
        }
        private void BindingPlayerService()
        {
            BindingPlayerProvider();
            BindingLevelProgression();
            BindingInputService();
        }
        private void BindFactories()
        {
            BindingWeaponFactory();
            BindingModifiersFactory();
            BindingModifiersViewFactory();
            BindingEnemyFactory();
            BindingGameFactory();
            BindingUIFactory();
        }
        private void BindingLevelProgression() =>
            Container.Bind<LevelProgression>()
                .AsSingle()
                .NonLazy();

        private void BindingPersistentProgress() =>
            Container.Bind<PersistentProgress>()
                .AsSingle()
                .NonLazy();
        private void BindingLevelService() =>
            Container.Bind<ILevelService>()
                .To<LevelService>()
                .AsSingle()
                .NonLazy();
        private void BindingUIFactory() =>
            Container.Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle()
                .NonLazy();
        private void BindingPauseService() =>
            Container.Bind<PauseService>()
                .AsSingle();
        private void BindingModifiersService() =>
            Container.Bind<ModifiersService>()
                     .AsSingle();
        private void BindingSceneLoader() =>
            Container.Bind<SceneLoader>()
                     .AsSingle()
                     .NonLazy();
        private void BindingPlayerProvider() =>
            Container.Bind<IPlayerProvider>()
                     .To<PlayerProvider>()
                     .AsSingle()
                     .NonLazy();
        private void BindingCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>()
                     .FromInstance(this)
                     .AsSingle();
        private void BindingAudioService() =>
            Container.Bind<IAudioService>()
                     .To<AudioService>()
                     .AsSingle()
                     .NonLazy();
        private void BindingInputService() =>
            Container.Bind<IInputService>()
                     .To<StandartInputService>()
                     .AsSingle()
                     .NonLazy();
        private void BindingStataDataService() =>
            Container.Bind<IStaticDataService>()
                     .To<StaticDataService>()
                     .AsSingle()
                     .NonLazy();
        private void BindingAssetProvider() =>
            Container.Bind<IAssetProvider>()
                     .To<AssetProvider>()
                     .AsSingle()
                     .NonLazy();
        private void BindingGameFactory() =>
            Container.Bind<IPlayerFactory>()
                     .To<PlayerFactory>()
                     .AsSingle()
                     .NonLazy();
        private void BindingEnemyFactory() =>
            Container.Bind<IEnemyFactory>()
                     .To<EnemyFactory>()
                     .AsSingle()
                     .NonLazy();
        private void BindingWeaponFactory() =>
            Container.Bind<WeaponFactory>()
                     .AsSingle()
                     .NonLazy();
        private void BindingModifiersFactory() =>
            Container.Bind<ModifierFactory>()
                     .AsSingle()
                     .NonLazy();
        private void BindingModifiersViewFactory() =>
            Container.Bind<ModifiersViewFactory>()
                     .AsSingle()
                     .NonLazy();
    }
}
