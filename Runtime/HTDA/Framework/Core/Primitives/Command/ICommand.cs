namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Minimal command for gameplay actions.
    /// Use for puzzle moves, undo/redo, replay.
    /// </summary>
    public interface ICommand
    {
        bool CanExecute();
        void Execute();

        /// <summary>
        /// If not supported, implement as empty.
        /// </summary>
        void Undo();
    }
}