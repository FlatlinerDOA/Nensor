namespace Nensor
{
    public sealed class InvalidShapeException : ArgumentOutOfRangeException
	{
		public InvalidShapeException(string parameterName, int expectedShape, int providedShape) : base(parameterName, $"Invalid shape expected {expectedShape} got {providedShape}")
		{
		}
	}
}