using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Service;
using CodeBase.StaticData;
using CodeBase.UI.ModifierUI;
using CodeBase.Weapons.Modifiers;
using System;

namespace CodeBase.Infrastructure.Factory
{
    public class ModifiersViewFactory
    {
        private readonly IAssetProvider _assetProvider;

        public ModifiersViewFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public ModifiersView Create(Modifier modifier)
        {
            var modifiersView = _assetProvider.Instance<ModifiersView>(AssetsPath.ModifierView);

            var color = modifier.RarityType switch
            {
                RarityType.Common => ModifiersColor.Common,
                RarityType.Epic => ModifiersColor.Epic,
                RarityType.Rare => ModifiersColor.Rare,
                RarityType.Legendary => ModifiersColor.Legendary,
                RarityType.Uncommon => ModifiersColor.Uncommon,
                _ => throw new NotImplementedException()
            };
            //string description = $"{modifier.Operation.GetType().Name} {modifier.Operation.Value} to {modifier.StatType}";
            modifiersView.Construct(modifier, color);
            return modifiersView;
        }
    }
}