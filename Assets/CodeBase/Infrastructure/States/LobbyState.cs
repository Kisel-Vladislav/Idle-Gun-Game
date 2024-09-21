using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class LobbyState : IState
    {
        private const string LobbySceneName = "Lobby";

        private readonly IUIFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;

        public LobbyState(IUIFactory uiFactory, SceneLoader sceneLoader)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(LobbySceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateLobby();
        }

        public void Exit()
        {
        }
    }
}