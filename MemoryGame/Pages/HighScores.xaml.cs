using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class HighScores : Page
	{
		private readonly Settings Config = new Settings();

		public HighScores()
		{
			InitializeComponent();
			DisplayScores();
		}

		public void DisplayScores()
		{
			foreach (HighScore HighScore in Config.HighScores)
			{

				HighScoresList.Items.Add($"{HighScore.PlayerName} {HighScore.Score}");

			}
		}
		
		public void GoBack(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainMenu());
		}

		public void Reset(object sender, RoutedEventArgs e)
		{
			Config.ResetHighScores();
			NavigationService.Navigate(new HighScores());

		}
	}
}
