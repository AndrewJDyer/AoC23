using Common;

namespace Day1.Puzzle;

public class PartB : IPuzzle
{
	private readonly string input;

	public int Day => 1;

	public string Part => "B";

	public PartB(string input) => this.input = input;

	public string Solve()
	{
		var lines = input.Split(Environment.NewLine).Select(x => new LineB(x));
		return lines.Sum(x => x.GetCalibrationValue()).ToString();
	}
}
