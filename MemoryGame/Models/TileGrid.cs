using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MemoryGame.Models
{
	public class TileGrid
	{
		private static List<TileType> GetShuffledTypes()
		{
			var types = new List<TileType>();
			foreach (TileType type in Enum.GetValues(typeof(TileType)).Cast<TileType>())
			{
				types.Add(type);
				types.Add(type);
			}

			var random = new Random();
			int remaining = types.Count;
			while (remaining > 1)
			{
				remaining -= 1;
				int k = random.Next(remaining + 1);
				TileType value = types[k];
				types[k] = types[remaining];
				types[remaining] = value;
			}
			return types;
		}

		public Player[] Players { get; set; }
		public int GridSize { get; set; }
		public Grid Element { get; set; }

		public Tile[,] Tiles;

		public TileGrid()
		{
			Tiles = new Tile[GridSize, GridSize];
			List<TileType> tileTypes = GetShuffledTypes();
			for (var x = 0; x < GridSize; x += 1)
			{
				Element.ColumnDefinitions.Add(new ColumnDefinition());
				Element.RowDefinitions.Add(new RowDefinition());
				for (var y = 0; y < GridSize; y += 1)
				{
					var tile = new Tile(x, y) { Type = tileTypes[x + y] };
					Element.Children.Add(tile.Element);
					Tiles[x, y] = tile;
				}
			}
		}

		public List<Tile> AllTiles
		{
			get
			{
				var tiles = new List<Tile>();
				for (var x = 0; x < GridSize; x += 1)
				{
					for (var y = 0; y < GridSize; y += 1)
					{
						tiles.Add(Tiles[x, y]);
					}
				}
				return tiles;
			}
		}
	}
}
