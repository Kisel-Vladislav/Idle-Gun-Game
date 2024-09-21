using CodeBase.Enemy;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Service.InputService;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Player;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{

    public class PlayerFactory : IPlayerFactory
    {
        private readonly IInputService _inputService;
        private readonly IAssetProvider _assetProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly PauseService _pauseService;

        public PlayerFactory(IAssetProvider assetProvider, IInputService inputService, IPlayerProvider playerProvider, PauseService pauseService)
        {
            _playerProvider = playerProvider;
            _inputService = inputService;
            _assetProvider = assetProvider;
            _pauseService = pauseService;
        }

        public PlayerBase Create(Vector3 at)
        {
            var player = _assetProvider.Instance<PlayerBase>(AssetsPath.PlayerPath);

            ConfigureMove(player);
            ConfigureAttack(player);
            ConfigureHealth(player);
            ConfigureDeath(player);

            _playerProvider.Player = player;
            RegisterPauseHandlers(player);

            return player;
        }

        private void ConfigureMove(PlayerBase player) =>
            player.Move.Construct(_inputService);
        private void ConfigureAttack(PlayerBase player) =>
            player.Attack.Construct(_inputService);
        private void ConfigureHealth(PlayerBase player) =>
            player.Health = new Health
            {
                // TODO static data
                Max = 100,
                Current = 100,
                //
            };
        private void ConfigureDeath(PlayerBase player) =>
            player.Death.Construct(player.Health, player.Animator);
        private void RegisterPauseHandlers(PlayerBase player) =>
            _pauseService.Register(player);
    }
}

