using System.Windows;
using System.Windows.Controls;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class SettingsPage : Page
	{
		private readonly Settings Config = new Settings();

		public SettingsPage()
		{
			InitializeComponent();
			ApplySettings();
		}

		private void ApplySettings()
		{
			ApplyThemeCard();
			ApplyWindowSetting();
		}

		//Dit laat de verschillende thema's op de knoppen zien dat wordt gelezen uit het settings bestand.
		private void ApplyThemeCard()
		{
			if (Config.ThemeCard == 1)
			{
				ThemeCardButton.Content = "Thema kaarten: Vis";
			}
			else if (Config.ThemeCard == 2)
			{
				ThemeCardButton.Content = "Thema kaarten: Ruimte";
			}

		}
		
		//Onze 2 thema's worden gelinked aan een int (1 en 2).
		private void ThemeCardSelector(object sender, RoutedEventArgs e)
		{
			if (Config.ThemeCard == 1)
			{
				Config.ThemeCard = 2;
			}
			else if (Config.ThemeCard == 2)
			{
				Config.ThemeCard = 1;
			}

			ApplyThemeCard();
		}

		//deze kan ik niet uitleggen !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		private void ApplyWindowSetting()
		{
			FullScreenButton.Content = Config.WindowSetting;
			var window = (MainWindow)Application.Current.MainWindow;
			window.SetWindow();
		}

		//Keuze tussen een fullscreen en venster
		public void ChangeWindowSize(object sender, RoutedEventArgs e)
		{
			if (Config.WindowSetting == "Windowed") Config.WindowSetting = "FullScreen";
			else if (Config.WindowSetting == "FullScreen") Config.WindowSetting = "Windowed";
			ApplyWindowSetting();
		}

		//Reset de settings naar standaard.
		public void ResetSettings(object sender, RoutedEventArgs e)
		{
			Config.ResetSettings();
			ApplySettings();
			ApplyWindowSetting();
		}

		public void GoBack(object sender, RoutedEventArgs e) 
		{
			//Gaat terug naar de MainMenu.
			NavigationService.Navigate(new MainMenu());
		}

	}
}	
