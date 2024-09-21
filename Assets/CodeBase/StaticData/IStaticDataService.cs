using CodeBase.StaticData.Enemy;
using CodeBase.StaticData.Weapon;
using CodeBase.StaticData.WeaponSelectPanel;
using CodeBase.Weapons;
using System.Collections.Generic;

namespace CodeBase.StaticData
{
    public interface IStaticDataService
    {
        void LoadWeapon();
        void LoadEnemy();
        void LoadEnemyWave();
        void LoadModifier();

        void LoadWeaponSelectItems();
        WeaponStaticData ForWeapon(WeaponTypeId id);
        EnemyStaticData ForEnemy(EnemyTypeId id);
        EnemyWaveData ForLevel(EnemyWaveTypeId id);

        IEnumerable<ModifierStaticData> ForModifiers(RarityType rarityType);
        List<WeaponSelectPanelItem> ForWeaponSelectPanelItems();
    }
}