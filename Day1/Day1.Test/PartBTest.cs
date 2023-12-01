using Day1.Puzzle;

namespace Day1.Test;

internal class PartBTest
{
	private const string ExampleInput = """
		two1nine
		eightwothree
		abcone2threexyz
		xtwone3four
		4nineeightseven2
		zoneight234
		7pqrstsixteen
		""";

	[TestCase(ExampleInput, ExpectedResult = "281")]
	[TestCase("two1nine", ExpectedResult = "29")]
	[TestCase("7pqrstsixteen", ExpectedResult = "76")]
	[TestCase("eightwothree", ExpectedResult = "83")]
	[TestCase("abcone2threexyz", ExpectedResult = "13")]
	[TestCase("xtwone3four", ExpectedResult = "24")]
	[TestCase("4nineeightseven2", ExpectedResult = "42")]
	[TestCase("zoneight234", ExpectedResult = "14")]
	[TestCase("7pqrstsixteen", ExpectedResult = "76")]
	[TestCase("", ExpectedResult = "0")]
	public string Solve(string input) => new PartB(input).Solve();
}
