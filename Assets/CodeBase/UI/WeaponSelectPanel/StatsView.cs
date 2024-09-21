using CodeBase.StaticData.Weapon;
using CodeBase.UI.Bar;
using UnityEngine;

namespace CodeBase.UI.WeaponSelectPanel
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private SegmentedProgressBar _damage;
        [SerializeField] private SegmentedProgressBar _fireRate;
        [SerializeField] private SegmentedProgressBar _spread;
        [SerializeField] private SegmentedProgressBar _shootCount;
        [SerializeField] private SegmentedProgressBar _range;

        // TO DOO
        private readonly float maxDamage = 100;
        private readonly float maxFireRate = 1.5f;
        private readonly float maxSpread = 0.3f;
        private readonly float maxEffectiveDistance = 100;
        private readonly float maxShootCount = 10;

        public void Fill(BaseWeaponAttackData weaponAttackData)
        {
            _damage.SetValue(weaponAttackData.Damage, maxDamage);
            _fireRate.SetValue(weaponAttackData.FireRate, maxFireRate);

            _spread.SetValue(weaponAttackData.SpreadFactor, maxSpread);

            _shootCount.SetValue(weaponAttackData.ShotCount, maxShootCount);
            _range.SetValue(weaponAttackData.EffectiveDistance, maxEffectiveDistance);
        }

    }
}