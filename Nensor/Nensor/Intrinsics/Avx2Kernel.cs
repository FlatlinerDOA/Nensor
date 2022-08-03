namespace Nensor.Intrinsics;

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

public sealed class Avx2Kernel : IMathOperations<double>
{
    public bool IsSupported => Avx2.IsSupported;

    public unsafe ReadOnlySpan<double> Add(ReadOnlySpan<double> source, double arg)
    {
        if (source.Length < 1)
        {
            return default;
        }

        var x = new double[source.Length].AsSpan();
        var right = new Vector<double>(arg).AsVector256();
        for (var offset = 0; offset < source.Length; offset += 256)
        {
            var subSlice = source.Slice(offset, 256);
            fixed (double* r = subSlice) 
            {
                var left = Avx2.LoadVector256(r);
                Avx2.Add(left, right).CopyTo(x.Slice(offset));
            }
        }

        return x;
    }

    public ReadOnlySpan<double> Sum(ReadOnlySpan<double> source, double arg)
    {
        throw new NotImplementedException();
    }
}
