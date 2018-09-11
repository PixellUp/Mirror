using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mirror.Models
{
    public class FemaleValidTopConfiguration
    {
        public static List<FemaleValidTopConfiguration> FemaleValidTops = new List<FemaleValidTopConfiguration>();

        [JsonProperty("_id")]
        public int ID { get; set; }
        [JsonProperty("Top")]
        public int Top { get; set; } = 0;
        [JsonProperty("Torso")]
        public int Torso { get; set; } = 0;
        [JsonProperty("Undershirt")]
        public int Undershirt { get; set; } = 0;

        public static void Initialize()
        {
            string deserialize = File.ReadAllText(@".\bridge\resources\Mirror\bin\Debug\netcoreapp2.0\Datasets\FemaleTopCombinations.json");
            FemaleValidTops = JsonConvert.DeserializeObject<List<FemaleValidTopConfiguration>>(deserialize);
        }

        public static void Create(int top, int torso, int undershirt)
        {
            FemaleValidTopConfiguration config = new FemaleValidTopConfiguration
            {
                Top = top,
                Torso = torso,
                Undershirt = undershirt
            };

            //Database.Upsert(config);
        }
    }
}
