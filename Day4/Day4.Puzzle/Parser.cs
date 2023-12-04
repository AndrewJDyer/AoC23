using Common.StringSplit;

namespace Day4.Puzzle;

internal class Parser
{
	private readonly string input;

	private int cardId = 1;

	private Parser(string input) => this.input = input;

	public static IEnumerable<Card> Parse(string input) => new Parser(input).Parse();

	public IEnumerable<Card> Parse() => input.Split(Environment.NewLine).Select(ParseCard);

	private Card ParseCard(string line)
	{
		var (myNumbersString, winningNumbersString) = SplitNumbersLine(line);
		var myNumbers = ParseNumbers(myNumbersString);
		var winningNumbers = ParseNumbers(winningNumbersString);

		return new Card(cardId++, myNumbers, winningNumbers);
	}

	private static (string MyNumbersString, string WinningNumbersString) SplitNumbersLine(string line)
	{
		var cardSplitConf = SplitConfig.TrimAndValidate(2, ':');
		var numbersPart = line.Split(cardSplitConf)[1]; //No need to parse the card ID for now...

		var numbersSplitConf = SplitConfig.TrimAndValidate(2, '|');
		var numbersSplit = numbersPart.Split(numbersSplitConf);

		return (numbersSplit[0], numbersSplit[1]);
	}

	private static IEnumerable<int> ParseNumbers(string numbersString)
		=> numbersString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse);
}
