using System;
using System.Windows;
using System.Windows.Controls;

namespace MemoryGame.Pages
{
	public partial class HighScores : Page
	{
		public HighScores()
		{
			InitializeComponent();
		}
		
		public void GoBack(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainMenu());
		}

		public void Reset(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("TODO: Reset score");
		}
	}
}
