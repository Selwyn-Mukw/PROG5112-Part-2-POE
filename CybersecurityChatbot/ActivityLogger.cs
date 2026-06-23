using System;
using System.IO;

namespace CybersecurityChatbot
{
    public static class ActivityLogger
    {
        private const string LogFile = "activity.log";

        public static void Log(string message)
        {
            File.AppendAllText(
                LogFile,
                $"{DateTime.Now}: {message}\n");
        }
    }
}