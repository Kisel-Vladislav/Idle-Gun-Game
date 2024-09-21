using CodeBase.StaticData;
using CodeBase.Weapons.Modifiers;
using NSubstitute;
namespace Tests
{
    public class Create
    {
        public static ModifiersService ModifierService() =>
            new ModifiersService();
        public static Modifier Modifier(StatType statType, IOperationStrategy operation) =>
            new Modifier(statType, operation, RarityType.Common, "");
        public static Modifier ModifierFor(Query query, IOperationStrategy operationStrategy) =>
            Modifier(query.StatType, operationStrategy);
        public static Modifier Modifier() =>
            Modifier(StatType.Attack, Substitute.For<IOperationStrategy>());
    }
}