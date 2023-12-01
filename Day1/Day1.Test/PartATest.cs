using Day1.Puzzle;

namespace Day1.Test;

public class Tests
{
	private const string ExampleInput = """
		1abc2
		pqr3stu8vwx
		a1b2c3d4e5f
		treb7uchet
		""";

	[TestCase(ExampleInput, ExpectedResult = "142")]
	[TestCase("1abc2", ExpectedResult = "12")]
	[TestCase("treb7uchet", ExpectedResult = "77")]
	[TestCase("", ExpectedResult = "0")]
	public string Solve(string input) => new PartA(input).Solve();
}