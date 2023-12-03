using Day3.Puzzle;

namespace Day3.Test;

public class PartBTest
{
	private const string ExampleInput = """
		467..114..
		...*......
		..35..633.
		......#...
		617*......
		.....+.58.
		..592.....
		......755.
		...$.*....
		.664.598..
		""";

	[TestCase(ExampleInput, ExpectedResult = "467835")]
	public string Solve(string input) => new PartB(input).Solve();
}
