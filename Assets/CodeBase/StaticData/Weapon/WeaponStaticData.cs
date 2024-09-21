using CodeBase.Weapons;
using CodeBase.Weapons.Sounds;
using System;
using UnityEngine;

namespace CodeBase.StaticData.Weapon
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "StaticData/Weapons")]
    public class WeaponStaticData : ScriptableObject
    {
        public WeaponTypeId Id;
        public GameObject Prefab;
        public BaseWeaponAttackData AttackData;
        public ParticleData ParticleData;
        public WeaponAudioData AudioData;
    }
    [Serializable]
    public class ParticleData
    {
        public GameObject EffectOnHit;
        public Vector3 CasingSpawnPosition;
        public TrailData TrailData;
        public CasingData CasingData;
    }
    [Serializable]
    public class TrailData
    {
        public Material Material;
        public AnimationCurve AnimationCurve;
        public float Duration;
        public float MinVertexDistance;
        public Gradient Color;
        public float MissDistance;
        public float SimulationSpeed;
    }
    [Serializable]
    public class BaseWeaponAttackData
    {
        public LayerMask LayerMask;
        [Min(0.1f)] public float Damage;
        [Min(0.1f)] public float EffectiveDistance;
        [Min(1f)] public int ShotCount;
        public float FireRate;
        public bool IsUseSpread;
        [Min(0f)] public float SpreadFactor;
    }
    [Serializable]
    public class CasingData
    {
        public GameObject CasingPrefab;

        public Vector3 MaxForge;
        public Vector3 MinForge;

        public float MaxRotation;
        public float MinRotation;
    }
    [Serializable]
    public class WeaponAudioData
    {
        public WeaponAudioInfo[] AudioClips;
    }
    [Serializable]
    public class WeaponAudioInfo
    {
        public WeaponSoundType SoundType;
        public AudioClip Clip;
    }

}