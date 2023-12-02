using Common;

namespace Day2.Puzzle;

public class PartA : IPuzzle
{
	private readonly string input;

	int IPuzzle.Day => 2;
	string IPuzzle.Part => "A";

	public PartA(string input) => this.input = input;

	public string Solve()
	{
		var games = new Parser(input).Parse();
		var actualBag = new CubeCollection(Green: 13, Blue: 14, Red: 12);
		var possibleGames = games.Where(g => g.IsPossible(actualBag));

		return possibleGames.Sum(x => x.Id).ToString();
	}
}