using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Puzzle;

public class PartB : IPuzzle
{
	private readonly string input;

	int IPuzzle.Day => 4;
	string IPuzzle.Part => "B";

	public PartB(string input) => this.input = input;

	public string Solve()
	{
		var cards = Parser.Parse(input).ToArray();

		int scratchcardsCount = 0;
		foreach (var card in cards)
			ProcessCard(card);

		return scratchcardsCount.ToString();

		void ProcessCard(Card card)
		{
			scratchcardsCount++;
			for (int i = card.Id; i < card.Id + card.ScoringCount; i++)
				ProcessCard(cards[i]);
		}
	}
}
