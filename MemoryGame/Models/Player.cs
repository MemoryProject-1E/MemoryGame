using System.Collections.Generic;

namespace MemoryGame.Models
{
	public class Player
	{
		public string Name { get; set; }
		private HashSet<TileType> ScoredTypes = new HashSet<TileType>();

		public int Score => ScoredTypes.Count;

		public void ApplyScore(TileType type)
		{
			ScoredTypes.Add(type);
		}
	}
}
