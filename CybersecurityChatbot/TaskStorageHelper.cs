using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CybersecurityChatbot
{
    public class TaskStorageHelper
    {
        private const string FileName = "tasks.json";

        public List<CyberTask> LoadTasks()
        {
            if (!File.Exists(FileName))
                return new List<CyberTask>();

            string json = File.ReadAllText(FileName);

            return JsonSerializer.Deserialize<List<CyberTask>>(json)
                   ?? new List<CyberTask>();
        }

        public void SaveTasks(List<CyberTask> tasks)
        {
            string json = JsonSerializer.Serialize(tasks,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(FileName, json);
        }
    }
}