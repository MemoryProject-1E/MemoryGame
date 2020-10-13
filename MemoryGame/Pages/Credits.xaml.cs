using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MemoryGame.Pages
{
	public partial class Credits : Page
	{
		public Credits()
		{
			InitializeComponent();
		}

		public void GoBack(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainMenu());
		}
	}
}
