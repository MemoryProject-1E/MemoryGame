using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class GamePage : Page
	{
		private readonly Player[] Players;
		private readonly CardGrid GridData;
		private int CurrentPlayerIndex = 0;
		private Card RevealedCard;
		private Window SettingsWindow = new Window() {
			Name = "SettingsWindow",
			Style = Application.Current.TryFindResource("SettingsWindow") as Style,
			Content = new SettingsWindowPage(),
		};
		private readonly Settings Config = new Settings();
		private bool IsLocked = false;

		public GamePage(Player[] players)
		{
			Players = players;
			InitializeComponent();
			GridData = new CardGrid(CardGridEl, Config.GridSize);
			GridData.AllCards
				.Select(card => card.Element)
				.ToList()
				.ForEach(toggleButton =>
				{
					toggleButton.Click += OnCardClick;
				});
			UpdatePlayerScore(Players[0]);
			UpdatePlayerScore(Players[1]);
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
			textElement.Text = $"{player.Name}: {player.Score}";
			if (Players[0].Score + Players[1].Score == System.Math.Pow(Config.GridSize, 2) / 2 * 20)
			{
				NavigationService.Navigate(new Outcome(Players));
			}
		}

		private Player CurrentPlayer => Players[CurrentPlayerIndex];

		public async void OnCardClick(object sender, RoutedEventArgs e)
		{
			if (IsLocked) return;
			Card card = GridData.AllCards.First(a => a.Element == e.Source as Button);
			if (card.IsRevealed) return;
			card.Reveal();

			// First card
			if (RevealedCard == null)
			{
				RevealedCard = card;
			}

			// No match
			else if (card.Type != RevealedCard.Type)
			{
				IsLocked = true;
				await Task.Delay(1000);
				card.Hide();
				RevealedCard.Hide();
				GridData.SetCardsEnabled(false);
				RevealedCard = null;
				CurrentPlayerIndex = CurrentPlayerIndex == 0 ? 1 : 0;
				GridData.SetCardsEnabled(true);
				IsLocked = false;
			}

			// Match
			else
			{
				CurrentPlayer.ApplyScore(card.Type);
				await Task.Delay(500);
				card.Matched();
				RevealedCard.Matched();
				UpdatePlayerScore(CurrentPlayer);
				RevealedCard = null;			
			}
		}
	}
}
