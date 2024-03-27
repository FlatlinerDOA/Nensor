using System.Numerics;
using Nensor.Intrinsics;

namespace Nensor;

public abstract class Tensor
{
	internal Function _ctx; // grad

	public LazyBuffer Data { get; init; }

	public LazyBuffer LazyData { get; init; }

    public static bool NoGrad { get; set; }

	public bool IsTraining { get; internal set; } = false;

	public bool? RequiresGrad { get; set; }

	public static int GetRowMajorOffset(Index[] indexes, int[] shape)
	{
		var x = 0;
		for (int d = 0; d < shape.Length - 1; d++)
		{
			var axisSize = shape[d];
			var axisOffset = indexes[d].GetOffset(axisSize);
			x = x + (axisSize * axisOffset);
		}

		var lastDim = shape.Length - 1;
		return x + indexes[lastDim].GetOffset(shape[lastDim]);
	}

	public static int[] GetAddressFromOffset(int offset, int[] shape)
	{
		// TODO: Calculate
		var address = new int[shape.Length];
		for (int i = 0; i < shape.Length; i++)
		{
			address[i] = Math.DivRem(offset, shape[i], out var y);
		}

		return address;
	}

	public static Tensor<T> Constant<T>(T value, params int[] shape) where T : INumber<T>
	{
		return new Tensor<T>(new T[shape.Aggregate(1, (p, n) => p * n)], shape);
	}

	public static Tensor<T> Zeros<T>(params int[] shape) where T : INumber<T>
	{
		return new Tensor<T>(new T[shape.Aggregate(1, (p, n) => p * n)], shape);
	}

	// public static TensorOperation<int, int> Add(this Tensor<int>.Slices tensor, int constant)
	// {
	// 	return new TensorOperation<int, int>(tensor, Kernels<int>.Default.Add, constant);
	// }

	// public static TensorOperation<double, double> Add(this Tensor<double>.Slices tensor, double constant)
	// {
	// 	return new TensorOperation<double, double>(tensor, Kernels<double>.Default.Add, constant);
	// }

	// public static TensorOperation<Half, Half> Add(this Tensor<Half>.Slices tensor, Half constant)
	// {
	// 	return new TensorOperation<Half, Half>(tensor, Kernels<Half>.Default.Add, constant);
	// }
}

public sealed class Tensor<T> : Tensor where T : INumber<T>
{
	public Tensor(Memory<T> source, params int[] shape) : this(new LazyBuffer<T>(source, shape))
	{		
	}

	public Tensor(LazyBuffer<T> buffer, Device? device = null, bool? requiresGrad = null)
	{
		device ??= buffer.Device;
		base.Data = buffer;
		this.RequiresGrad = requiresGrad;
		base.LazyData = device == buffer.Device ? buffer : buffer.CopyToDevice(device);
	}

	public new LazyBuffer<T> Data => (LazyBuffer<T>)base.Data;

	public new LazyBuffer<T> LazyData => (LazyBuffer<T>)base.LazyData;

	public Device Device { get; } = Device.Default;

	public Slices this[params Range[] ranges] => throw new NotImplementedException();
	// ranges.Length > this.Shape.Length ?
	// 	throw new InvalidShapeException(nameof(ranges), this.shape.Length, ranges.Length) :
	// 	new Slices(this.shape, this.source.ToArray(), ranges);

	public T this[params Index[] indexes] => throw new NotImplementedException();
	//this.source.ToArray()[this.GetRowMajorOffset(indexes)];


	// public int GetRowMajorOffset(params Index[] indexes)
	// {
	// 	var x = 0;
	// 	for (int d = 0; d < this.shape.Length - 1; d++)
	// 	{
	// 		var axisSize = this.shape[d];
	// 		var axisOffset = indexes[d].GetOffset(axisSize);
	// 		x = x + (axisSize * axisOffset);
	// 	}

	// 	var lastDim = this.shape.Length - 1;
	// 	return x + indexes[lastDim].GetOffset(this.shape[lastDim]);
	// }

	// public int[] GetAddressFromOffset(int offset)
	// {
	// 	var address = new int[this.shape.Length];
	// 	for (int i = 0; i < this.shape.Length; i++)
	// 	{
	// 		address[i] = Math.DivRem(offset, this.shape[i], out var y);
	// 	}

	// 	return address;
	// }

	public T[] ToArray() => this.LazyData.Data.ToArray();

	// public Array ToMultiDimensionalArray()
	// {
	// 	var a = Array.CreateInstance(typeof(T), this.shape);
	// 	// TODO: Copy slices to array
	// 	return a;
	// }

	// public int[,] ToTwoDimensionalArray()
	// {
	// 	var a = Array.CreateInstance(typeof(T), this.shape);
	// 	// TODO: Copy slices to array
	// 	return (int[,])a;
	// }


	public sealed record class TrainScope : IDisposable
	{
		private readonly Tensor<T> tensor;
		private readonly bool wasTraining;
		public TrainScope(Tensor<T> tensor, bool isTraining = true)
		{
			this.tensor = tensor;
			this.wasTraining = this.tensor.IsTraining;
			this.tensor.IsTraining = isTraining;
		}

		public void Dispose()
		{
			this.tensor.IsTraining = this.wasTraining;
		}
	}
}