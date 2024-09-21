using CodeBase.Weapons;
using UnityEngine;

namespace CodeBase.StaticData.WeaponSelectPanel
{
    [CreateAssetMenu(fileName = "WeaponSelectPanelItemView", menuName = "StaticData/WeaponSelectPanel/Item")]
    public class WeaponSelectPanelItem : ScriptableObject
    {
        public WeaponTypeId Id;
        public GameObject Model;
        public Vector3 Offset;
        public Sprite Sprite;
    }
}