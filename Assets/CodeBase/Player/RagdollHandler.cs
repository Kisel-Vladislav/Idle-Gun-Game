using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Player
{
    public class RagdollHandler : MonoBehaviour
    {
        private List<Rigidbody> rigidbodies;
        private void Awake()
        {
            rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        }
        public void Enable()
        {
            foreach (var rigidbody in rigidbodies)
                rigidbody.isKinematic = false;
        }
    }
}
