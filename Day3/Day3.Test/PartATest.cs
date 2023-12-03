using Day3.Puzzle;

namespace Day3.Test;

public class PartATest
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

	[TestCase(ExampleInput, ExpectedResult = "4361")]
	public string Solve(string input) => new PartA(input).Solve();
}