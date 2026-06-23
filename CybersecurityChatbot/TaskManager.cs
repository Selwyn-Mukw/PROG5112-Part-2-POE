using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    public class TaskManager
    {
        private TaskStorageHelper storage;

        public TaskManager()
        {
            storage = new TaskStorageHelper();
        }

        public string AddTask(string title,
                              string description,
                              string reminder)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            int newId = tasks.Count == 0
                ? 1
                : tasks.Max(t => t.Id) + 1;

            tasks.Add(new CyberTask
            {
                Id = newId,
                Title = title,
                Description = description,
                Reminder = reminder,
                IsComplete = false
            });

            storage.SaveTasks(tasks);

            ActivityLogger.Log($"Task Added: {title}");

            return "Task added successfully.";
        }

        public List<CyberTask> GetAllTasks()
        {
            return storage.LoadTasks();
        }

        public void MarkAsComplete(int id)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            CyberTask task =
                tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.IsComplete = true;

                storage.SaveTasks(tasks);

                ActivityLogger.Log(
                    $"Task Completed: {task.Title}");
            }
        }

        public void DeleteTask(int id)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            tasks.RemoveAll(t => t.Id == id);

            storage.SaveTasks(tasks);

            ActivityLogger.Log(
                $"Task Deleted: {id}");
        }
    }
}