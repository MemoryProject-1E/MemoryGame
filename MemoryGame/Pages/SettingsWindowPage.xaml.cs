using System.Windows;
using System.Windows.Controls;

namespace MemoryGame.Pages
{
	public partial class SettingsWindowPage : Page
	{


		public SettingsWindowPage()
		{
			InitializeComponent();
		}

		private Window SettingsWindow
		{
			get
			{
				//Dit opent een nieuw venster met settings.
				return Window.GetWindow(this);	
			}
		}

		public void Close(object sender, RoutedEventArgs e)
		{
			//Sluit de in-game settings venster af.
			SettingsWindow.Close();
		}

		public void GoToMainMenu(object sender, RoutedEventArgs e)
		{
			//Gaat naar de MainMenu
			var window = (MainWindow)Application.Current.MainWindow;
			window.GoToMainMenu();

			SettingsWindow.Close();
		}

		public void Exit(object sender, RoutedEventArgs e)
		{
			//Exit de game.
			Application.Current.Shutdown();
		}
	}
}
