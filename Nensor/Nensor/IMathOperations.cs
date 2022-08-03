using System.Numerics;

namespace Nensor
{
    public interface IMathOperations<T> : IKernel
		 where T : struct, INumber<T>
	{
		ReadOnlySpan<T> Add(ReadOnlySpan<T> source, T arg);

		ReadOnlySpan<T> Sum(ReadOnlySpan<T> source, T arg);
	}
}