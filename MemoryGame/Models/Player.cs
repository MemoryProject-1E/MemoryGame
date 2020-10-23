using System.Collections.Generic;

namespace MemoryGame.Models
{
	public class Player
	{
		public string Name { get; set; }
		private HashSet<CardType> ScoredTypes = new HashSet<CardType>();

		public int Score => ScoredTypes.Count;
			
		public void ApplyScore(CardType type)
		{
			ScoredTypes.Add(type);
		}
	}
}
