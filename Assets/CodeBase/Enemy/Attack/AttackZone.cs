using UnityEngine;

namespace CodeBase.Enemy.Attack
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _attack;

        public void OnTriggerEnter(Collider other) => 
            _attack.Attack(other.transform);
    }
}