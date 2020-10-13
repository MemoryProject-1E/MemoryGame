using System.Windows;
using System.Windows.Controls;
using System;
using System.IO;
using System.Text;


namespace MemoryGame.Pages
{
	public partial class Settings : Page
	{
		static string Path = "../Settings.txt";


		public Settings()
		{
			InitializeComponent();
			ApplyGridSize();
			if (!File.Exists(Path))
			{
				File.WriteAllText(Path, "4", Encoding.UTF8);
			}
		}

		private int GridSize
		{
			get { return Int32.Parse(File.ReadAllText(Path)); }
			set { File.WriteAllText(Path, value.ToString(), Encoding.UTF8); }
		} 

		private void ApplyGridSize()
		{
			GridSizeButton.Content = $"Grid Size: {GridSize}";
		}

		public void ChangeGridSize(object sender, RoutedEventArgs e)
		{

			if (GridSize == 2) GridSize = 4;
			else if (GridSize == 4) GridSize = 6;
			else GridSize = 2;


			ApplyGridSize();
		}

		public void GoBack(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainMenu());
		}
	}
}
