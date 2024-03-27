
namespace Nensor.Intrinsics;

using System.Numerics;

// public static partial class Kernels<T> where T : struct, INumber<T>
// {
//     private static readonly IKernel[] Hardware = new IKernel[]
//     {
//         new Avx2Kernel(),
//         new AdvSimdDoubleKernel()
//     };

//     private static readonly IMathOperations<T> defaultKernel;

//     static Kernels()
//     {
//         defaultKernel = Hardware.OfType<IMathOperations<T>>().FirstOrDefault(k => k.IsSupported) ?? new CpuKernel<T>();
//     }

//     public static IMathOperations<T> Default => defaultKernel;
// }