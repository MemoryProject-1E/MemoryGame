﻿using System.Windows;
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
				return Window.GetWindow(this);	
			}
		}

		public void Close(object sender, RoutedEventArgs e)
		{
			SettingsWindow.Close();
		}

		public void GoToMainMenu(object sender, RoutedEventArgs e)
		{
			var window = (MainWindow)Application.Current.MainWindow;
			window.GoToMainMenu();

			SettingsWindow.Close();
		}

		public void Exit(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
