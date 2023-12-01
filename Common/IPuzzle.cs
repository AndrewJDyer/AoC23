namespace Common;

public interface IPuzzle
{
	int Day { get; }
	string Part { get; }

	string Solve();
}