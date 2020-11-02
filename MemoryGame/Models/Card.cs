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
		private readonly Settings Config = new Settings();
		private static readonly Dictionary<CardType, string> CardTypeImages = new Dictionary<CardType, string>
		{
			{ CardType.Fish1, "Fish1.jpg" },
			{ CardType.Fish2, "Fish2.jpg" },
			{ CardType.Fish3, "Fish3.jpg" },
			{ CardType.Fish4, "Fish4.jpg" },
			{ CardType.Fish_5, "Fish_5.jpg" },
			{ CardType.Fish_6, "Fish_6.jpg" },
			{ CardType.Fish_7, "Fish_7.jpg" },
			{ CardType.Fish_8, "Fish_8.jpg" },
		};

		public CardType Type;
		public Button Element;
		private readonly Image Image;

		public Card(CardType type)
		{
			if (Config.ThemeCard == 2)
			{
				CardTypeImages.Clear();
				CardTypeImages.Add(CardType.Fish1, "Aarde.jpg");
				CardTypeImages.Add(CardType.Fish2, "Jupiter.jpg");
				CardTypeImages.Add(CardType.Fish3, "Mars.png");
				CardTypeImages.Add(CardType.Fish4, "Mercurius.jpg");
				CardTypeImages.Add(CardType.Fish_5, "Neptunes.jpg");
				CardTypeImages.Add(CardType.Fish_6, "Saturnus.jpg");
				CardTypeImages.Add(CardType.Fish_7, "Uranus.jpg");
				CardTypeImages.Add(CardType.Fish_8, "Venus.jpg");
			}
			else if (Config.ThemeCard == 1)
			{
				CardTypeImages.Clear();
				CardTypeImages.Add(CardType.Fish1, "Fish1.jpg");
				CardTypeImages.Add(CardType.Fish2, "Fish2.jpg");
				CardTypeImages.Add(CardType.Fish3, "Fish3.png");
				CardTypeImages.Add(CardType.Fish4, "Fish4.jpg");
				CardTypeImages.Add(CardType.Fish_5, "Fish_5.jpg");
				CardTypeImages.Add(CardType.Fish_6, "Fish_6.jpg");
				CardTypeImages.Add(CardType.Fish_7, "Fish_7.jpg");
				CardTypeImages.Add(CardType.Fish_8, "Fish_8.jpg");
			}

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

		public void Matched()
		{
			Element.Visibility = Visibility.Hidden;
		}
	}

	public enum CardType
	{
		Fish1,
		Fish2,
		Fish3,
		Fish4,
		Fish_5,
		Fish_6,
		Fish_7,
		Fish_8,
	}
}
