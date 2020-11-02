using System.Windows;
using System.Windows.Controls;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class Outcome : Page
	{
		private readonly Settings Config = new Settings();
		private readonly Player[] Players;

		public Outcome(Player[] players)
		{
			InitializeComponent();
			Players = players;

			// Display result text
			if (players[0].Score == players[1].Score)
			{
				MainOutcomeTextBlock.Text = "Gelijkspel!";
			}
			else
			{
				Player winner = players[players[0].Score > players[1].Score ? 0 : 1];
				MainOutcomeTextBlock.Text = $"{winner.Name} heeft gewonnen met een score van {winner.Score}!";
			}

			// Register high scores if any
			foreach (Player player in players)
			{
				if (Config.RegisterHighScore(player))
				{
					AdditionalMessagesContainer.Children.Add(new TextBlock()
					{
						Text = $"High score toegevoegd voor {player.Name}",
						Style = Application.Current.TryFindResource("OutcomeAdditionalMessage") as Style,
					});
				}
			}
		}

		public void Rematch(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new GamePage(new Player[]
			{
				new Player(Players[0].Name),
				new Player(Players[1].Name),
			}));
		}

		public void GoToMainMenu(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainMenu());
		}

		public void ExitGame(object sender, RoutedEventArgs e)
		{
			System.Environment.Exit(0);
		}
	}
}
