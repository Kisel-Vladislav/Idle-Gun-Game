using UnityEngine;

namespace CodeBase.StaticData.Enemy
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/👿 Enemy/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId Id;
        public GameObject Prefab;
        public float MoveSpeed;
        public float MaxHealth;
        public int ExperienceReward;

        public EnemyAttackType AttackType;
        public EnemyExploreAttackData ExploreAttackData;
        public EnemyOverlapAttackData OverlapAttackData;
    }
}