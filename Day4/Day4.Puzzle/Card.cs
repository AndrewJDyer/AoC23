namespace Day4.Puzzle;

internal class Card
{
	private readonly IEnumerable<int> myNumbers;
	private readonly IEnumerable<int> winningNumbers;

	private readonly Lazy<IReadOnlyList<int>> scoringNumbers;

	public int ScoringCount => scoringNumbers.Value.Count;
	public int Id { get; }

	public Card(int id, IEnumerable<int> myNumbers, IEnumerable<int> winningNumbers)
	{
		Id = id;
		this.myNumbers = myNumbers;
		this.winningNumbers = winningNumbers;

		scoringNumbers = new(GetScoringNumbers);
	}

	private IReadOnlyList<int> GetScoringNumbers() => myNumbers.Intersect(winningNumbers).ToList();

	public int CalculatePoints()
	{
		if (ScoringCount == 0)
			return 0;

		var score = 1;
		for (int i = 0; i < ScoringCount - 1; i++)
			score *= 2;

		return score;
	}

	public override string ToString() => Id.ToString();
}
