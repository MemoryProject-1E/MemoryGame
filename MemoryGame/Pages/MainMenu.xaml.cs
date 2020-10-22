using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MemoryGame.Pages
{
	public partial class MainMenu : Page
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		public void GoToNewGame(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Game());
		}

		public void GoToHighScores(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new HighScores());
		}

		public void GoToCredits(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Credits());
		}

        public void GoToSettings(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Settings());
        }

		private void ExitGame(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}
    }
}
