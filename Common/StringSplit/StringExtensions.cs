namespace Common.StringSplit;

public static class StringExtensions
{
	public static string[] Split(this string str, SplitConfig config)
	{
		var split = str.Split(config.Separators);
		DoValidation();
		return config.ShouldTrim ? DoTrim() : split;


		void DoValidation()
		{
			if (!config.ShouldValidate)
				return;

			if (split.Length != config.ExpectedParts)
				throw new InvalidOperationException($"Invalid split count, expected {config.ExpectedParts} parts splitting {str} using {config.Separators}");
		}

		string[] DoTrim() => split.Select(split => split.Trim()).ToArray();
	}
}
