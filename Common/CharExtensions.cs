namespace Common;

public static class CharExtensions
{
	public static bool IsDigit(this char c) => Char.IsDigit(c);
	public static int ToInt(this char c) => c - '0';
}
