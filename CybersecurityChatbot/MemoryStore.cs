using System;
using System.Collections.Generic;
using System.IO;

namespace CybersecurityChatbot
{
    public class MemoryStore
    {
        // File path
        private readonly string filePath = "memory.txt";

        // User memory
        public string UserName { get; set; }

        public string FavouriteTopic { get; set; }

        // Dictionary memory
        private Dictionary<string, string> memory =
            new Dictionary<string, string>();

        // Constructor
        public MemoryStore()
        {
            LoadMemory();
        }

        // Store values
        public void Store(string key, string value)
        {
            if (memory.ContainsKey(key))
            {
                memory[key] = value;
            }
            else
            {
                memory.Add(key, value);
            }

            SaveMemory();
        }

        // Recall values
        public string Recall(string key)
        {
            if (memory.ContainsKey(key))
            {
                return memory[key];
            }

            return null;
        }

        // Personalized opener
        public string GetPersonalisedOpener()
        {
            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                return $"As someone interested in {FavouriteTopic}, ";
            }

            return "";
        }

        // ===================== SAVE MEMORY =====================

        private void SaveMemory()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var item in memory)
                {
                    lines.Add(item.Key + "=" + item.Value);
                }

                File.WriteAllLines(filePath, lines);
            }
            catch
            {
                // Ignore file errors
            }
        }

        // ===================== LOAD MEMORY =====================

        private void LoadMemory()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('=');

                        if (parts.Length == 2)
                        {
                            memory[parts[0]] = parts[1];
                        }
                    }

                    // Restore values
                    if (memory.ContainsKey("UserName"))
                    {
                        UserName = memory["UserName"];
                    }

                    if (memory.ContainsKey("FavouriteTopic"))
                    {
                        FavouriteTopic = memory["FavouriteTopic"];
                    }
                }
            }
            catch
            {
                // Ignore file errors
            }
        }
    }
}