namespace Nensor;

public record Device(string Name)
{
	public static readonly Device Default = new("CPU");

	public static implicit operator Device(string device) => new(device ?? Default);

	public static implicit operator string(Device device) => device.Name;
}