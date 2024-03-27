namespace Nensor;


public record class DType(int Priority, int ItemSize, string Name, Type Type, int Size = 1)
{
    private static readonly DType Unsupported = new DType(0, 1, "<unsupported>", typeof(object));
    public static readonly DType Bool = new DType(0, 1, "bool", typeof(bool));
    public static readonly DType Float16 = new DType(9, 2, "half", typeof(Half));
    public static readonly DType Half = Float16;
    public static readonly DType Float32 = new DType(10, 4, "float", typeof(float));
    public static readonly DType Float = Float32;
    public static readonly DType Float64 = new DType(11, 8, "double", typeof(double));
    public static readonly DType Double = Float64;
    public static readonly DType Int8 = new DType(1, 1, "char", typeof(sbyte));
    public static readonly DType Int16 = new DType(3, 2, "short", typeof(short));
    public static readonly DType Int32 = new DType(5, 4, "int", typeof(int));
    public static readonly DType Int64 = new DType(7, 8, "long", typeof(long));
    public static readonly DType UInt8 = new DType(2, 1, "unsigned char", typeof(byte));
    public static readonly DType UInt16 = new DType(4, 2, "unsigned short", typeof(ushort));
    public static readonly DType UInt32 = new DType(6, 4, "unsigned int", typeof(uint));
    public static readonly DType UInt64 = new DType(8, 8, "unsigned long", typeof(ulong));
    public static readonly DType BFloat16 = new DType(9, 2, "__bf16", typeof(float));    
    public static readonly IReadOnlyList<DType> FloatTypes = new[] { DType.Float16, DType.Float32, DType.Float64 };
    public static readonly IReadOnlyList<DType> IntTypes = new[] { DType.Int8, DType.Int16, DType.Int32, DType.Int64, DType.UInt8, DType.UInt16, DType.UInt32, DType.UInt64 };
    public static readonly Dictionary<Type, DType> TypeMap = new[] { Bool }.Concat(FloatTypes).Concat(IntTypes).ToDictionary(t => t.Type);    

    public static DType FromType<T>() => typeof(T);
    
    public bool IsInt => DType.IntTypes.Contains(this);
    public bool IsFloat => DType.IntTypes.Contains(this);

    public override string ToString() => $"dtype.{this.Name}";
        
    public static implicit operator DType(Type type) => TypeMap.GetValueOrDefault(type, DType.Unsupported);

    public static implicit operator Type(DType type) => type.Type;
}