namespace HTDA.Framework.Core.Primitives
{
    public interface IStrategy<in TContext, out TResult>
    {
        TResult Execute(TContext context);
    }
}