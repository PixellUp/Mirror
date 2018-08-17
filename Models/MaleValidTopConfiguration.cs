using LiteDbWrapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mirror.Models
{
   

    public class MaleValidTopConfiguration
    {
        public static List<MaleValidTopConfiguration> MaleValidTops = new List<MaleValidTopConfiguration>();

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
            string deserialize = File.ReadAllText(@".\bridge\resources\Mirror\bin\Debug\netcoreapp2.0\Datasets\MaleTopCombinations.json");
            MaleValidTops = JsonConvert.DeserializeObject<List<MaleValidTopConfiguration>>(deserialize);
        }

        public static void Create(int top, int torso, int undershirt)
        {

            MaleValidTopConfiguration config = new MaleValidTopConfiguration
            {
                Top = top,
                Torso = torso,
                Undershirt = undershirt
            };

            //Database.Upsert(config);
        }
    }
}
