namespace Nensor;

public delegate void Mutation<T, in TArg>(Span<T> select, TArg arg);

public ref struct TensorMutation<T, TArg>
{
	private readonly Tensor<T>.Slices source;

	private readonly TArg arg;

	private long applied = 0;

	private readonly Mutation<T, TArg> op;

	public TensorMutation(Tensor<T>.Slices source, Mutation<T, TArg> op, TArg arg)
	{
		this.source = source;
		this.op = op;
		this.arg = arg;
	}

	public void ApplyToSource()
	{
		if (Interlocked.CompareExchange(ref this.applied, 0, 1) == 1)
		{
			foreach (var s in this.source)
			{
				op(s, this.arg);
			}
		}
	}
}
