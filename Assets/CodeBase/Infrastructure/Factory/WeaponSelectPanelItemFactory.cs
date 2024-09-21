using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.StaticData.WeaponSelectPanel;
using CodeBase.UI.WeaponSelectPanel;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class WeaponSelectPanelItemFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IAudioService _audioService;

        public WeaponSelectPanelItemFactory(IAssetProvider assetProvider, IAudioService audioService)
        {
            _assetProvider = assetProvider;
            _audioService = audioService;
        }

        public WeaponSelectPanelItemView Create(WeaponSelectPanelItem item, Transform parent)
        {
            var weaponSelectPanelItemView = _assetProvider.Instance<WeaponSelectPanelItemView>(AssetsPath.WeaponSelectPanelItemView, parent);
            weaponSelectPanelItemView.Construct(_audioService);
            weaponSelectPanelItemView.Initialize(item);
            return weaponSelectPanelItemView;
        }
    }
}