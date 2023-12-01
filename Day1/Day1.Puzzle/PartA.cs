using Common;

namespace Day1.Puzzle;

public class PartA : IPuzzle
{
	private readonly string input;

	public int Day => 1;

	public string Part => "A";

	public PartA(string input) => this.input = input;

	public string Solve()
	{
		var lines = input.Split(Environment.NewLine).Select(x => new Line(x));
		return lines.Sum(x => x.GetCalibrationValue()).ToString();
	}
}