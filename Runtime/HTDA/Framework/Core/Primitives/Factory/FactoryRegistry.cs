using System.Collections.Generic;

namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Map keys -> factories. Useful for spawning by id/type without switch-case.
    /// </summary>
    public sealed class FactoryRegistry<TKey, TProduct>
    {
        private readonly Dictionary<TKey, IFactory<TProduct>> _map;

        public FactoryRegistry(int capacity = 16, IEqualityComparer<TKey> comparer = null)
        {
            _map = comparer != null
                ? new Dictionary<TKey, IFactory<TProduct>>(capacity, comparer)
                : new Dictionary<TKey, IFactory<TProduct>>(capacity);
        }

        public void Register(TKey key, IFactory<TProduct> factory)
        {
            if (factory == null) return;
            _map[key] = factory;
        }

        public bool TryCreate(TKey key, out TProduct product)
        {
            if (_map.TryGetValue(key, out var factory) && factory != null)
            {
                product = factory.Create();
                return true;
            }

            product = default;
            return false;
        }

        public bool Remove(TKey key) => _map.Remove(key);

        public void Clear() => _map.Clear();
    }
}