using CodeBase.Service;
using CodeBase.StaticData;
using CodeBase.Weapons.Modifiers;
using System;
using System.Linq;
using Random = System.Random;

namespace CodeBase.Infrastructure.Factory
{
    public class ModifierFactory
    {
        private readonly IStaticDataService _staticData;

        public ModifierFactory(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public Modifier Create(StatType statType, OperationType op, float value, RarityType rarityType, string description)
        {
            IOperationStrategy operation = op switch
            {
                OperationType.Add => new AddOperation(value),
                OperationType.Multiply => new MultiplyOperation(value),
                _ => throw new ArgumentOutOfRangeException()
            };
            return new Modifier(statType, operation, rarityType, description);
        }
        public Modifier CreateRandom()
        {
            var random = new Random();
            var rarityValue = random.Next(1, 101);
            var rarityType = DetermineRarity(rarityValue);

            return CreateRandom(rarityType);
        }
        public Modifier CreateRandom(RarityType rarityType)
        {
            var modifiers = _staticData.ForModifiers(rarityType).ToList();
            var random = new Random();
            var modifierData = modifiers[random.Next(modifiers.Count)];

            return Create(modifierData.StatType, modifierData.OperationType, modifierData.Value, modifierData.RarityType, modifierData.Description);
        }

        private RarityType DetermineRarity(int value)
        {
            int[] thresholds =
            {
                RarityConstants.CommonPercentage,
                RarityConstants.UncommonPercentage,
                RarityConstants.RarePercentage,
                RarityConstants.EpicPercentage,
                RarityConstants.LegendaryPercentage
            };

            RarityType[] rarityTypes =
            {
                RarityType.Common,
                RarityType.Uncommon,
                RarityType.Rare,
                RarityType.Epic,
                RarityType.Legendary
            };

            var cumulative = 0;
            for (var i = 0; i < thresholds.Length; i++)
            {
                cumulative += thresholds[i];
                if (value <= cumulative)
                    return rarityTypes[i];
            }

            return RarityType.Common;
        }
    }
}
