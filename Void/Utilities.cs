using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections;

namespace Void
{
    public class Utilities
    {
        private static Dictionary<string, string> alerts;
        private static Dictionary<string, string> quotes;
        private const string memoryFolder = "SystemLang";
        private const string memoryFile = "memory.json";
        private static string selection;

        public static Dictionary<string, string> memories;

        Random r = new Random();

        public Utilities()
        {
            string json = File.ReadAllText("SystemLang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alerts = data.ToObject<Dictionary<string, string>>();
            json = File.ReadAllText("SystemLang/tomquotes.json");
            data = JsonConvert.DeserializeObject<dynamic>(json);
            quotes = data.ToObject<Dictionary<string, string>>();

            json = File.ReadAllText("SystemLang/memory.json");
            data = JsonConvert.DeserializeObject<dynamic>(json);
            memories = data.ToObject<Dictionary<string, string>>();
        }

        internal string GetQuote()
        {
            int intSelection = r.Next(memories.Count);
            selection = memories[intSelection.ToString()];
            return selection;
        }

        public string GetAlert(string key)
        {
            if (alerts.ContainsKey(key))
            {
                return alerts[key];
            }
            return "";
        }

        public void SetRememberQuote(string quote)
        {
            memories.Add((Convert.ToInt32(memories.Last().Key) + 1).ToString(), quote);

            string json = JsonConvert.SerializeObject(memories);
            File.WriteAllText(memoryFolder + "/" + memoryFile, json);

            json = File.ReadAllText("SystemLang/memory.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            memories = data.ToObject<Dictionary<string, string>>();
        }

        public string GetTomQuote()
        {
            int intSelection = r.Next(quotes.Count);
            selection = quotes[intSelection.ToString()];
            return selection;
        }
        
    }
}