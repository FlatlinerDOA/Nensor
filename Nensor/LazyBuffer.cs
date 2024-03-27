using System.Numerics;

namespace Nensor;

public sealed record class RawCPUBuffer<T>(Memory<T> ToCPU); // ToCPU redundant?

/// <summary>
/// Our version of np.view ... this is going to be painful to implement.
/// </summary>
public sealed record class Slices
{
    private readonly ReadOnlyMemory<Range> slices;

    private int[] sourceShape;

    public Slices(int[] sourceShape) 
    {
        this.sourceShape = sourceShape;
        this.slices = sourceShape.Select(_ => Range.All).ToArray();
    }

    public Slices(int[] sourceShape, ReadOnlyMemory<Range> slices)
    {
        this.sourceShape = sourceShape;
        this.slices = slices;
    }

    // // Needed to be compatible with the foreach operator
    // public Slices GetEnumerator() => this;

    // public bool MoveNext()
    // {
    // 	// Reach the end of the shape
    // 	if (this.slices.Length == 0 || index >= this.slices.Length)
    // 	{
    // 		return false;
    // 	}

    // 	var (offset, length) = this.slices.Span[index].GetOffsetAndLength(this.source.Length);
    // 	this.Current = this.source.Slice(offset, length);
    // 	index++;
    // 	return true;
    // }

    public int[] SourceShape => this.sourceShape;


    // TODO: Views of a buffer
    // public T[] ViewOf<T>(Memory<T> memory)
    // {
    // 	var size = Tensor.GetRowMajorOffset(this.slices.ToArray().Select(r => r.End).ToArray(), this.sourceDims);
    // 	Memory<T> a = new T[size];
    // 	var i = 0;
    // 	while (this.MoveNext() && i < a.Length)
    // 	{
    // 		this.Current.CopyTo(a.Slice(i, this.Current.Length));
    // 		i += this.Current.Length;
    // 	}

    // 	return a.ToArray();
    // }
}

public abstract record class LazyBuffer(int[] Shape, DType DType, Slices View, Device Device)
{
    public virtual LazyBuffer<TResult> Cast<TResult>(bool bitcast = false) where TResult : INumber<TResult> => throw new NotImplementedException("Cast");
}

public sealed record class LazyBuffer<T>(Memory<T> Data, int[] Shape, Slices? View = null) : LazyBuffer(Shape, typeof(T), View ?? new(Shape), Device.Default)
    where T : INumber<T>
{
    public Memory<T> Realized => this.Data;

    public static LazyBuffer<T> FromCPU(Memory<T> data) => new LazyBuffer<T>(data, new[] { data.Length });

    public LazyBuffer<T> Contiguous(LazyBuffer<T> x) => x;
    
    public LazyBuffer<T> Const(T x) => throw new NotImplementedException("Const");

    public override LazyBuffer<TResult> Cast<TResult>(bool bitcast = false) =>
        this is LazyBuffer<TResult> correct ?
            correct :
            new LazyBuffer<TResult>(this.Data.ToArray().Cast<TResult>().ToArray(), this.Shape, this.View); // IMPROVE: Double copy

    public LazyBuffer<T> CopyToDevice(Device device) => this;

    public override string ToString() => $"<LB {this.Shape} {this.DType}>";
}