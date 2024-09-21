using CodeBase.StaticData.Weapon;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;


namespace CodeBase.Weapons
{
    public class CasingPool
    {
        private readonly CasingData _casingData;
        private readonly Transform _casingSpawnTransform;
        private readonly ObjectPool<Casing> _casingPool;

        private Vector3 SpawnPosition => _casingSpawnTransform.position;

        public CasingPool(CasingData casingData, Transform casingSpawnTransform)
        {
            _casingData = casingData;
            _casingSpawnTransform = casingSpawnTransform;
            _casingPool = new ObjectPool<Casing>(Create);
        }
        private class Casing
        {
            public GameObject GameObject;
            public Rigidbody Rigidbody;
        }

        public IEnumerator Spawn()
        {
            var instance = _casingPool.Get();

            instance.GameObject.transform.position = SpawnPosition;

            instance.GameObject.SetActive(true);

            var rigidbody = instance.Rigidbody;
            rigidbody.AddRelativeTorque(CalculateRotation());
            rigidbody.AddRelativeForce(CalculateForce());

            yield return new WaitForSeconds(5);
            instance.GameObject.SetActive(false);
            _casingPool.Release(instance);
        }

        private Casing Create()
        {
            var casing = new Casing();
            casing.GameObject = Object.Instantiate(_casingData.CasingPrefab, SpawnPosition, Quaternion.identity);
            casing.Rigidbody = casing.GameObject.GetComponent<Rigidbody>();
            return casing;
        }
        private Vector3 CalculateRotation()
        {
            return new Vector3
            {
                x = Random.Range(_casingData.MinRotation, _casingData.MaxRotation),
                y = Random.Range(_casingData.MinRotation, _casingData.MaxRotation),
                z = Random.Range(_casingData.MinRotation, _casingData.MaxRotation),
            };
        }
        private Vector3 CalculateForce()
        {
            return new Vector3
            {
                x = Random.Range(_casingData.MinForge.x, _casingData.MaxForge.x),
                y = Random.Range(_casingData.MinForge.y, _casingData.MaxForge.y),
                z = Random.Range(_casingData.MinForge.z, _casingData.MaxForge.z),
            };
        }
    }

}