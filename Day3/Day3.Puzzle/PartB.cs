using Common;

namespace Day3.Puzzle;

public class PartB : IPuzzle
{
	private readonly string input;

	int IPuzzle.Day => 3;
	string IPuzzle.Part => "B";

	public PartB(string input) => this.input = input;

	public string Solve()
	{
		var schematic = Parser.Parse(input);
		return schematic.SumGearRatios().ToString();
	}
}
