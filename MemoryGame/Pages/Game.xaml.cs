using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class Game : Page
	{
		private Player[] Players;
		private CardGrid GridData;
		private int CurrentPlayerIndex = 0;
		private (int x, int y) RevealedCardCoords = (-1, -1);
		private Window SettingsWindow = new Window();

		public Game(Player[] players)
		{
			Players = players;
			InitializeComponent();
			GridData = new CardGrid {
				Players = Players,
				GridSize = 4,
				Element = CardGridEl,
			};
			DrawCards();
			UpdatePlayerScore(Players[0]);
			UpdatePlayerScore(Players[1]);
			SettingsWindow.Style = Application.Current.TryFindResource("SettingsWindow") as Style;
		}

		public void DrawCards()
		{

		}
		

		public void OpenSettings(object sender, RoutedEventArgs e)
		{
			SettingsWindow = new Window();
			SettingsWindow.Show();
		}

		private void UpdatePlayerScore(Player player)
		{
			var isPlayerOne = player == Players[0];
			TextBlock textElement = isPlayerOne ? PlayerOneScoreText : PlayerTwoScoreText;
			StackPanel indicators = isPlayerOne ? PlayerOneScoreIndicators : PlayerTwoScoreIndicators;
			textElement.Text = $"{player.Name}: {player.Score}";
			for (var i = 0; i < indicators.Children.Count; i += 1)
			{
				StackPanel indicator = indicators.Children[i] as StackPanel;
				indicator.Background = i <= player.Score ? Constants.COLOR_PURPLE : Brushes.Transparent;
			}
		}

		private Player CurrentPlayer => Players[CurrentPlayerIndex];

		private Card RevealedCard => RevealedCardCoords.x == -1
			? null
			: GridData.Cards[RevealedCardCoords.x, RevealedCardCoords.y];

		public void OnCardClick(object sender, RoutedEventArgs e)
		{
			Button cardButton = e.Source as Button;
			int x = Grid.GetColumn(cardButton);
			int y = Grid.GetRow(cardButton);
			Card card = GridData.Cards[x, y];

			// Ignore clicks on already revealed cards
			if (!card.IsRevealed)
			{
				card.Reveal();

				// First card
				if (RevealedCard == null)
				{
					RevealedCardCoords = (x, y);
				}

				// No match
				else if (card.Type != RevealedCard.Type)
				{
					card.Hide();
					RevealedCard.Hide();
					RevealedCardCoords = (-1, -1);
					NextPlayer();
				}

				// Match
				else
				{
					CurrentPlayer.ApplyScore(card.Type);

					card.IsMatched = true;
					RevealedCard.IsMatched = true;
					RevealedCardCoords = (-1, -1);
				}
			}
		}

		private void NextPlayer()
		{
			CurrentPlayerIndex = CurrentPlayerIndex == 0 ? 1 : 0;
		}
	}
}
