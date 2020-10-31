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
			ApplyGridSize();
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

		public void GoBack(object sender, RoutedEventArgs e) 
		{
			NavigationService.Navigate(new MainMenu());
		}
	}
}	
