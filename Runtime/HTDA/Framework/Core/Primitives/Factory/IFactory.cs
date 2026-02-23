namespace HTDA.Framework.Core.Primitives
{
    public interface IFactory<out T>
    {
        T Create();
    }
}