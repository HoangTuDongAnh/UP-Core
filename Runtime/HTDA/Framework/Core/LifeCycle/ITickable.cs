namespace HTDA.Framework.Core.Lifecycle
{
    /// <summary>
    /// Optional contract for update-driven systems.
    /// Keep minimal (no Unity dependency).
    /// </summary>
    public interface ITickable
    {
        void Tick(float deltaTime);
    }
}