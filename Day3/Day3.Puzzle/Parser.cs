using Common;

namespace Day3.Puzzle;

internal class Parser
{
	private readonly string[] lines;

	private readonly List<EnginePart> parts = new();
	private readonly List<EngineLocation> symbolLocations = new();
	private readonly List<EngineLocation> gearLocations = new();
	private readonly List<char> currentPartDigits = new();
	private readonly List<EngineLocation> currentPartLocations = new();

	private int x;
	private int y;

	private string Line => lines[y];
	private char Character => Line[x];

	private Parser(string[] lines) => this.lines = lines;

	public static Schematic Parse(string input)
	{
		var lines = input.Split(Environment.NewLine);
		return new Parser(lines).Parse();
	}

	private Schematic Parse()
	{
		for (y = 0; y < lines.Length; y++)
			ParseLine();

		return new Schematic(symbolLocations, gearLocations, parts);
	}

	private void ParseLine()
	{
		for (x = 0; x < lines.Length; x++)
			ParseChar();

		CompletePartNumber();
	}

	private void ParseChar()
	{
		if (Character.IsDigit())
		{
			AppendPartNumber();
			return;
		}

		if (currentPartDigits.Count != 0)
			CompletePartNumber();

		if (IsCurrentCharEmpty())
			return;

		//must be a symbol now!
		symbolLocations.Add(GetLocation());
		if (Character == '*')
			gearLocations.Add(GetLocation());
	}

	private void AppendPartNumber()
	{
		currentPartDigits.Add(Character);
		currentPartLocations.Add(GetLocation());
	}

	private void CompletePartNumber()
	{
		if (HaveCurrentPart())
			AddCurrentPart();
		ResetCurrentPart();
	}

	private bool HaveCurrentPart() => currentPartDigits.Count != 0;

	private void AddCurrentPart()
	{
		var part = CreatePart();
		parts.Add(part);
	}

	private void ResetCurrentPart()
	{
		currentPartLocations.Clear();
		currentPartDigits.Clear();
	}

	private EnginePart CreatePart()
	{
		var number = Int32.Parse(currentPartDigits.ToArray());
		var space = new EngineSpace(currentPartLocations.ToList());

		return new EnginePart(number, space);
	}

	private EngineLocation GetLocation() => new(x, y);

	private bool IsCurrentCharEmpty() => Character == '.';
}
