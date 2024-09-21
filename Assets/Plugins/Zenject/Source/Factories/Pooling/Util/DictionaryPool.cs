using ModestTree;
using System.Collections.Generic;

namespace Zenject
{
    public class DictionaryPool<TKey, TValue> : StaticMemoryPool<Dictionary<TKey, TValue>>
    {
        private static readonly DictionaryPool<TKey, TValue> _instance = new DictionaryPool<TKey, TValue>();

        public DictionaryPool()
        {
            OnSpawnMethod = OnSpawned;
            OnDespawnedMethod = OnDespawned;
        }

        public static DictionaryPool<TKey, TValue> Instance
        {
            get { return _instance; }
        }

        private static void OnSpawned(Dictionary<TKey, TValue> items)
        {
            Assert.That(items.IsEmpty());
        }

        private static void OnDespawned(Dictionary<TKey, TValue> items)
        {
            items.Clear();
        }
    }
}

