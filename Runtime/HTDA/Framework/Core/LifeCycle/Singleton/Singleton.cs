using System;

namespace HTDA.Framework.Core.LifeCycle
{
    /// <summary>
    /// Minimal, thread-safe lazy singleton for pure C# services.
    /// Prefer using this for non-Mono services (Save, Config, etc.)
    /// </summary>
    public abstract class Singleton<T> where T : class
    {
        private static readonly object _lock = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_lock)
                {
                    if (_instance != null) return _instance;
                    _instance = CreateInstance();
                    return _instance;
                }
            }
        }

        public static bool HasInstance => _instance != null;

        /// <summary>
        /// Manually set instance (optional). Useful for tests or bootstrap override.
        /// </summary>
        public static void SetInstance(T instance)
        {
            lock (_lock) { _instance = instance; }
        }

        /// <summary>
        /// Clear singleton instance (optional). Useful for tests.
        /// </summary>
        public static void Clear()
        {
            lock (_lock) { _instance = null; }
        }

        protected static T CreateInstance()
        {
            // Require derived class to expose parameterless ctor by default.
            // If you want custom creation, override Create().
            if (_instance is null)
            {
                var created = Create();
                if (created == null)
                    throw new InvalidOperationException($"Singleton<{typeof(T).Name}> Create() returned null.");
                return created;
            }
            return _instance;
        }

        /// <summary>
        /// Override this in derived class if you need custom construction.
        /// Default uses Activator (requires public parameterless ctor).
        /// </summary>
        protected static T Create()
        {
            return Activator.CreateInstance(typeof(T), nonPublic: true) as T;
        }
    }
}