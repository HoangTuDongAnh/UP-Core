namespace HTDA.Framework.Core.Primitives
{
    public interface IFactory<in TIn, out TOut>
    {
        TOut Create(TIn input);
    }
}