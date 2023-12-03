namespace Day3.Puzzle;

internal class Schematic
{
	private readonly IEnumerable<EngineLocation> symbolLocations;
	private readonly IEnumerable<EngineLocation> gearLocations;
	private readonly IEnumerable<EnginePart> parts;

	public Schematic(
		IEnumerable<EngineLocation> symbolLocations,
		IEnumerable<EngineLocation> gearLocations,
		IEnumerable<EnginePart> parts)
	{
		this.symbolLocations = symbolLocations;
		this.gearLocations = gearLocations;
		this.parts = parts;
	}

	public int SumTruePartNumbers() => FindTruePartNumbers().Sum(p => p.PartNumber);

	private IEnumerable<EnginePart> FindTruePartNumbers() => parts.Where(p => p.Location.IsAdjacentToAny(symbolLocations));

	public int SumGearRatios()
	{
		var sum = 0;
		foreach (var gear in gearLocations)
		{
			var adjacentParts = GetAdjacentParts(gear).ToList();
			if (adjacentParts.Count == 2)
				sum += adjacentParts[0].PartNumber * adjacentParts[1].PartNumber;
		}

		return sum;
	}

	private IEnumerable<EnginePart> GetAdjacentParts(EngineLocation location)
		=> parts.Where(p => p.Location.IsAdjacentTo(location));
}
