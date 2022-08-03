using Nensor.Intrinsics;

namespace Nensor;

public static class Tensor
{
	public static Tensor<T> Constant<T>(T value, params int[] dims)
	{
		return new Tensor<T>(new T[dims.Aggregate(1, (p, n) => p * n)], dims);
	}

	public static Tensor<T> Zeros<T>(params int[] dims)
	{
		return new Tensor<T>(new T[dims.Aggregate(1, (p, n) => p * n)], dims);
	}

	public static TensorOperation<int, int> Add(this Tensor<int>.Slices tensor, int constant)
	{
		return new TensorOperation<int, int>(tensor, Kernels<int>.Default.Add, constant);
	}

	public static TensorOperation<double, double> Add(this Tensor<double>.Slices tensor, double constant)
	{
		return new TensorOperation<double, double>(tensor, Kernels<double>.Default.Add, constant);
	}

	public static TensorOperation<Half, Half> Add(this Tensor<Half>.Slices tensor, Half constant)
	{
		return new TensorOperation<Half, Half>(tensor, Kernels<Half>.Default.Add, constant);
	}
}

public ref struct Tensor<T>
{
	private readonly Span<T> source;

	private readonly int[] dims;

	public Tensor(Span<T> source, params int[] dims)
	{
		this.source = source;
		this.dims = dims;
	}

	public Slices this[params Range[] ranges] => ranges.Length > this.dims.Length ?
		throw new InvalidDimensionsException(nameof(ranges), this.dims.Length, ranges.Length) :
		new Slices(this.dims, this.source, ranges);

	public T this[params Index[] indexes] => this.source[this.GetRowMajorOffset(indexes)];

	public int GetRowMajorOffset(params Index[] indexes)
	{
		var x = 0;
		for (int d = 0; d < this.dims.Length - 1; d++)
		{
			var axisSize = this.dims[d];
			var axisOffset = indexes[d].GetOffset(axisSize);
			x = x + (axisSize * axisOffset);
		}

		var lastDim = this.dims.Length - 1;
		return x + indexes[lastDim].GetOffset(this.dims[lastDim]);
	}

	public int[] GetAddressFromOffset(int offset)
	{
		var address = new int[this.dims.Length];
		for (int i = 0; i < this.dims.Length; i++)
		{
			address[i] = Math.DivRem(offset, this.dims[i], out var y);
		}

		return address;
	}

	public T[] ToArray() => this.source.ToArray();

	public Array ToMultiDimensionalArray()
	{
		var a = Array.CreateInstance(typeof(T), this.dims);
		// TODO: Copy slices to array
		return a;
	}

	public int[,] ToTwoDimensionalArray()
	{
		var a = Array.CreateInstance(typeof(T), this.dims);
		// TODO: Copy slices to array
		return (int[,])a;
	}

	// Must be a ref struct as it contains a ReadOnlySpan<T>
	public ref struct Slices
	{
		private Span<T> source;

		private ReadOnlySpan<Range> slices;
		private int[] sourceDims;
		private int index;

		public Slices(int[] sourceDims, Span<T> source, ReadOnlySpan<Range> slices)
		{
			this.sourceDims = sourceDims;
			this.source = source;
			this.slices = slices;
			this.Current = default;
			this.index = 0;
		}

		// Needed to be compatible with the foreach operator
		public Slices GetEnumerator() => this;

		public bool MoveNext()
		{
			// Reach the end of the string
			if (this.slices.Length == 0 || index >= this.slices.Length)
			{
				return false;
			}

			var (offset, length) = this.slices[index].GetOffsetAndLength(this.source.Length);
			this.Current = this.source.Slice(offset, length);
			index++;
			return true;
		}

		public Span<T> Source => this.source;

		public int[] SourceDimensions => this.sourceDims;

		public Span<T> Current { get; private set; }
	}
}