using CodeBase.Weapons.Modifiers;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ModifiersServiceTest
    {
        private ModifiersService _modifierService;

        [SetUp]
        public void SetUp()
        {
            _modifierService = Create.ModifierService();
        }

        [Test]
        public void WhenAddModifier_AndModifierCountZero_ThenModifierCountShouldBeOne()
        {
            // Arrange.
            var modifier = Create.Modifier(StatType.Attack, new AddOperation(0));

            // Act.
            _modifierService.AddModifier(modifier);

            // Assert.
            _modifierService.Modifiers.Count.Should().Be(1);
        }
        [Test]
        public void WhenPerformQuery_AndModifiersExist_ThenApplyModifiersToQueryValue()
        {
            // Arrange.
            var query = new Query(StatType.Attack, 0);

            _modifierService.AddModifier(Create.ModifierFor(query, new AddOperation(1)));

            // Act.
            _modifierService.PerformQuery(query);
            // Assert.
            query.Value.Should().Be(1);
        }

        [Test]
        public void WhenCleanUp_AndModifiersExist_ThenModifiersShouldBeCleared()
        {
            // Arrange.

            // Act.
            _modifierService.AddModifier(Create.Modifier());
            _modifierService.CleanUp();

            // Assert.
            _modifierService.Modifiers.Count.Should().Be(0);
        }

        [Test]
        public void WhenPerformQuery_AndNoMatchingModifiersExist_ThenQueryValueShouldNotChange()
        {
            // Arrange.
            var @default = 0f;
            var query = new Query(StatType.Attack, @default);

            _modifierService.AddModifier(Create.Modifier(StatType.ShotCount, new AddOperation(1)));

            // Act.
            _modifierService.PerformQuery(query);

            // Assert.
            query.Value.Should().Be(@default);
        }



    }
}