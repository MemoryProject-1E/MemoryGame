using System.Collections.Generic;
using System.Windows.Controls;

namespace MemoryGame.Models
{
	public class Player
	{
		private readonly HashSet<CardType> ScoredTypes = new HashSet<CardType>();
		public string Name;
		public TextBlock ScoreElement;

		public Player(string name)
		{
			Name = name;
		}

		public int Score => ScoredTypes.Count * 20;

		public void ApplyScore(CardType type)
		{
			ScoredTypes.Add(type);
		}
	}
}
