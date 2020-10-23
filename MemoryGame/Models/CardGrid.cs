using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MemoryGame.Models
{
	public class CardGrid
	{
		private static List<CardType> GetShuffledTypes()
		{
			var types = new List<CardType>();
			foreach (CardType type in Enum.GetValues(typeof(CardType)).Cast<CardType>())
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
				CardType value = types[k];
				types[k] = types[remaining];
				types[remaining] = value;
			}
			return types;
		}

		public Player[] Players { get; set; }
		public int GridSize { get; set; }
		public Grid Element { get; set; }

		public Card[,] Cards;

		public CardGrid()
		{
			Cards = new Card[GridSize, GridSize];
			List<CardType> CardTypes = GetShuffledTypes();
			for (var x = 0; x < GridSize; x += 1)
			{
				Element.ColumnDefinitions.Add(new ColumnDefinition());
				Element.RowDefinitions.Add(new RowDefinition());
				for (var y = 0; y < GridSize; y += 1)
				{
					var card = new Card(x, y) { Type = CardTypes[x + y] };
					Element.Children.Add(card.Element);
					Cards[x, y] = card;
				}
			}
		}

		public List<Card> AllCards
		{
			get
			{
				var cards = new List<Card>();
				for (var x = 0; x < GridSize; x += 1)
				{
					for (var y = 0; y < GridSize; y += 1)
					{
						cards.Add(Cards[x, y]);
					}
				}
				return cards;
			}
		}
	}
}
