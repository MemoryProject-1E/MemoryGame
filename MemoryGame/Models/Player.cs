using System.Collections.Generic;
using System.Windows.Controls;

namespace MemoryGame.Models
{
	public class Player
	{
		private readonly HashSet<CardType> ScoredTypes = new HashSet<CardType>();
		public string Name;
		public TextBlock ScoreElement;


		/// <summary>
		/// Leest Player 1 en Player 2 in de public list Player
		/// </summary>
		public Player(string name)
		{
			Name = name;
		}

		//Makes it so that every match gives 20 points.
		public int Score => ScoredTypes.Count * 20;

		public void ApplyScore(CardType type)
		{
			ScoredTypes.Add(type);
		}
	}
}
