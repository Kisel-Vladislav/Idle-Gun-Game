using System.Collections.Generic;

namespace Zenject
{
    public class ListPool<T> : StaticMemoryPool<List<T>>
    {
        private static readonly ListPool<T> _instance = new ListPool<T>();

        public ListPool()
        {
            OnDespawnedMethod = OnDespawned;
        }

        public static ListPool<T> Instance
        {
            get { return _instance; }
        }

        private void OnDespawned(List<T> list)
        {
            list.Clear();
        }
    }
}
