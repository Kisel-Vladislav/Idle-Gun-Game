using CodeBase.Weapons.Modifiers;

namespace CodeBase.StaticData.Weapon
{
    public class WeaponAttackData
    {
        private readonly ModifiersService _modifiersMediator;
        private readonly BaseWeaponAttackData _baseData;

        public BaseWeaponAttackData BaseData => _baseData;
        public WeaponAttackData(ModifiersService modifiersMediator, BaseWeaponAttackData baseData)
        {
            _modifiersMediator = modifiersMediator;
            _baseData = baseData;
        }

        private float GetModifiedStat(StatType statType, float baseValue)
        {
            var query = new Query(statType, baseValue);
            _modifiersMediator.PerformQuery(query);
            return query.Value;
        }

        public float Damage => GetModifiedStat(StatType.Attack, BaseData.Damage);
        public float FireRate => GetModifiedStat(StatType.FireRate, BaseData.FireRate);
        public float EffectiveDistance => GetModifiedStat(StatType.EffectiveDistance, BaseData.EffectiveDistance);
        public float SpreadFactor => GetModifiedStat(StatType.SpreadFactor, BaseData.SpreadFactor);
        public int ShotCount => (int)GetModifiedStat(StatType.ShotCount, BaseData.ShotCount);

    }
}