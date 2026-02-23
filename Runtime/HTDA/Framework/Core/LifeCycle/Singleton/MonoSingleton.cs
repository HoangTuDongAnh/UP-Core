using UnityEngine;

namespace HTDA.Framework.Core.LifeCycle
{
    /// <summary>
    /// Minimal MonoBehaviour singleton.
    /// - Auto creates GameObject if not found.
    /// - Destroys duplicates.
    /// </summary>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        private static readonly object _lock = new object();
        private static bool _quitting;

        public static T Instance
        {
            get
            {
                if (_quitting) return null;
                if (_instance != null) return _instance;

                lock (_lock)
                {
                    if (_instance != null) return _instance;

                    _instance = FindFirstObjectByType<T>();
                    if (_instance != null) return _instance;

                    var go = new GameObject($"[{typeof(T).Name}]");
                    _instance = go.AddComponent<T>();
                    return _instance;
                }
            }
        }

        public static bool HasInstance => _instance != null && !_quitting;

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
                OnSingletonAwake();
                return;
            }

            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnApplicationQuit()
        {
            _quitting = true;
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
                _instance = null;
        }

        /// <summary>
        /// Hook for derived class init. Called on the first instance in Awake().
        /// </summary>
        protected virtual void OnSingletonAwake() { }
    }
}