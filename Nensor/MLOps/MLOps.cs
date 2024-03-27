using System.Numerics;

namespace Nensor.MLOps;

public sealed class Zero<T> : Function where T : INumber<T>
{
    public Zero(Device device, params Tensor<T>[] tensors) : base(device, tensors)
    {
    }

    public override LazyBuffer Forward(params LazyBuffer[] srcs) => this.Forward(srcs[0] is LazyBuffer<T> x ? x : srcs[0].Cast<T>());

    public override LazyBuffer Backward(params LazyBuffer[] srcs)=> this.Backward(srcs[0] is LazyBuffer<T> x ? x : srcs[0].Cast<T>());

    public LazyBuffer<T> Forward(LazyBuffer<T> x) => x.Const(T.Zero);

    public LazyBuffer<T> Backward(LazyBuffer<T> grad) => grad.Const(T.Zero);
}
