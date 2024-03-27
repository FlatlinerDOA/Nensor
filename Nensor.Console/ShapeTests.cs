using Nensor;

namespace Nensor;

public static class ShapeTests
{
    public static bool Array1dConstruction()
    {
        var array1d = new int[]
        {
            0,   1,  2,  3,  4
        };

        var tensor1d = new Tensor<int>(array1d, 1, 3);
        return tensor1d.Data.Realized.ToArray().SequenceEqual(new[] { 1, 2, 3 });
    }

    public static bool Array2dConstruction()
    {
        var array2d = new int[]
        {
			0,   1,  2,  3,  4,
			5,   6,  7,  8,  9,
			10, 11, 12, 13, 14
        };
        var tensor2d = new Tensor<int>(array2d, 5, 3);
        ///tensor2d.GetRowMajorOffset(2, 4).Dump();
        return tensor2d[2, 4].Dump("tensor2d [2, 4], should be 14") == 14;
    }

    public static bool Array3dConstruction()
    {
        var array3d = new int[]
        {
			0,   1,  2,  3,  4,
			5,   6,  7,  8,  9,
			10, 11, 12, 13, 14,

			15, 16, 17, 18, 19,
			20, 21, 22, 23, 24,
			25, 26, 27, 28, 29
        };

        var tensor3d = new Tensor<int>(array3d, 5, 3, 2);
        return tensor3d[4, 1, 2].Dump("tensor3d [4, 1, 2], should be 23") == 23;
    }

    public static bool Array4dConstruction()
    {
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
        
        var tensor4d = new Tensor<int>(array4d, 5, 3, 2, 2);        
        return tensor4d[3, 2, 1, 1].Dump("tensor4d [3, 2, 1, 1], should be 53") == 53;
    }
}