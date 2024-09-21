using CodeBase.Player;
using System;

namespace CodeBase.Infrastructure.Services.Player
{
    public class PlayerProvider : IPlayerProvider
    {
        private PlayerBase _player;

        public PlayerBase Player
        {
            get
            {
                if (_player == null)
                    throw new InvalidOperationException("Player has not been set.");
                return _player;
            }
            set
            {
                if (_player != null)
                    throw new InvalidOperationException("Player has already been set.");
                _player = value;
            }
        }
        public void CleanUp() => _player = null;
    }
}
