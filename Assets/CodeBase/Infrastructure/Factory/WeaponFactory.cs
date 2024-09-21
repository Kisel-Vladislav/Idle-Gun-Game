using CodeBase.Infrastructure.Services.Audio;
using CodeBase.StaticData;
using CodeBase.StaticData.Weapon;
using CodeBase.Weapons;
using CodeBase.Weapons.AttackBehaviour;
using CodeBase.Weapons.Modifiers;
using CodeBase.Weapons.Sounds;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class WeaponFactory
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IStaticDataService _staticData;
        private readonly IAudioService _audioService;
        private readonly ModifiersService _modifiersMediator;

        public WeaponFactory(ICoroutineRunner coroutineRunner, IStaticDataService staticData, IAudioService audioService, ModifiersService modifiersMediator)
        {
            _coroutineRunner = coroutineRunner;
            _staticData = staticData;
            _modifiersMediator = modifiersMediator;
            _audioService = audioService;
        }

        public Weapon Create(WeaponTypeId id, Transform parent)
        {
            var weaponData = _staticData.ForWeapon(id);
            var weaponModel = Object.Instantiate(weaponData.Prefab, parent);

            var trailPool = InitTrailPool(weaponData);
            var casingPool = InitCasingPool(weaponData, weaponModel);
            var weapon = InitWeapon(weaponData, weaponModel, trailPool, casingPool);

            return weapon;
        }

        private TrailPool InitTrailPool(WeaponStaticData weaponData) => 
            new TrailPool(weaponData.ParticleData.TrailData);
        private CasingPool InitCasingPool(WeaponStaticData weaponData, GameObject weaponModel)
        {
            var casingParent = new GameObject("CasingPoint");
            casingParent.transform.position = weaponData.ParticleData.CasingSpawnPosition;
            casingParent.transform.SetParent(weaponModel.transform, false);

            return new CasingPool(weaponData.ParticleData.CasingData, casingParent.transform);
        }
        private Weapon InitWeapon(WeaponStaticData weaponData, GameObject weaponModel, TrailPool trailFactory, CasingPool casingFactory)
        {
            var particleSystem = weaponModel.GetComponentInChildren<ParticleSystem>();
            var particleService = new WeaponParticleService(_coroutineRunner, weaponData.ParticleData, particleSystem, trailFactory, casingFactory);

            var weaponSounds = new WeaponSounds(weaponData.AudioData, _audioService);

            var attackData = new WeaponAttackData(_modifiersMediator, weaponData.AttackData);
            var attackBehaviour = new RaycastAttack(particleSystem.transform, attackData, particleService, weaponSounds, _modifiersMediator);

            return new Weapon(attackBehaviour);
        }
    }
}

