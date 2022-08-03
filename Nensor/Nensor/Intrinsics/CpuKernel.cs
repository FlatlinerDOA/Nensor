namespace Nensor.Intrinsics;

using System.Numerics;
using System.Runtime.InteropServices;

public static partial class Kernels<T>
{
    /* TODO: Research CUDA C++ binding?
    private sealed class CudaKernel : IMathOperations<T>
    {
        public bool IsSupported => false;

        public ReadOnlySpan<TResult> Add<TArg, TResult>(ReadOnlySpan<T> select, TArg arg)
        {
            throw new NotImplementedException();
        }
    }
    */
    public sealed class CpuKernel<T> : IMathOperations<T> where T : struct, INumber<T>
    {
        public bool IsSupported => true;

        public ReadOnlySpan<T> Add(ReadOnlySpan<T> source, T arg)
        {
            if (source.Length < 1) 
            {
                return default;
            }

            var x = new T[source.Length].AsSpan();
            var right = new Vector<T>(arg);
            for (var offset = 0; offset < source.Length; offset += Vector<T>.Count)
            {
                var subSlice = source.Slice(offset, Vector<T>.Count);
                var left = new Vector<T>(subSlice);
                Vector.Add(left, right).CopyTo(x.Slice(offset, Vector<T>.Count));
            }

            return x;
        }

        public ReadOnlySpan<T> Sum(ReadOnlySpan<T> source, T arg)
        {
            var left = new Vector<T>(source);
            return new T[] { Vector.Sum(left) };
        }
    }
}