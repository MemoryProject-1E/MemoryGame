using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MemoryGame.Models;

namespace MemoryGame.Pages
{
	public partial class Game : Page
	{
		private Player[] Players;
		private TileGrid GridData;
		private int CurrentPlayerIndex = 0;
		private (int x, int y) RevealedTileCoords = (-1, -1);
		private Window SettingsWindow = new Window();

		public Game(Player[] players)
		{
			Players = players;
			InitializeComponent();
			GridData = new TileGrid {
				Players = Players,
				GridSize = 4,
				Element = TileGridEl,
			};
			UpdatePlayerScore(Players[0]);
			UpdatePlayerScore(Players[1]);
			SettingsWindow.Style = Application.Current.TryFindResource("SettingsWindow") as Style;
		}

		public void OpenSettings(object sender, RoutedEventArgs e)
		{
			SettingsWindow = new Window();
			SettingsWindow.Show();
		}

		private void UpdatePlayerScore(Player player)
		{
			var isPlayerOne = player == Players[0];
			TextBlock textElement = isPlayerOne ? PlayerOneScoreText : PlayerTwoScoreText;
			StackPanel indicators = isPlayerOne ? PlayerOneScoreIndicators : PlayerTwoScoreIndicators;
			textElement.Text = $"{player.Name}: {player.Score}";
			for (var i = 0; i < indicators.Children.Count; i += 1)
			{
				StackPanel indicator = indicators.Children[i] as StackPanel;
				indicator.Background = i <= player.Score ? Constants.COLOR_PURPLE : Brushes.Transparent;
			}
		}

		private Player CurrentPlayer => Players[CurrentPlayerIndex];

		private Tile RevealedTile => RevealedTileCoords.x == -1
			? null
			: GridData.Tiles[RevealedTileCoords.x, RevealedTileCoords.y];

		public void OnTileClick(object sender, RoutedEventArgs e)
		{
			Button tileButton = e.Source as Button;
			int x = Grid.GetColumn(tileButton);
			int y = Grid.GetRow(tileButton);
			Tile tile = GridData.Tiles[x, y];

			// Ignore clicks on already revealed tiles
			if (!tile.IsRevealed)
			{
				tile.Reveal();

				// First tile
				if (RevealedTile == null)
				{
					RevealedTileCoords = (x, y);
				}

				// No match
				else if (tile.Type != RevealedTile.Type)
				{
					tile.Hide();
					RevealedTile.Hide();
					RevealedTileCoords = (-1, -1);
					NextPlayer();
				}

				// Match
				else
				{
					CurrentPlayer.ApplyScore(tile.Type);

					tile.IsMatched = true;
					RevealedTile.IsMatched = true;
					RevealedTileCoords = (-1, -1);
				}
			}
		}

		private void NextPlayer()
		{
			CurrentPlayerIndex = CurrentPlayerIndex == 0 ? 1 : 0;
		}
	}
}
