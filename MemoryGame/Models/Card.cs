using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MemoryGame.Models
{
	public class Card
	{
		private static Dictionary<CardType, string> CardTypeImages = new Dictionary<CardType, string>
		{
			{ CardType.Star, "Star" },
			{ CardType.Moon, "Moon" },
			{ CardType.Cat, "Cat" },
			{ CardType.Dog, "Dog" },
			{ CardType.Duck, "Duck" },
			{ CardType.Hand, "Hand" },
			{ CardType.Seven, "Seven" },
			{ CardType.Eye, "Eye" },
		};

		public CardType Type { get; set; }
		public bool IsMatched = false;
		public Button Element = new Button();

		public Card(int x, int y)
		{
			Element.Style = Application.Current.TryFindResource("CardButton") as Style;
			Grid.SetRow(Element, y);
			Grid.SetColumn(Element, x);
		}

		public bool IsRevealed => Element.Content != null;

		public void Reveal()
		{
			if (!IsRevealed)
			{
				Element.Content = CardTypeImages[Type];
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

	public enum CardType
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
