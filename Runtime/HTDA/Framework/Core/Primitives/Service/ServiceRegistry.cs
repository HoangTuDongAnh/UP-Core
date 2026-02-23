using System;
using System.Collections.Generic;

namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Minimal type-based service registry (Service Locator).
    /// - O(1) get by type
    /// - No reflection scanning
    /// - No lifecycle opinions (you can build on top)
    /// </summary>
    public sealed class ServiceRegistry
    {
        private readonly Dictionary<Type, object> _map;

        public ServiceRegistry(int capacity = 16)
        {
            _map = new Dictionary<Type, object>(capacity);
        }

        public void Register<T>(T instance) where T : class
        {
            if (instance == null) return;
            _map[typeof(T)] = instance;
        }

        public bool Unregister<T>() where T : class
        {
            return _map.Remove(typeof(T));
        }

        public T Get<T>() where T : class
        {
            return _map.TryGetValue(typeof(T), out var obj) ? (T)obj : null;
        }

        public bool TryGet<T>(out T instance) where T : class
        {
            instance = Get<T>();
            return instance != null;
        }

        public void Clear() => _map.Clear();
    }
}