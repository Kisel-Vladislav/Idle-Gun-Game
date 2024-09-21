using CodeBase.Weapons.Modifiers;
using UnityEngine;

namespace CodeBase.StaticData.Weapon
{
    [CreateAssetMenu(fileName = "ModifierStaticData", menuName = "StaticData/Modifier")]
    public class ModifierStaticData : ScriptableObject
    {
        public RarityType RarityType;
        public StatType StatType;
        public OperationType OperationType;
        public float Value;
        public Sprite Image;
        public string Description;
    }
}
