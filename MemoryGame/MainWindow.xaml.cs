using System.Windows;
using System.Configuration;
using System.Windows.Navigation;
using MemoryGame.Pages;
using MemoryGame.Models;


namespace MemoryGame
{
	public partial class MainWindow : NavigationWindow
	{

		private readonly Settings Config = new Settings();

		public MainWindow()
		{
			InitializeComponent();
			SetWindow();
		}

		public void SetWindow()
		{
			if (Config.WindowSetting == "Windowed")
			{
				ResizeMode = ResizeMode.CanResize;
				WindowStyle = WindowStyle.SingleBorderWindow;
				WindowState = WindowState.Normal;
				Topmost = false;
			}
			else if (Config.WindowSetting == "FullScreen")
			{
				ResizeMode = ResizeMode.NoResize;
				WindowStyle = WindowStyle.None;
				WindowState = WindowState.Maximized;
				Topmost = true;
			}
		}
	}
}
