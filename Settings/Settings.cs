using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wrapper = LiteDbWrapper;

namespace Mirror.Settings
{
    public class Settings
    {
        [JsonProperty("DatabaseLocation")]
        public static string DatabaseLocation { get; set; } = Wrapper.Settings.DatabaseLocation;
        [JsonProperty("StartupMessage")]
        public static string StartupMessage { get; set; } = "Welcome! Please use ~g~/register ~w~or ~b~/login";
        [JsonProperty("DisableTalentCommands")]
        public static bool DisableTalentCommands { get; set; } = false;
        [JsonProperty("TalentDivision")]
        public static int TalentDivision { get; set; } = 4;

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
