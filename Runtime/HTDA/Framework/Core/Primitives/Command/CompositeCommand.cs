using System.Collections.Generic;

namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// A command that executes multiple commands in order and undoes in reverse order.
    /// </summary>
    public sealed class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _items;

        public CompositeCommand(int capacity = 4)
        {
            _items = new List<ICommand>(capacity);
        }

        public CompositeCommand Add(ICommand cmd)
        {
            if (cmd != null) _items.Add(cmd);
            return this;
        }

        public bool CanExecute()
        {
            for (int i = 0; i < _items.Count; i++)
                if (!_items[i].CanExecute())
                    return false;
            return true;
        }

        public void Execute()
        {
            for (int i = 0; i < _items.Count; i++)
                _items[i].Execute();
        }

        public void Undo()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
                _items[i].Undo();
        }
    }
}