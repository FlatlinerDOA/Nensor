namespace Nensor;

public delegate ReadOnlySpan<TResult> CastOperator<T, in TArg, TResult>(ReadOnlySpan<T> select, TArg arg);

public ref struct TensorCastOperation<T, TArg, TResult>
{
	private readonly Tensor<T>.Slices source;
	private readonly CastOperator<T, TArg, TResult> select;
	private readonly TArg arg;

	public TensorCastOperation(Tensor<T>.Slices source, CastOperator<T, TArg, TResult> select, TArg arg)
	{
		this.source = source;
		this.select = select;
		this.arg = arg;
		this.Current = Array.Empty<TResult>();
	}

	// Needed to be compatible with the foreach operator
	public TensorCastOperation<T, TArg, TResult> GetEnumerator() => this;

	public bool MoveNext()
	{
		if (this.source.MoveNext())
		{
			this.Current = this.select(source.Current, this.arg);
			return true;
		}

		return false;
	}

	public ReadOnlySpan<TResult> Current { get; private set; }
}
