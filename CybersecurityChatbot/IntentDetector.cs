using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class IntentDetector
    {
        private Dictionary<string, List<string>> intents =
            new Dictionary<string, List<string>>
        {
            {
                "AddTask",
                new List<string>
                {
                    "add task",
                    "add a task",
                    "create task",
                    "i need to",
                    "enable",
                    "set up"
                }
            },

            {
                "Reminder",
                new List<string>
                {
                    "remind me",
                    "reminder",
                    "set a reminder",
                    "remind me to",
                    "don't forget"
                }
            },

            {
                "Quiz",
                new List<string>
                {
                    "start quiz",
                    "take quiz",
                    "test my knowledge",
                    "quiz me",
                    "play the game"
                }
            },

            {
                "Log",
                new List<string>
                {
                    "show log",
                    "activity log",
                    "what have you done",
                    "what did you do",
                    "recent actions"
                }
            }
        };

        public string DetectIntent(string input)
        {
            input = input.ToLower();

            foreach (var intent in intents)
            {
                foreach (string phrase in intent.Value)
                {
                    if (input.Contains(phrase))
                        return intent.Key;
                }
            }

            return "None";
        }
    }
}