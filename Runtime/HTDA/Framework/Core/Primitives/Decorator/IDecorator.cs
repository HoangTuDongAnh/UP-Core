namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Applies a modification to an input and returns output.
    /// Useful for modifier chains (score/damage/etc).
    /// </summary>
    public interface IDecorator<T>
    {
        T Apply(T input);
    }
}