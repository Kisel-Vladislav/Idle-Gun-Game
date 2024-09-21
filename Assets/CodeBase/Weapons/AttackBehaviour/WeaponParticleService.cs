using CodeBase.Infrastructure;
using CodeBase.StaticData.Weapon;
using UnityEngine;

namespace CodeBase.Weapons.AttackBehaviour
{
    public class WeaponParticleService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ParticleData _particleData;
        private readonly ParticleSystem _particleSystem;
        private readonly TrailPool _trailFactory;
        private readonly CasingPool _casingFactory;
        private readonly ParticleService _particleService;

        public WeaponParticleService(ICoroutineRunner coroutineRunner, ParticleData particleData, ParticleSystem particleSystem, TrailPool trailFactory, CasingPool casingFactory)
        {
            _coroutineRunner = coroutineRunner;
            _particleData = particleData;
            _particleSystem = particleSystem;
            _trailFactory = trailFactory;
            _casingFactory = casingFactory;
        }
        public void DrawTrail(Vector3 start, Vector3 end) =>
            _coroutineRunner.StartCoroutine(_trailFactory.PlayTrail(start, end));
        public void SpawnCasing() =>
            _coroutineRunner.StartCoroutine(_casingFactory.Spawn());
        public void PlayMuzzleFlash() =>
            _particleSystem.Play();
        public void SpawnEffectOnHit(RaycastHit hit)
        {
            var position = hit.point;
            var rotation = Quaternion.LookRotation(hit.normal);
            Object.Instantiate(_particleData.EffectOnHit, position, rotation);
        }
    }

    public class ParticleService
    {
        public void SpawnEffect(GameObject FX, Vector3 position, Quaternion rotation) =>
            Object.Instantiate(FX, position, rotation);
        public void SpawnEffect(GameObject FX, Transform transform) =>
            Object.Instantiate(FX, transform);
    }
}