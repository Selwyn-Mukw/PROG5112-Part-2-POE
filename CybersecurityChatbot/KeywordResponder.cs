using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> _responses;
        private Random _random = new Random();

        public KeywordResponder()
        {
            _responses = new Dictionary<string, List<string>>()
            {
                {
                    "password",
                    new List<string>()
                    {
                        "Use strong passwords with symbols and numbers.",
                        "Avoid using personal information in passwords."
                    }
                },

                {
                    "phishing",
                    new List<string>()
                    {
                        "Do not click suspicious email links.",
                        "Always verify who sent the email."
                    }
                },

                {
                    "privacy",
                    new List<string>()
                    {
                        "Review your privacy settings regularly.",
                        "Avoid sharing sensitive information online."
                    }
                },

                {
                    "scam",
                    new List<string>()
                    {
                        "Be careful of offers that seem too good to be true.",
                        "Never send money to strangers online."
                    }
                },

                {
                    "malware",
                    new List<string>()
                    {
                        "Install trusted antivirus software.",
                        "Keep your computer updated."
                    }
                }
            };
        }

        public string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var keyword in _responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    List<string> possibleResponses = _responses[keyword];

                    int index = _random.Next(possibleResponses.Count);

                    return possibleResponses[index];
                }
            }

            return "I can help with passwords, phishing, privacy, scams, and malware.";
        }
    }
}