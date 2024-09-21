using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Weapons.Modifiers
{
    public class ModifiersService
    {
        private readonly List<Modifier> _modifiers = new List<Modifier>();
        private readonly IStatModifierApplicationOrder order = new NormalStatModifierOrder();

        public List<Modifier> Modifiers { get => _modifiers; }

        public void PerformQuery(Query query)
        {
            var modifiers = _modifiers.Where(modifier => modifier.StatType == query.StatType).ToList();
            query.Value = order.Apply(modifiers, query.Value);
        }

        public void AddModifier(Modifier modifier) =>
            _modifiers.Add(modifier);

        public void CleanUp()
        {
            _modifiers.Clear();
        }
    }
    public interface IStatModifierApplicationOrder
    {
        float Apply(IEnumerable<Modifier> statModifiers, float baseValue);
    }

    public class NormalStatModifierOrder : IStatModifierApplicationOrder
    {
        public float Apply(IEnumerable<Modifier> statModifiers, float baseValue)
        {
            var allModifiers = statModifiers.ToList();

            foreach (var modifier in allModifiers.Where(modifier => modifier.Operation is AddOperation))
            {
                baseValue = modifier.Operation.Calculate(baseValue);
            }

            foreach (var modifier in allModifiers.Where(modifier => modifier.Operation is MultiplyOperation))
            {
                baseValue = modifier.Operation.Calculate(baseValue);
            }

            return baseValue;
        }
    }
}
