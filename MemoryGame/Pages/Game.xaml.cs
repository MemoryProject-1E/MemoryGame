using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class Game : Page
	{

		const int NR_OF_ROWS = 4;
		const int NR_OF_COLUMNS = 4;
		const int SIZE = 100;

		private int[,] StatusOfCard = new int[NR_OF_ROWS, NR_OF_COLUMNS];
		private Rectangle[,] Card = new Rectangle[NR_OF_ROWS, NR_OF_COLUMNS];
		private static Random rng = new Random();

		public Game()
		{
			InitializeComponent();
			CreateBoard();
			Randomize();
			Pogger();
		}


		private void CreateBoard()
		{
			for (int i = 0; i < NR_OF_ROWS; i++)
			{
				ConnectMemorieGame.RowDefinitions.Add(new RowDefinition());
			}
			for (int i = 0; i < NR_OF_COLUMNS; i++)
			{
				ConnectMemorieGame.ColumnDefinitions.Add(new ColumnDefinition());
			}
		}

		


		private void Randomize()
		{
			List<int> List = new List<int>
			{ 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
			List.Shuffle();

			
			Random rnd = new Random();
			int PickedNumber = 0;
			int Number = 0;

			for (int r = 0; r < NR_OF_ROWS; r++)
			{
				for (int c = 0; c < NR_OF_COLUMNS; c++)
				{
					PickedNumber = List[Number];
					StatusOfCard[r, c] = PickedNumber;
					Number++;
				}
			}
		}




		private void Pogger()
		{
			for (int r = 0; r < NR_OF_ROWS; r++)
			{
				for (int c = 0; c < NR_OF_COLUMNS; c++)
				{
					Rectangle Card = new Rectangle();
					Card.Fill = Brushes.Aqua;
					Card.Width = SIZE;
					Card.Height = SIZE;
					//Card.MouseEnter += Card_MouseEnter;
					//Card.MouseLeave += Card_MouseLeave;
					Card.Tag = c;
					Card.Tag = r;
					Card.MouseDown += Card_MouseDown;
					Grid.SetColumn(Card, c);
					Grid.SetRow(Card, r);
					ConnectMemorieGame.Children.Add(Card);

				}
			}
		}

		private void Card_MouseEnter(object sender, MouseEventArgs e)
		{
			((Rectangle)sender).Fill = Brushes.Gray;
		} 

		private void Card_MouseLeave(object sender, MouseEventArgs e)
		{
			((Rectangle)sender).Fill = Brushes.Aqua;
		}

		private void Card_MouseDown(object sender, MouseEventArgs e)
		{
			int column = (int)((Rectangle)sender).Tag;
			int row = (int)((Rectangle)sender).Tag;

			if (StatusOfCard[row, column] == 0)
				((Rectangle)sender).Fill = Brushes.Red;

			else if (StatusOfCard[row, column] == 1)
				((Rectangle)sender).Fill = Brushes.Pink;

			else if (StatusOfCard[row, column] == 2)
				((Rectangle)sender).Fill = Brushes.Purple;

			else if (StatusOfCard[row, column] == 3)
				((Rectangle)sender).Fill = Brushes.Yellow;

			else if (StatusOfCard[row, column] == 4)
				((Rectangle)sender).Fill = Brushes.Green;

			else if (StatusOfCard[row, column] == 5)
				((Rectangle)sender).Fill = Brushes.Gray;

			else if (StatusOfCard[row, column] == 6)
				((Rectangle)sender).Fill = Brushes.Black;

			else if (StatusOfCard[row, column] == 7)
				((Rectangle)sender).Fill = Brushes.Silver;

		}
	}
}

	
