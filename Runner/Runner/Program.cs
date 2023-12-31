﻿using Common;
using Runner.Properties;

RunPuzzle(new Day4.Puzzle.PartB(Resources.Day4Input));

static void RunPuzzle(IPuzzle puzzle)
{
	Console.WriteLine($"Running {GetPuzzleDescription(puzzle)}...");
	Console.WriteLine($"Solution={puzzle.Solve()}");

	Console.WriteLine("Press any key to exit...");
	Console.ReadKey();
}

static string GetPuzzleDescription(IPuzzle puzzle) => $"Day {puzzle.Day} Part {puzzle.Part}";