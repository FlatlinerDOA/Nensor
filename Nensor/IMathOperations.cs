using System.Linq.Expressions;
using System.Numerics;

namespace Nensor;

public enum UnaryOps
{
	NoOp,
	Exp2,
	Log2,
	Cast,
	Sin,
	Sqrt,
	Recip,
	Neg,
}

/// <summary>
/// Operations that take two inputs and return an output: f(a, b) => c
/// </summary>
public enum BinaryOps
{
	Add,
	Subtract,
	Multiply,
	Divide,
	Max,
	Mod,
	/// <summary>
	/// TODO: CMPLT = ComponentLessThan?
	/// </summary>
	/// <param name="source"></param>
	/// <param name="arg"></param>
	/// <returns></returns>
	ComponentLessThan,
}


public enum ReduceOps
{
	Sum,
	Max,
}

public enum TernaryOps
{
	MulAcc,
	Where,
}

public enum MovementOps
{
	Reshape,
	Permute,
	Expand,
	Pad,
	Shrink,
	Stride
}


public enum LoadOps
{
	Empty,
	Rand,
	Const,
	From,
	Contiguous,
	Custom,
}