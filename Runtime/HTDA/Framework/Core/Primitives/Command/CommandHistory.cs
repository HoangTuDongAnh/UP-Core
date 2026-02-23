using System.Collections.Generic;

namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Simple undo/redo history for ICommand.
    /// No allocations during Undo/Redo (except list growth).
    /// </summary>
    public sealed class CommandHistory
    {
        private readonly List<ICommand> _done;
        private int _cursor; // points to next redo index

        public int CountDone => _cursor;
        public int CountTotal => _done.Count;
        public int CountRedo => _done.Count - _cursor;

        public CommandHistory(int capacity = 64)
        {
            _done = new List<ICommand>(capacity);
            _cursor = 0;
        }

        public bool Do(ICommand cmd)
        {
            if (cmd == null) return false;
            if (!cmd.CanExecute()) return false;

            // If we undid some commands, clear redo tail
            if (_cursor < _done.Count)
                _done.RemoveRange(_cursor, _done.Count - _cursor);

            cmd.Execute();
            _done.Add(cmd);
            _cursor++;
            return true;
        }

        public bool Undo()
        {
            if (_cursor <= 0) return false;

            _cursor--;
            var cmd = _done[_cursor];
            cmd?.Undo();
            return true;
        }

        public bool Redo()
        {
            if (_cursor >= _done.Count) return false;

            var cmd = _done[_cursor];
            if (cmd == null) return false;
            if (!cmd.CanExecute()) return false;

            cmd.Execute();
            _cursor++;
            return true;
        }

        public void Clear()
        {
            _done.Clear();
            _cursor = 0;
        }
    }
}