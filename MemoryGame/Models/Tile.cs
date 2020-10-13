using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemoryGame.Models
{
	public class Tile
	{
		private static Dictionary<TileType, string> TileTypeImages = new Dictionary<TileType, string>
		{
			{ TileType.Star, "Star" },
			{ TileType.Moon, "Moon" },
			{ TileType.Cat, "Cat" },
			{ TileType.Dog, "Dog" },
			{ TileType.Duck, "Duck" },
			{ TileType.Hand, "Hand" },
			{ TileType.Seven, "Seven" },
			{ TileType.Eye, "Eye" },
		};

		public TileType Type { get; set; }
		public bool IsMatched = false;
		public Button Element = new Button();

		public Tile(int x, int y)
		{
			Element.Style = Application.Current.TryFindResource("TileButton") as Style;
			Grid.SetRow(Element, y);
			Grid.SetColumn(Element, x);
		}

		public bool IsRevealed => Element.Content != null;

		public void Reveal()
		{
			if (!IsRevealed)
			{
				Element.Content = TileTypeImages[Type];
				Element.Background = Brushes.White;
;			}
		}

		public void Hide()
		{
			if (!IsMatched)
			{
				Element.Content = string.Empty;
				Element.Background = Constants.COLOR_PURPLE;
			}
		}
	}

	public enum TileType
	{
		Star,
		Moon,
		Cat,
		Dog,
		Duck,
		Hand,
		Seven,
		Eye,
	}
}
