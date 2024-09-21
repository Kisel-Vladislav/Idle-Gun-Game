using CodeBase.Player;

namespace CodeBase.Infrastructure.Services.Player
{
    public interface IPlayerProvider
    {
        public PlayerBase Player { get; set; }

        void CleanUp();
    }
}

