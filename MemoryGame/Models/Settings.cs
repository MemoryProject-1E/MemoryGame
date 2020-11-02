using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MemoryGame.Models
{
	[Serializable]
	public class Settings
	{
		private const string CONFIG_FILE_PATH = "Settings.json";

		private static bool IsInitialized = false;
		private static int _gridSize = 4;
		private static int _themeCard;
		private static List<HighScore> _highScores;
		private static string _windowSetting;

		private static List<HighScore> DefaultHighScores = new List<HighScore>(); 

		public Settings()
		{
			if (!IsInitialized)
			{
				if (!File.Exists(CONFIG_FILE_PATH))
				{
					_themeCard = 1;
					_highScores = DefaultHighScores;
					_windowSetting = "Windowed";
					Write();
				}
				else
				{
					ConfigFile config = JObject.Parse(File.ReadAllText(CONFIG_FILE_PATH)).ToObject<ConfigFile>();
					_themeCard = config.ThemeCard;
					_highScores = config.HighScores;
					_windowSetting = config.WindowSetting;
				}
				IsInitialized = true;
			}
		}

		[JsonProperty]
		public int GridSize
		{
			get { return _gridSize; }
			set
			{
				_gridSize = value;
				Write();
			}
		}


		[JsonProperty]
		public string WindowSetting
		{
			get { return _windowSetting; }
			set
			{
				_windowSetting = value;
				Write();
			}
		}

		[JsonProperty]
		public int ThemeCard
		{
			get { return _themeCard; }
			set
			{
				_themeCard = value;
				Write();
			}
		}

		public void ResetSettings()
		{
			WindowSetting = "Windowed";
			ThemeCard = 1;
		}

		public bool RegisterHighScore(Player player)
		{

			if (player.Score > -1)
			{
				_highScores.Add(new HighScore
				{
					PlayerName = player.Name,
					Score = player.Score,
				});

				HighScores.RemoveAt(HighScores.Count - 1);
				Write();

				return true;
			}

			return false;
		}

		[JsonProperty]
		public List<HighScore> HighScores
		{
			get { return _highScores.OrderByDescending(a => a.Score).ToList(); }
			set
			{
				_highScores = value;
				Write();
			}
		}

		//Deze functie reset de highscore.
		public void ResetHighScores()
		{
			DefaultHighScores.Clear();
			HighScores = DefaultHighScores;
		}

		private void Write()
		{
			using (StreamWriter file = File.CreateText(CONFIG_FILE_PATH))
			{
				var serializer = new JsonSerializer();
				var config = new ConfigFile
				{
					ThemeCard = ThemeCard,
					HighScores = HighScores,
					WindowSetting = WindowSetting,
				};
				serializer.Serialize(file, config);
				file.Close();
			}
		}

		private class ConfigFile
		{
			public int ThemeCard { get; set; }
			public List<HighScore> HighScores { get; set; }
			public string WindowSetting  { get; set; }
		}
	}

	public class HighScore
	{
		public string PlayerName { get; set; }
		public int Score { get; set; }
	}
}
