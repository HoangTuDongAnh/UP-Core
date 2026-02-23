using UnityEngine;

namespace HTDA.Framework.Core.LifeCycle
{
    /// <summary>
    /// Mono singleton that persists across scenes (DontDestroyOnLoad).
    /// </summary>
    public abstract class PersistentMonoSingleton<T> : MonoSingleton<T> where T : PersistentMonoSingleton<T>
    {
        protected override void Awake()
        {
            base.Awake();
            if (Instance == this)
                DontDestroyOnLoad(gameObject);
        }
    }
}