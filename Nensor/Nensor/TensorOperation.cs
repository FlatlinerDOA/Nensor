namespace Nensor;

public delegate ReadOnlySpan<T> Operator<T, in TArg>(ReadOnlySpan<T> select, TArg arg);

public ref struct TensorOperation<T, TArg>
{
	private readonly Tensor<T>.Slices source;
	private readonly Operator<T, TArg> select;
	private readonly TArg arg;

	public TensorOperation(Tensor<T>.Slices source, Operator<T, TArg> select, TArg arg)
	{
		this.source = source;
		this.select = select;
		this.arg = arg;
		this.Current = Array.Empty<T>();
	}

	// Needed to be compatible with the foreach operator
	public TensorOperation<T, TArg> GetEnumerator() => this;

	public bool MoveNext()
	{
		if (this.source.MoveNext())
		{
			this.Current = this.select(source.Current, this.arg);
			return true;
		}

		return false;
	}

	public ReadOnlySpan<T> Current { get; private set; }

}

