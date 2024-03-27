using System.Collections;

namespace Nensor;

internal class Program
{   
    public static readonly Type[] TestClasses = new[]
    {
        typeof(ShapeTests)
    };

    public static IReadOnlyList<(string Name, bool Result)> RunTests() =>
        (from type in TestClasses
        from func in type.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
        select (func.Name, func.Invoke(null, null) is true)).ToList();
    private static void Main(string[] args)
    {
        RunTests().Dump();
    }
}

// TODO: Tensor.Add(tensor2d[.., ..], 10).Dump();

//return;
//var row1 = tensor2d[0..1, ..].Dump("Row1");
//var row2 = tensor2d[0..2, ..].Dump("Row2");
//var row3 = tensor2d[10..15].Dump("Row3");

//var all = x.AsSpan().Stride(5, 2);
//var result = all.Select((s, m) => s[0] + m, 10);
//all.ToArray().Dump();


//foreach (var xn in tensor2d[0..2, 5..6])
//{
//	xn.Dump();
//}

//Tensor.Zeros<int>(10, 10, 10, 10)[0..3].Dump();


public static class Utils
{
	public static T Dump<T>(this T value, string message = null)
    {
		if (message != null)
        {
			Console.WriteLine($"# {message}");
		}

		Console.WriteLine(value switch
        {
            IEnumerable x => string.Join("\n", x.Cast<object>().Select(t => t.ToString())),
            object x => x.ToString(),
            null => "(null)"
        });
		return value;
    }
}