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
		private static int _gridSize;
		private static List<HighScore> _highScores;
		private static string _windowSetting;

		private static List<HighScore> DefaultHighScores = new List<HighScore>()
		{

		}; 

		public Settings()
		{
			if (!IsInitialized)
			{
				if (!File.Exists(CONFIG_FILE_PATH))
				{
					_gridSize = 4;
					_highScores = DefaultHighScores;
					_windowSetting = "Windowed";
					Write();
				}
				else
				{
					ConfigFile config = JObject.Parse(File.ReadAllText(CONFIG_FILE_PATH)).ToObject<ConfigFile>();
					_gridSize = config.GridSize;
					_highScores = config.HighScores;
					_windowSetting = config.WindowSetting;
				}
				IsInitialized = true;
			}
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
		public List<HighScore> HighScores
		{
			get { return _highScores.OrderByDescending(a => a.Score).ToList(); }
			set
			{
				_highScores = value;
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

		public void ResetHighScores()
		{
			DefaultHighScores.Clear();
			HighScores = DefaultHighScores;
		}

		public void ResetSettings()
		{
			GridSize = 4;
			WindowSetting = "Windowed";
		}

		private void Write()
		{
			using (StreamWriter file = File.CreateText(CONFIG_FILE_PATH))
			{
				var serializer = new JsonSerializer();
				var config = new ConfigFile
				{
					GridSize = GridSize,
					HighScores = HighScores,
					WindowSetting = WindowSetting,
				};
				serializer.Serialize(file, config);
				file.Close();
			}
		}

		private class ConfigFile
		{
			public int GridSize { get; set; }
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
