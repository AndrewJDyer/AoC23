namespace Common.StringSplit;

[Flags]
public enum SplitOptions
{
	None = 0b0,
	Validate = 0b1,
	Trim = 0b10
}
