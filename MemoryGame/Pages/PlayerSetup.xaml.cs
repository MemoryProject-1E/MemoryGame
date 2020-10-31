using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class PlayerSetup : Page
	{
		public PlayerSetup()
		{
			InitializeComponent();
		}

		private string PlayerOneNameText
		{
			get { return PlayerOneName.Text.Trim(); }
			set { PlayerOneName.Text = value; }
		}

		private string PlayerTwoNameText
		{
			get { return PlayerTwoName.Text.Trim(); }
			set { PlayerTwoName.Text = value; }
		}

		public void Submit(object sender, RoutedEventArgs e)
		{
			if (Validate())
			{
				var players = new Player[2]
				{
					new Player(PlayerOneNameText),
					new Player(PlayerTwoNameText),
				};
				NavigationService.Navigate(new GamePage(players));
			}
		}

		private bool Validate()
		{
			PlayerOneNameFeedback.Text = string.IsNullOrEmpty(PlayerOneNameText) ? "Required" : string.Empty;
			if (string.IsNullOrEmpty(PlayerTwoNameText))
			{
				PlayerTwoNameFeedback.Text = "Required";
			}
			else if (PlayerTwoNameText == PlayerOneNameText)
			{
				PlayerTwoNameFeedback.Text = "Must be unique";
			}
			else
			{
				PlayerTwoNameFeedback.Text = string.Empty;
			}
			return string.IsNullOrEmpty(PlayerOneNameFeedback.Text) && string.IsNullOrEmpty(PlayerTwoNameFeedback.Text);
		}

		public void GoBack(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainMenu());
		}
	}
}
