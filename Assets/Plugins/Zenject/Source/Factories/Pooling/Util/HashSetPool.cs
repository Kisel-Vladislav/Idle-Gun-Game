using ModestTree;
using System.Collections.Generic;

namespace Zenject
{
    public class HashSetPool<T> : StaticMemoryPool<HashSet<T>>
    {
        private static readonly HashSetPool<T> _instance = new HashSetPool<T>();

        public HashSetPool()
        {
            OnSpawnMethod = OnSpawned;
            OnDespawnedMethod = OnDespawned;
        }

        public static HashSetPool<T> Instance
        {
            get { return _instance; }
        }

        private static void OnSpawned(HashSet<T> items)
        {
            Assert.That(items.IsEmpty());
        }

        private static void OnDespawned(HashSet<T> items)
        {
            items.Clear();
        }
    }
}
