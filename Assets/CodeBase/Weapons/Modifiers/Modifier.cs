
using CodeBase.StaticData;

namespace CodeBase.Weapons.Modifiers
{
    public class Modifier
    {
        public readonly IOperationStrategy Operation;
        public readonly StatType StatType;
        public readonly RarityType RarityType;
        public readonly string Description;
        public Modifier(StatType statType, IOperationStrategy operation, RarityType rarityType, string description)
        {
            StatType = statType;
            Operation = operation;
            RarityType = rarityType;
            Description = description;
        }
        public void Handle(Query query)
        {
            if (query.StatType == StatType)
                query.Value = Operation.Calculate(query.Value);
        }
    }

    public enum OperationType
    {
        Add,
        Multiply
    }
}
