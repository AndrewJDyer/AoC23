namespace Day1.Puzzle;

internal class LineB : Line
{
	private static readonly Dictionary<string, int> SpelledDigits = new()
	{
		{ "one", 1 },
		{ "two", 2 },
		{ "three", 3 },
		{ "four", 4 },
		{ "five", 5 },
		{ "six", 6 },
		{ "seven", 7 },
		{ "eight", 8 },
		{ "nine", 9 }
	};

	public LineB(string value) : base(value) { }

	protected override int GetFirstDigit()
	{
		var firstSpelledDigit = GetFirstSpelledDigit();
		if (firstSpelledDigit.Digit == 0)
			return base.GetFirstDigit();

		var firstNumericDigitIndex = base.GetFirstDigitIndex();
		if (firstNumericDigitIndex < 0)
			return firstSpelledDigit.Digit;

		return firstSpelledDigit.Index < firstNumericDigitIndex ? firstSpelledDigit.Digit : GetValueForIndex(firstNumericDigitIndex);
	}

	private (int Digit, int Index) GetFirstSpelledDigit()
	{
		var (digit, index) = (0, Int32.MaxValue);

		foreach (var spelledDigit in SpelledDigits)
		{
			var i = value.IndexOf(spelledDigit.Key);
			if (i != -1 && i < index)
				(digit, index) = (spelledDigit.Value, i);
		}

		return (digit, index);
	}

	protected override int GetLastDigit()
	{
		var lastSpelledDigit = GetLastSpelledDigit();
		if (lastSpelledDigit.Digit == 0)
			return base.GetLastDigit();

		var lastNumericDigitIndex = base.GetLastDigitIndex();
		return lastSpelledDigit.Index > lastNumericDigitIndex ? lastSpelledDigit.Digit : GetValueForIndex(lastNumericDigitIndex);
	}

	private (int Digit, int Index) GetLastSpelledDigit()
	{
		var (digit, index) = (0, -1);

		foreach (var spelledDigit in SpelledDigits)
		{
			var i = value.LastIndexOf(spelledDigit.Key);
			if (i > index)
				(digit, index) = (spelledDigit.Value, i);
		}

		return (digit, index);
	}
}
