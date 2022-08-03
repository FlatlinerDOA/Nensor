namespace Nensor
{
    public interface IConversionOperations<T, TResult> : IKernel
	{
		ReadOnlySpan<TResult> Add<TArg>(ReadOnlySpan<T> select, TArg arg);

		ReadOnlySpan<TResult> Sum<TArg>(ReadOnlySpan<T> select, TArg arg);
	}
}