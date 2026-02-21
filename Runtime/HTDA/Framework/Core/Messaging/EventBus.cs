using System;
using System.Collections.Generic;

namespace HTDA.Framework.Core.Messaging
{
    /// <summary>
    /// Very small, type-based event bus.
    /// - No threading guarantees
    /// - No allocations per publish except delegate invocation (depends on usage)
    /// </summary>
    public sealed class EventBus : IEventBus
    {
        private readonly Dictionary<Type, Delegate> _map = new Dictionary<Type, Delegate>(64);

        public void Subscribe<T>(Action<T> handler)
        {
            if (handler == null) return;

            var type = typeof(T);
            if (_map.TryGetValue(type, out var existing))
                _map[type] = (Action<T>)existing + handler;
            else
                _map[type] = handler;
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            if (handler == null) return;

            var type = typeof(T);
            if (!_map.TryGetValue(type, out var existing)) return;

            var next = (Action<T>)existing - handler;
            if (next == null) _map.Remove(type);
            else _map[type] = next;
        }

        public void Publish<T>(T evt)
        {
            var type = typeof(T);
            if (_map.TryGetValue(type, out var existing))
            {
                var cb = (Action<T>)existing;
                cb.Invoke(evt);
            }
        }

        public void Clear() => _map.Clear();
    }
}