using Common;

namespace Day2.Puzzle;

public class PartB : IPuzzle
{
	private readonly string input;

	int IPuzzle.Day => 2;
	string IPuzzle.Part => "B";

	public PartB(string input) => this.input = input;

	public string Solve()
	{
		var games = new Parser(input).Parse();
		return games.Sum(g => g.GetPower()).ToString();
	}
}
