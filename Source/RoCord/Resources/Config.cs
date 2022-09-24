using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RoCord
{
    class Config
    {
        public string token { get; set; }

        public static void Create()
        {
            Directory.CreateDirectory("bin/");
            List<Config> Json = new List<Config>();
            using (FileStream FileStream = File.Create("bin/config.json"))
            Json.Add(new Config()
            {
                token = ""
            });
            File.WriteAllText("bin/config.json", JsonConvert.SerializeObject(Json, Formatting.Indented));
            Index.DownloadVMP();
            Directory.CreateDirectory(Index.ScriptsDirectory);
            Directory.CreateDirectory(Index.AutoExecuteDirectory);
        }

        public static void Write(string key, dynamic value)
        {
            dynamic JsonFile = JsonConvert.DeserializeObject(File.ReadAllText("bin/config.json"));
            JsonFile[0][key] = value;
            File.WriteAllText("bin/config.json", JsonConvert.SerializeObject(JsonFile, Formatting.Indented));
        }

        public static dynamic Read(string key)
        {
            dynamic JsonFile = JsonConvert.DeserializeObject(File.ReadAllText("bin/config.json"));
            return JsonFile[0][key];
        }
    }
}