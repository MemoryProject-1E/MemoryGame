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
			ApplyGridSize();
			ApplyWindowSetting();
		}

		private void ApplyWindowSetting()
		{
			FullScreenButton.Content = Config.WindowSetting;

			var window = (MainWindow)Application.Current.MainWindow;

			window.SetWindow();

		}

		private void ApplyGridSize()
		{
			GridSizeButton.Content = $"Grid Size: {Config.GridSize}";
		}

		public void ChangeGridSize(object sender, RoutedEventArgs e)
		{
			if (Config.GridSize == 2) Config.GridSize = 4;
			else if (Config.GridSize == 4) Config.GridSize = 6;
			else Config.GridSize = 2;
			ApplyGridSize();
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
		}

		public void GoBack(object sender, RoutedEventArgs e) 
		{
			NavigationService.Navigate(new MainMenu());
		}
	}
}	
