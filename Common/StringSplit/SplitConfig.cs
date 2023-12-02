namespace Common.StringSplit;

public readonly record struct SplitConfig(
	SplitOptions Options = SplitOptions.None,
	int ExpectedParts = 0,
	params char[] Separators)
{
	public bool ShouldTrim => (Options & SplitOptions.Trim) != 0;
	public bool ShouldValidate => (Options & SplitOptions.Validate) != 0;

	public static SplitConfig Trim(params char[] separators) => new(SplitOptions.Trim, Separators: separators);
	public static SplitConfig Validate(int expectedParts, params char[] separators)
		=> new(SplitOptions.Validate, ExpectedParts: expectedParts, Separators: separators);
	public static SplitConfig TrimAndValidate(int expectedParts, params char[] separators)
		=> new(SplitOptions.Trim | SplitOptions.Validate, ExpectedParts: expectedParts, Separators: separators);
}