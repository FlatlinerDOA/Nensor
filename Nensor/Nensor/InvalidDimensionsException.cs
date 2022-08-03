namespace Nensor
{
    public sealed class InvalidDimensionsException : ArgumentOutOfRangeException
	{
		public InvalidDimensionsException(string parameterName, int expectedDimensions, int providedDimensions) : base(parameterName, $"Invalid shape expected {expectedDimensions} got {providedDimensions}")
		{
		}
	}
}