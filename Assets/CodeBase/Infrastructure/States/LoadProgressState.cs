using CodeBase.Player.Data;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PersistentProgress _progress;

        public LoadProgressState(GameStateMachine stateMachine, PersistentProgress progress)
        {
            _stateMachine = stateMachine;
            _progress = progress;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _stateMachine.Enter<LobbyState>();
        }

        private void LoadProgressOrInitNew()
        {
            _progress.Player = new PlayerData()
            {
                SelectWeapon = Weapons.WeaponTypeId.AR,
                WaveCount = 1,
            };
        }

        public void Exit()
        {
        }
    }
}