using CodeBase.StaticData.Weapon;
using CodeBase.Weapons.Modifiers;
using CodeBase.Weapons.Sounds;
using UnityEngine;

namespace CodeBase.Weapons.AttackBehaviour
{
    public class RaycastAttack : AttackBehaviour
    {
        private readonly WeaponParticleService _particleService;
        private readonly WeaponSounds _weaponSounds;
        private float _lastAttackTime;

        public RaycastAttack(Transform attackStartPoint, WeaponAttackData attackData, WeaponParticleService particleService, WeaponSounds weaponSounds, ModifiersService modifiersMediator) :
            base(attackStartPoint, attackData, modifiersMediator)
        {
            _particleService = particleService;
            _weaponSounds = weaponSounds;
        }

        public override void Attack()
        {
            if (Time.time > _attackData.FireRate + _lastAttackTime)
            {
                _lastAttackTime = Time.time;
                for (var i = 0; i < _attackData.ShotCount; i++)
                {
                    _particleService.PlayMuzzleFlash();
                    _weaponSounds.Play(WeaponSoundType.Fire);
                    _particleService.SpawnCasing();
                    Raycast();
                }
            }
        }

        private void Raycast()
        {
            var direction = _attackData.BaseData.IsUseSpread ? _attackStartPoint.forward + CalculateSpread() : _attackStartPoint.forward;
            var ray = new Ray(_attackStartPoint.position, direction);

            if (Physics.Raycast(ray, out var hitIInfo, _attackData.EffectiveDistance, _attackData.BaseData.LayerMask))
            {
                var hitCollider = hitIInfo.collider;
                if (hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_attackData.Damage);
                }

                _particleService.DrawTrail(ray.origin, hitIInfo.point);
                _particleService.SpawnEffectOnHit(hitIInfo);
                _weaponSounds.Play(WeaponSoundType.Hit);
            }
            else
            {
                _particleService.DrawTrail(_attackStartPoint.position, direction * _attackData.EffectiveDistance);
            }
        }

        private Vector3 CalculateSpread() => new Vector3
        {
            x = Random.Range(-_attackData.SpreadFactor, _attackData.SpreadFactor),
            //y = Random.Range(-_attackData.SpreadFactor, _attackData.SpreadFactor),
            //z = Random.Range(-_attackData.SpreadFactor, _attackData.SpreadFactor),
        };

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            var ray = new Ray(_attackStartPoint.position, _attackStartPoint.forward);

            if (Physics.Raycast(ray, out var hitIInfo, _attackData.EffectiveDistance, _attackData.BaseData.LayerMask))
                DrawRay(ray, hitIInfo.point, hitIInfo.distance, Color.red);
            else
            {
                var hitPosition = ray.origin + ray.direction * _attackData.EffectiveDistance;

                DrawRay(ray, hitPosition, _attackData.EffectiveDistance, Color.green);
            }
        }

        private void DrawRay(Ray ray, Vector3 point, float distance, Color color)
        {
            const float hitPointRadius = 0.15f;

            Debug.DrawRay(ray.origin, ray.direction * distance, color);

            Gizmos.color = color;
            Gizmos.DrawSphere(point, hitPointRadius);
        }
#endif
    }
}
