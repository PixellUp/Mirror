using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mirror.Settings
{
    public class Settings
    {
        [JsonProperty("DatabaseLocation")]
        public static string DatabaseLocation { get; set; } = @".\bridge\LiteDB";
        [JsonProperty("DatabaseName")]
        public static string DatabaseFile { get; set; } = @"\LiteDatabase.db";
        [JsonProperty("StartupMessage")]
        public static string StartupMessage { get; set; } = "Welcome! Please use ~g~/register ~w~or ~b~/login";
        [JsonProperty("DisableTalentCommands")]
        public static bool DisableTalentCommands { get; set; } = false;
        [JsonProperty("TalentDivision")]
        public static int TalentDivision { get; set; } = 4;
        [JsonProperty("SpawnX")]
        public static int SpawnX { get; set; } = -1537;
        [JsonProperty("SpawnY")]
        public static int SpawnY { get; set; } = -942;
        [JsonProperty("SpawnZ")]
        public static int SpawnZ { get; set; } = 11;
        [JsonProperty("Hospital")]
        public static Tuple<double, double, double> HospitalLocation { get; set; } = new Tuple<double, double, double>(360, -585, 28);

        public static void Initialize()
        {
            if (!Directory.Exists(DatabaseLocation))
                Directory.CreateDirectory(DatabaseLocation);

            if (!File.Exists(DatabaseLocation + @"\mirror-settings.json"))
            {
                Console.WriteLine("[Mirror] Creating Mirror Settings. \r\n");
                SettingsHelper.SaveSettings();
            }

            SettingsHelper.LoadSettings();
            Console.WriteLine("[Mirror] Settings found, reading settings. \r\n");
        }
    }

    public class SettingsHelper
    {
        public static Settings Settings = new Settings();

        public static void SaveSettings()
        {
            string serialize = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(Settings.DatabaseLocation + @"\mirror-settings.json", serialize);
        }

        public static void LoadSettings()
        {
            string deserialize = File.ReadAllText(Settings.DatabaseLocation + @"\mirror-settings.json");
            Settings = JsonConvert.DeserializeObject<Settings>(deserialize);
        }
    }
}
