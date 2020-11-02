using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MemoryGame.Pages
{
	public partial class MainMenu : Page
	{

		/// <summary>
		/// In deze pagina zitten de knoppen die te vinden zijn in MainMenu.xaml. 
		/// De knoppen verwijzen naar andere .xaml bestanden die in ons mappenstructuur te vinden zijn.
		/// </summary>
		public MainMenu()
		{
			InitializeComponent();
		}

		public void GoToNewGame(object sender, RoutedEventArgs e)
		{
			//Gaat naar PlayerSetup en daarna naar het spel. Of er kan terug worden genavigeerd.
			NavigationService.Navigate(new PlayerSetup());
		}

		public void GoToHighScores(object sender, RoutedEventArgs e)
		{
			//Gaat naar de highscore pagina.
			NavigationService.Navigate(new HighScores());
		}

		public void GoToSettings(object sender, RoutedEventArgs e)
		{
			//Gaat naar de eerste Settings pagina. In het spel zelf heb je een andere settings pagina.
			NavigationService.Navigate(new SettingsPage());
		}

		public void GoToCredits(object sender, RoutedEventArgs e)
		{
			//Gaat naar de Credit scherm met onze namen
			NavigationService.Navigate(new Credits());
		}

		private void ExitGame(object sender, RoutedEventArgs e)
		{
			//Sluit het spel af.
			Environment.Exit(0);
		}
	}
}
