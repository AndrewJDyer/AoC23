namespace Day3.Puzzle;

internal readonly record struct EngineSpace(IEnumerable<EngineLocation> Locations)
{
	public bool IsAdjacentToAny(IEnumerable<EngineLocation> locations)
		=> locations.Any(IsAdjacentTo);

	public bool IsAdjacentTo(EngineLocation location) => Locations.Any(x => x.IsAdjacentTo(location));
}
