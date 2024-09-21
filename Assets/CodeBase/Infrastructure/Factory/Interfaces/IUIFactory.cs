using CodeBase.UI;
using CodeBase.UI.Window;

namespace CodeBase.Infrastructure.Factory
{
    public interface IUIFactory
    {
        void CreateHUD();
        LobbyController CreateLobby();
        void CreateUIRoot();
        WeaponSelectWindow CreateWeaponSelectWindow();
    }
}