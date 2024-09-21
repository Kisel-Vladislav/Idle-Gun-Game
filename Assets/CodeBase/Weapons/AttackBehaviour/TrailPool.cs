using CodeBase.StaticData.Weapon;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace CodeBase.Weapons.AttackBehaviour
{
    public class TrailPool
    {
        private readonly TrailData _trailData;
        private readonly ObjectPool<TrailRenderer> _trailPool;
        public TrailPool(TrailData trailData)
        {
            _trailData = trailData;
            _trailPool = new ObjectPool<TrailRenderer>(CreateTrail);
        }
        public IEnumerator PlayTrail(Vector3 start, Vector3 end)
        {
            var instance = _trailPool.Get();
            instance.gameObject.SetActive(true);
            instance.transform.position = start;
            yield return null;

            instance.emitting = true;

            float distance = Vector3.Distance(start, end);
            float remainingDistance = distance;
            while (remainingDistance > 0)
            {
                instance.transform.position = Vector3.Lerp(
                    start,
                    end,
                    Mathf.Clamp01(1 - (remainingDistance / distance))
                );
                remainingDistance -= _trailData.SimulationSpeed * Time.deltaTime;

                yield return null;
            }

            instance.transform.position = end;

            yield return new WaitForSeconds(_trailData.Duration);
            yield return null;
            instance.emitting = false;
            instance.gameObject.SetActive(false);
            _trailPool.Release(instance);
        }
        private TrailRenderer CreateTrail()
        {
            var instance = new GameObject();
            TrailRenderer trail = instance.AddComponent<TrailRenderer>();
            trail.colorGradient = _trailData.Color;
            trail.material = _trailData.Material;
            trail.widthCurve = _trailData.AnimationCurve;
            trail.time = _trailData.Duration;
            trail.minVertexDistance = _trailData.MinVertexDistance;
            trail.emitting = true;
            trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            return trail;
        }
    }
}