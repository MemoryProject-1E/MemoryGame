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
			ChangeWindowText();
		}

		private void ApplyThemeCard()
		{
			if (Config.ThemeCard == 1)
			{
				ThemeCardButton.Content = $"Thema kaarten: Vis";
			}
			else if (Config.ThemeCard == 2)
			{
				ThemeCardButton.Content = $"Thema kaarten: Ruimte";
			}

		}
		
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

		private void ApplyWindowSetting()
		{
			FullScreenButton.Content = Config.WindowSetting;
			var window = (MainWindow)Application.Current.MainWindow;
			window.SetWindow();
		}

		private void ChangeWindowText()
		{
			FullScreenButton.Content = Config.WindowSetting;
		}

		public void ChangeWindowSize(object sender, RoutedEventArgs e)
		{
			if (Config.WindowSetting == "Windowed") Config.WindowSetting = "FullScreen";
			else if (Config.WindowSetting == "FullScreen") Config.WindowSetting = "Windowed";
			ApplyWindowSetting();
		}

		public void ResetSettings(object sender, RoutedEventArgs e)
		{
			Config.ResetSettings();
			ApplySettings();
			ApplyWindowSetting();
		}

		public void GoBack(object sender, RoutedEventArgs e) 
		{
			NavigationService.Navigate(new MainMenu());
		}

	}
}	
