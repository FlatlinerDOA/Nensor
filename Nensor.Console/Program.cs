using Nensor;

var array1d = new int[]
{
	0,   1,  2,  3,  4
};

var array2d = new int[]
{
	0,   1,  2,  3,  4,
	5,   6,  7,  8,  9,
	10, 11, 12, 13, 14
};

var array3d = new int[]
{
	0,   1,  2,  3,  4,
	5,   6,  7,  8,  9,
	10, 11, 12, 13, 14,

	15, 16, 17, 18, 19,
	20, 21, 22, 23, 24,
	25, 26, 27, 28, 29
};

var array4d = new int[]
{
	 0,  1,  2,  3,  4,   
	 5,  6,  7,  8,  9,   
	10, 11, 12, 13, 14,   
  
	15, 16, 17, 18, 19,   
	20, 21, 22, 23, 24,   
	25, 26, 27, 28, 29,

	    30, 31, 32, 33, 34,
	    35, 36, 37, 38, 39,
	    40, 41, 42, 43, 44,

	    45, 46, 47, 48, 49,
	    50, 51, 52, 53, 54,
	    55, 56, 57, 58, 59,
};

var tensor2d = new Tensor<int>(array2d, 5, 3);
var tensor3d = new Tensor<int>(array3d, 5, 3, 2);
var tensor4d = new Tensor<int>(array4d, 5, 3, 2, 2);
tensor2d.GetRowMajorOffset(2, 4).Dump();
tensor2d[2, 4].Dump("tensor2d [2, 4], should be 14");
tensor3d[4, 1, 2].Dump("tensor3d [4, 1, 2], should be 23");
tensor4d[3, 2, 1, 1].Dump("tensor3d [3, 2, 1, 1], should be 53");

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

		Console.WriteLine(value.ToString());
		return value;
    }
}