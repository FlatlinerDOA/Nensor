using System.Numerics;

namespace Nensor;

public abstract class Function
{
    private readonly Tensor[] parents;
    
    protected Function(Device device, params Tensor[] tensors)
    {
        this.Device = device;
        this.parents = tensors;
    }
    
    public IEnumerable<bool?> NeedsInputGrad =>
        from t in this.parents
        select t.RequiresGrad;

    public Device Device { get; }

    public bool? RequiresGrad
    {
        get
        {
            if (this.NeedsInputGrad.Any(x => x == true)) // If any true
            {
                return true;
            }
            else if (this.NeedsInputGrad.Any(x => x is null)) // If any null and no true
            {
                return null;
            }

            return false;
        }
    }

    public virtual LazyBuffer Forward(params LazyBuffer[] srcs) => throw new NotImplementedException($"Forward not implemented for {this.GetType()}");
    
    public virtual LazyBuffer Backward(params LazyBuffer[] srcs) => throw new NotImplementedException($"Backward not implemented for {this.GetType()}");

    public Tensor<T> Apply<T>(params Tensor[] x) where T : INumber<T>
    {
        ////var ctx = Activator.CreateInstance(fxn, x[0].Device, x);
        var ret = new Tensor<T>((LazyBuffer<T>)this.Forward((from t in x select t.LazyData).ToArray()), this.Device, this.RequiresGrad);
        if (this.RequiresGrad is true && Tensor.NoGrad is not true)
        {
             ret._ctx = this; // used by autograd engine
        }

        return ret;
    }
}