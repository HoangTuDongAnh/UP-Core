using System;

namespace HTDA.Framework.Core.Messaging
{
    public interface IEventBus
    {
        void Subscribe<T>(Action<T> handler);
        void Unsubscribe<T>(Action<T> handler);
        void Publish<T>(T evt);
        void Clear();
    }
}