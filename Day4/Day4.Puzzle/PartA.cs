using Common;

namespace Day4.Puzzle;

public class PartA : IPuzzle
{
	private readonly string input;

	int IPuzzle.Day => 4;
	string IPuzzle.Part => "A";

	public PartA(string input) => this.input = input;

	public string Solve()
	{
		var cards = Parser.Parse(input);
		var points = cards.Select(x => x.CalculatePoints()).Sum();

		return points.ToString();
	}
}