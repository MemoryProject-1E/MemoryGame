using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MemoryGame.Models
{
	public class Card
	{
		private static readonly Dictionary<CardType, string> CardTypeImages = new Dictionary<CardType, string>
		{
			{ CardType.Star, "Star.jpg" },
			{ CardType.Moon, "Moon.jpg" },
			{ CardType.Cat, "Cat.jpg" },
			{ CardType.Dog, "Dog.jpg" },
			{ CardType.Duck, "Duck.jpg" },
			{ CardType.Hand, "Hand.jpg" },
			{ CardType.Seven, "Seven.jpg" },
			{ CardType.Eye, "Eye.jpg" },
		};

		public CardType Type;
		public Button Element;
		private readonly Image Image;

		public Card(CardType type)
		{
			Type = type;

			Element = new Button()
			{
				Style = Application.Current.TryFindResource("CardGridCard") as Style,
			};

			Image = new Image()
			{
				Style = Application.Current.TryFindResource("CardImage") as Style,
				Source = new BitmapImage(new Uri($"../Assets/Images/Cards/{CardTypeImages[Type]}", UriKind.Relative)),
				Stretch = Stretch.UniformToFill,
			};
		}

		public bool IsRevealed => Element.Content != null;

		public void Hide()
		{
			Element.Content = null;
		}

		public void Reveal()
		{
			Element.Content = Image;
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
