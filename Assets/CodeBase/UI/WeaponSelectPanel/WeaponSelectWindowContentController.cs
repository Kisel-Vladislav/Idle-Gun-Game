using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;
using CodeBase.StaticData.WeaponSelectPanel;
using CodeBase.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.WeaponSelectPanel
{
    public class WeaponSelectWindowContentController : MonoBehaviour
    {
        [SerializeField] private Transform _contentParent;
        [SerializeField] private ItemPlacement _itemPlacement;
        [SerializeField] private ItemInspect _itemInspect;
        [SerializeField] private StatsView _statsView;

        private WeaponSelectPanelItemFactory _itemViewFactory;
        private IStaticDataService _staticDataService;
        private WeaponSelectPanelItemView _previewedItem;

        public WeaponTypeId SelectItemID => _previewedItem.Item.Id;

        public void Construct(WeaponSelectPanelItemFactory itemViewFactory, IStaticDataService staticDataService)
        {
            _itemViewFactory = itemViewFactory;
            _staticDataService = staticDataService;
        }

        public void Fill(List<WeaponSelectPanelItem> content)
        {
            foreach (var item in content)
            {
                var itemView = CreateAndSubscribeItemView(item);

                if (_previewedItem == null)
                    ChangeItem(itemView);
            }
        }

        private WeaponSelectPanelItemView CreateAndSubscribeItemView(WeaponSelectPanelItem item)
        {
            var itemView = _itemViewFactory.Create(item, _contentParent);
            SubscribeToItemView(itemView);
            return itemView;
        }
        private void ChangeItem(WeaponSelectPanelItemView view)
        {
            _previewedItem?.UnSelect();

            view.Select();
            _previewedItem = view;

            UpdateItemStats();
            InstantiateInspectItem();
        }
        private void InstantiateInspectItem()
        {
            _itemPlacement.InstantiateModel(_previewedItem.Item.Model);
            _itemInspect.InspectItem = _itemPlacement.CurrentModel.transform;
        }
        private void SubscribeToItemView(WeaponSelectPanelItemView itemView) =>
            itemView.OnClick += ChangeItem;
        private void UpdateItemStats() =>
            _statsView.Fill(_staticDataService.ForWeapon(SelectItemID).AttackData);
    }
}