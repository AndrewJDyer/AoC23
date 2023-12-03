using Common;

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
			if (value[i].IsDigit())
				return i;
		}

		return -1;
	}

	protected virtual int GetLastDigit() => GetValueForIndex(GetLastDigitIndex());

	protected int GetLastDigitIndex()
	{
		for (int i = value.Length - 1; i >= 0; i--)
		{
			if (value[i].IsDigit())
				return i;
		}

		return -1;
	}

	protected int GetValueForIndex(int index) => index >= 0 ? value[index].ToInt() : 0;
}
