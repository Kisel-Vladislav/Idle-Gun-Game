using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.WeaponSelectPanel
{
    [CreateAssetMenu(fileName = "WeaponSelectPanelContent", menuName = "StaticData/WeaponSelectPanel/Content")]
    public class WeaponSelectPanelContent : ScriptableObject
    {
        public List<WeaponSelectPanelItem> Items;

        //private void OnValidate()
        //{
        //    var duplicatedItems = Items.GroupBy(item => item.Id)
        //                               .Where(group => group.Count() > 1)
        //                               .ToList();

        //    if (duplicatedItems.Count > 0)
        //    {
        //        var duplicatedItemGroup = duplicatedItems.First();
        //        var duplicatedId = duplicatedItemGroup.Key;
        //        var duplicatedItemNames = duplicatedItemGroup.Select(item => item.name).ToArray();
        //        var errorMessage = $"Duplicate items found for WeaponTypeId: {duplicatedId}\n"
        //                           + $"Duplicated items:\n {string.Join("\n", duplicatedItemNames)}";


        //        Debug.LogException(new InvalidOperationException(errorMessage));
        //    }
        //}
    }
}