namespace Day3.Puzzle;

internal readonly record struct EngineLocation(int X, int Y)
{
	public bool IsAdjacentTo(EngineSpace space) => space.IsAdjacentTo(this);

	public bool IsAdjacentTo(EngineLocation other)
		=> IsXAdjacentTo(other) && IsYAdjacentTo(other);

	private bool IsXAdjacentTo(EngineLocation other)
		=> X > other.X ? (X - other.X < 2) : (other.X - X < 2);

	private bool IsYAdjacentTo(EngineLocation other)
		=> Y > other.Y ? (Y - other.Y < 2) : (other.Y - Y < 2);
}
