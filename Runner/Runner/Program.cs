using Common;

void RunPuzzle(IPuzzle puzzle)
{
	Console.WriteLine($"Running {GetPuzzleDescription(puzzle)}...");
	Console.WriteLine($"Solution={puzzle.Solve()}");
}

static string GetPuzzleDescription(IPuzzle puzzle) => $"Day {puzzle.Day} Part {puzzle.Part}";