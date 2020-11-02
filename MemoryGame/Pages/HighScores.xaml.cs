using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class HighScores : Page
	{
		//leest de Settings.cs pagina in. Hier sit ook HighScore relevanten 
		//dingen in omdat we alles in een bestand hebben
		private readonly Settings Config = new Settings();

		public HighScores()
		{
			InitializeComponent();
			DisplayScores();
		}


		/// <remarks>
		/// Config.Highscores" zoekt de lijst de "HighScores" in Settings.cs die hierboven ingelezen word.
		/// </remarks>
		/// <summary>
		/// De functie zorgt ervoor dat ieder item uit de lijst "HighScores" op beeld wordt laten zien.
		/// </summary>
		public void DisplayScores()
		{
			foreach (HighScore HighScore in Config.HighScores)
			{
				HighScoresList.Items.Add(new ListBoxItem()
				{
					Style = Application.Current.TryFindResource("HighScoreItem") as Style,
					Content = $"{HighScore.PlayerName} {HighScore.Score}",
				});
			}
		}
		
		public void GoBack(object sender, RoutedEventArgs e)
		{
			//Gaat naar de MainMenu.
			NavigationService.Navigate(new MainMenu());
		}

		public void Reset(object sender, RoutedEventArgs e)
		{
			//Reset de Highscores.
			Config.ResetHighScores();
			NavigationService.Navigate(new HighScores());

		}
	}
}
