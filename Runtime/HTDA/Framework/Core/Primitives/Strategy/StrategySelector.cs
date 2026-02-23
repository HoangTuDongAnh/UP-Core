using System;
using System.Collections.Generic;

namespace HTDA.Framework.Core.Primitives
{
    public sealed class StrategySelector<TContext, TResult>
    {
        private readonly List<(Func<TContext, bool> when, IStrategy<TContext, TResult> strategy)> _items;

        public StrategySelector(int capacity = 4)
        {
            _items = new List<(Func<TContext, bool>, IStrategy<TContext, TResult>)>(capacity);
        }

        public StrategySelector<TContext, TResult> Add(Func<TContext, bool> when, IStrategy<TContext, TResult> strategy)
        {
            if (when == null || strategy == null) return this;
            _items.Add((when, strategy));
            return this;
        }

        public bool TryExecute(TContext context, out TResult result)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var (when, strategy) = _items[i];
                if (when(context))
                {
                    result = strategy.Execute(context);
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}