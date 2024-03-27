namespace Nensor;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

// public interface ICoordinateSystem<TDimensions>
// {
//     static abstract int Dimensions { get; }

//     static object NextRank() => throw new NotImplementedException();

//     static ICoordinateSystem<THigher> Broadcast<THigher>(ICoordinateSystem<TDimensions> self)
//         where THigher : ICoordinateSystem<THigher> => typeof(THigher) == typeof(ICoordinateSystem<TDimensions>) ? self : self.NextRank();
// }

// public class Rank1 : ICoordinateSystem<Rank1>, IAdditionOperators<Rank1, int, Rank2>
// {
//     public static int Dimensions => 1;
// }

// public class Rank2 : ICoordinateSystem<Rank1>
// {
//     public static int Dimensions => 2;
// }

// public struct Vector<TDimensions> : ICoordinateSystem<TDimensions>, INumber<Vector<TDimensions>>
// {
//     public static Vector<TDimensions> One => throw new NotImplementedException();

//     public static int Radix => throw new NotImplementedException();

//     public static Vector<TDimensions> Zero => throw new NotImplementedException();

//     public static Vector<TDimensions> AdditiveIdentity => One;

//     public static Vector<TDimensions> MultiplicativeIdentity => One;

//     int[] Address { get; }

//     public static Vector<TDimensions> Abs(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static ICoordinateSystem<TDimensions> Concat(ICoordinateSystem<TDimensions> self)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsCanonical(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsComplexNumber(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsEvenInteger(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsFinite(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsImaginaryNumber(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsInfinity(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsInteger(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsNaN(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsNegative(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsNegativeInfinity(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsNormal(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsOddInteger(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsPositive(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsPositiveInfinity(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsRealNumber(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsSubnormal(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool IsZero(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> MaxMagnitude(Vector<TDimensions> x, Vector<TDimensions> y)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> MaxMagnitudeNumber(Vector<TDimensions> x, Vector<TDimensions> y)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> MinMagnitude(Vector<TDimensions> x, Vector<TDimensions> y)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> MinMagnitudeNumber(Vector<TDimensions> x, Vector<TDimensions> y)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> Parse(string s, NumberStyles style, IFormatProvider? provider)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> Parse(string s, IFormatProvider? provider)
//     {
//         throw new NotImplementedException();
//     }

//     public static ICoordinateSystem<TDimensions> Slice(Vector<TDimensions> address)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Vector<TDimensions> result)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out Vector<TDimensions> result)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Vector<TDimensions> result)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Vector<TDimensions> result)
//     {
//         throw new NotImplementedException();
//     }

//     public int CompareTo(object? obj)
//     {
//         throw new NotImplementedException();
//     }

//     public int CompareTo(Vector<TDimensions> other)
//     {
//         throw new NotImplementedException();
//     }

//     public bool Equals(Vector<TDimensions> other)
//     {
//         throw new NotImplementedException();
//     }

//     public string ToString(string? format, IFormatProvider? formatProvider)
//     {
//         throw new NotImplementedException();
//     }

//     public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator +(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator +(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator -(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator -(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator ++(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator --(Vector<TDimensions> value)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator *(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator /(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static Vector<TDimensions> operator %(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool operator ==(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool operator !=(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool operator <(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool operator >(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool operator <=(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }

//     public static bool operator >=(Vector<TDimensions> left, Vector<TDimensions> right)
//     {
//         throw new NotImplementedException();
//     }
// }

// public struct Slice<TDimensions>
// {
//     public Vector<TDimensions> Start { get; init; }

//     public Vector<TDimensions> End { get; }

//     public Vector<TDimensions> Stride { get; }
// }

// public interface ITensor<TDimensions, TValue>
//     where TDimensions : ICoordinateSystem<TDimensions>
//     where TValue : INumber<TValue>
// {
//     TValue this[Vector<TDimensions> x] { get; }

//     ITensor<TDimensions, TValue> this[Slice<TDimensions> x] { get; }
// }