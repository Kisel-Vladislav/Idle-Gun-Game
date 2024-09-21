using CodeBase.Service;
using CodeBase.StaticData.Enemy;
using CodeBase.StaticData.Weapon;
using CodeBase.StaticData.WeaponSelectPanel;
using CodeBase.Weapons;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WeaponTypeId, WeaponStaticData> _weapons;
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;
        private Dictionary<EnemyWaveTypeId, EnemyWaveData> _waveEnemies;
        private Dictionary<RarityType, ModifierStaticData> _modifiers;

        private List<WeaponSelectPanelItem> _weaponPanelItems = new();

        public void LoadWeapon() =>
            _weapons = Resources.LoadAll<WeaponStaticData>("StaticData/Weapons")
                                .ToDictionary(x => x.Id, x => x);
        public void LoadEnemy() =>
            _enemies = Resources.LoadAll<EnemyStaticData>("StaticData/Enemies")
                                .ToDictionary(x => x.Id, x => x);
        public void LoadEnemyWave() =>
            _waveEnemies = Resources.LoadAll<EnemyWaveData>("StaticData/Enemies")
                                    .ToDictionary(x => x.Id, x => x);
        public void LoadModifier() =>
            _modifiers = Resources.LoadAll<ModifierStaticData>("StaticData/Modifiers")
                                  .ToDictionary(x => x.RarityType, x => x);

        public WeaponStaticData ForWeapon(WeaponTypeId id) =>
            _weapons.TryGetValue(id, out var weaponData) ? weaponData : null;
        public EnemyStaticData ForEnemy(EnemyTypeId id) =>
            _enemies.TryGetValue(id, out var enemyData) ? enemyData : null;
        public EnemyWaveData ForLevel(EnemyWaveTypeId id) =>
            _waveEnemies.TryGetValue(id, out var waveEnemyData) ? waveEnemyData : null;
        public IEnumerable<ModifierStaticData> ForModifiers(RarityType rarityType) =>
            _modifiers.Where(modifiers => modifiers.Key == rarityType)
                      .Select(modifiers => modifiers.Value);

        public List<WeaponSelectPanelItem> ForWeaponSelectPanelItems() =>
            _weaponPanelItems;
        public void LoadWeaponSelectItems() =>
            _weaponPanelItems = Resources.Load<WeaponSelectPanelContent>("StaticData/WeaponSelectPanel/WeaponSelectPanelContent").Items;

    }

    public enum EnemyWaveTypeId
    {
        All,
    }
}
