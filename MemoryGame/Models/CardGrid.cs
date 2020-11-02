using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MemoryGame.Models
{
	public class CardGrid
	{
		private static List<CardType> GetShuffledTypes()
		{
			/// <summary>
			/// Advanced randomizer van online
			/// </summary>
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

		public StackPanel Element;
		public int GridSize;
		public Card[,] Cards;

		public CardGrid(StackPanel element, int gridSize)
		{
			Element = element;
			GridSize = gridSize;
			Cards = new Card[GridSize, GridSize];
			List<CardType> cardTypes = GetShuffledTypes();

			for (int x = 0; x < GridSize; x += 1)
			{
				var row = new StackPanel
				{
					Style = Application.Current.TryFindResource("CardGridRow") as Style
				};
				for (int y = 0; y < GridSize; y += 1)
				{
					var card = new Card(cardTypes[GridSize * x + y]);
					Cards[x, y] = card;
					row.Children.Add(card.Element);
				}
				Element.Children.Add(row);
			}
		}

		public List<Card> AllCards
		{
			get
			{
				var elements = new List<Card>();
				for (var x = 0; x < GridSize; x += 1)
				{
					for (var y = 0; y < GridSize; y += 1)
					{
						elements.Add(Cards[x, y]);
					}
				}
				return elements;
			}
		}

		public void SetCardsEnabled(bool isEnabled)
		{
			AllCards.ForEach(card =>
			{
				card.Element.IsEnabled = isEnabled;
			});
		}
	}
}
