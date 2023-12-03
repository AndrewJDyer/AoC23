using Common;

namespace Day3.Puzzle;

public class PartA : IPuzzle
{
	private readonly string input;

	int IPuzzle.Day => 3;
	string IPuzzle.Part => "A";

	public PartA(string input) => this.input = input;

	public string Solve()
	{
		var schematic = Parser.Parse(input);
		return schematic.SumTruePartNumbers().ToString();
	}
}