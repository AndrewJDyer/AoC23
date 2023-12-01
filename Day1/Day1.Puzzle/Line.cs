using static System.Char;

namespace Day1.Puzzle;

internal class Line
{
	protected readonly string value;

	public Line(string value) => this.value = value;

	public int GetCalibrationValue() => GetFirstDigit() * 10 + GetLastDigit();

	protected virtual int GetFirstDigit() => GetValueForIndex(GetFirstDigitIndex());

	protected int GetFirstDigitIndex()
	{
		for (int i = 0; i < value.Length; i++)
		{
			if (IsDigit(value[i]))
				return i;
		}

		return -1;
	}

	protected virtual int GetLastDigit() => GetValueForIndex(GetLastDigitIndex());

	protected int GetLastDigitIndex()
	{
		for (int i = value.Length - 1; i >= 0; i--)
		{
			if (IsDigit(value[i]))
				return i;
		}

		return -1;
	}

	protected int GetValueForIndex(int index) => index >= 0 ? ToInt(value[index]) : 0;

	private static int ToInt(char c) => c - 48;	//ASCII values for digits are 48-57
}
