using Common.StringSplit;
using static Common.StringSplit.StringExtensions;

namespace Day2.Puzzle;

internal class Parser
{
	private readonly string input;
	private readonly Lazy<string[]> gameLines;

	public Parser(string input)
	{
		this.input = input;
		gameLines = new(GetGameLines);
	}

	public IEnumerable<Game> Parse() => gameLines.Value.Select(ParseGame).ToList();

	private static Game ParseGame(string gameLine)
	{
		var (gameDesc, handfullsString) = SplitGameline(gameLine);
		var gameId = ParseGameId(gameDesc);
		var handfulls = ParseHandfulls(handfullsString);

		return new Game(gameId, handfulls);
	}

	private static (string GameDescription, string Handfulls) SplitGameline(string gameLine)
	{
		var splitConf = SplitConfig.TrimAndValidate(expectedParts: 2, ':');
		var split = gameLine.Split(splitConf);
		return (split[0], split[1]);
	}

	private static int ParseGameId(string gameDescription)
	{
		var splitConf = SplitConfig.Validate(expectedParts: 2, ' ');
		var idString = gameDescription.Split(splitConf)[^1];
		return Int32.Parse(idString);
	}

	private static IEnumerable<CubeCollection> ParseHandfulls(string handfullsString)
	{
		var splitConf = SplitConfig.Trim(';');
		var handfullsSplit = handfullsString.Split(splitConf);

		return handfullsSplit.Select(ParseHandfull);
	}

	private static CubeCollection ParseHandfull(string handfullDesc)
	{
		var splitConf = SplitConfig.Trim(',');
		var cubeSets = handfullDesc.Split(splitConf);

		var handfull = new CubeCollection();
		var colourSets = cubeSets.Select(ParseCubeCollection);
		foreach (var colourSet in colourSets)
			handfull += colourSet;

		return handfull;
	}

	private static CubeCollection ParseCubeCollection(string collectionDesc)
	{
		var splitConf = SplitConfig.Validate(expectedParts: 2, ' ');
		var split = collectionDesc.Split(splitConf);
		var (countString, colour) = (split[0], split[1]);
		var count = Int32.Parse(countString);

		return colour switch
		{
			"green" => CubeCollection.AllGreen(count),
			"blue" => CubeCollection.AllBlue(count),
			"red" => CubeCollection.AllRed(count),
			_ => throw new InvalidOperationException($"Invalid colour {colour}")
		};
	}

	private string[] GetGameLines() => input.Split(Environment.NewLine);
}
