namespace Day2.Puzzle;

internal class Game
{
	private readonly IEnumerable<CubeCollection> handfulls;

	public int Id { get; }

	public Game(int id, IEnumerable<CubeCollection> handfulls)
	{
		Id = id;
		this.handfulls = handfulls;
	}

	public bool IsPossible(CubeCollection actualCubes) => handfulls.All(h => IsHandfullPossible(h, actualCubes));

	private static bool IsHandfullPossible(CubeCollection handfull, CubeCollection actualCubes)
		=> handfull.Green <= actualCubes.Green &&
			handfull.Blue <= actualCubes.Blue &&
			handfull.Red <= actualCubes.Red;

	public int GetPower()
	{
		var maxGreen = 0;
		var maxBlue = 0;
		var maxRed = 0;

		foreach (var handfull in handfulls)
		{
			if (handfull.Green > maxGreen)
				maxGreen = handfull.Green;
			if (handfull.Blue > maxBlue)
				maxBlue = handfull.Blue;
			if (handfull.Red > maxRed)
				maxRed = handfull.Red;
		}

		return maxGreen * maxBlue * maxRed;
	}
}
