using System.Collections.Generic;

namespace HTDA.Framework.Core.Primitives
{
    public sealed class DecoratorChain<T>
    {
        private readonly List<IDecorator<T>> _items;

        public DecoratorChain(int capacity = 4)
        {
            _items = new List<IDecorator<T>>(capacity);
        }

        public DecoratorChain<T> Add(IDecorator<T> decorator)
        {
            if (decorator != null) _items.Add(decorator);
            return this;
        }

        public bool Remove(IDecorator<T> decorator) => _items.Remove(decorator);

        public T Apply(T input)
        {
            var value = input;
            for (int i = 0; i < _items.Count; i++)
                value = _items[i].Apply(value);
            return value;
        }

        public void Clear() => _items.Clear();
    }
}