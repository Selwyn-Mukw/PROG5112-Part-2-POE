using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        // ===================== VARIABLES =====================

        // Store user's name
        private string userName;

        // Conversation stages
        private bool nameCaptured = false;
        private bool askedHowAreYou = false;
        private bool conversationStarted = false;

        // Count topic requests
        private int topicCounter = 0;

        // Random object
        private Random random = new Random();

        // Sentiment detector object
        private SentimentDetector detector = new SentimentDetector();

        // Memory storage object
        private MemoryStore memory = new MemoryStore();

        // ===================== RANDOM RESPONSES =====================

        private Dictionary<string, string[]> responses =
            new Dictionary<string, string[]>()
        {
            {
                "cybersecurity",
                new string[]
                {
                    "Cyber security protects computers, networks, and data from cyber attacks.",
                    "Cyber security involves keeping systems safe from hackers and malicious software.",
                    "Cyber security focuses on protecting digital information and online systems."
                }
            },

            {
                "phishing",
                new string[]
                {
                    "Phishing tricks users into giving away sensitive information through fake emails or websites.",
                    "Phishing attacks often pretend to be trusted companies to steal passwords or banking details.",
                    "Be careful of suspicious links because phishing scams are designed to steal personal information."
                }
            },

            {
                "malware",
                new string[]
                {
                    "Malware is harmful software created to damage or exploit devices.",
                    "Viruses, worms, and trojans are all examples of malware.",
                    "Malware can steal data, slow down computers, or give hackers access to your system."
                }
            },

            {
                "ransomware",
                new string[]
                {
                    "Ransomware locks or encrypts files until money is paid to attackers.",
                    "A ransomware attack can prevent users from accessing important data.",
                    "Always back up important files to protect yourself from ransomware attacks."
                }
            },

            {
                "firewall",
                new string[]
                {
                    "A firewall filters incoming and outgoing network traffic for security.",
                    "Firewalls help block unauthorized access to devices and networks.",
                    "Using a firewall adds an extra layer of protection against cyber threats."
                }
            },

            {
                "vpn",
                new string[]
                {
                    "A VPN encrypts your internet connection for better privacy.",
                    "VPNs help protect your data when using public Wi-Fi.",
                    "Using a VPN can hide your IP address and improve online security."
                }
            },

            {
                "password",
                new string[]
                {
                    "Strong passwords should contain letters, numbers, and symbols.",
                    "Avoid using easy passwords like your name or birthdate.",
                    "Using unique passwords for every account improves security."
                }
            },

            {
                "2fa",
                new string[]
                {
                    "Two-factor authentication adds an extra verification step during login.",
                    "2FA improves account security by requiring a second form of authentication.",
                    "Even if a password is stolen, 2FA can help prevent unauthorized access."
                }
            },

            {
                "privacy",
                new string[]
                {
                    "Protect your personal data by avoiding suspicious links and websites.",
                    "Privacy settings can help control who sees your personal information online.",
                    "Never share sensitive information on unsecured websites."
                }
            }
        };

        // ===================== RANDOM RESPONSE METHOD =====================

        private string GetRandomResponse(string category)
        {
            string[] categoryResponses = responses[category];

            int index = random.Next(categoryResponses.Length);

            return categoryResponses[index];
        }

        // ===================== MENU METHOD =====================

        private string GetMenu()
        {
            return "\n\nHere are some cybersecurity topics you can ask me about. Please type the topic you would like to learn about:\n\n" +

                   "1- Cyber Security\n" +
                   "2- Phishing\n" +
                   "3- Malware\n" +
                   "4- Ransomware\n" +
                   "5- Firewalls\n" +
                   "6- VPNs\n" +
                   "7- Password Safety\n" +
                   "8- Two-Factor Authentication\n" +
                   "9- Personal Data Protection\n\n" +

                   "Press 0 to exit the application.";
        }

        // ===================== USER INTEREST METHOD =====================

        private string CheckTopicInterest()
        {
            if (topicCounter >= 3)
            {
                return $"\n\n{userName}, you seem to really be enjoying cyber security!"
                       + GetMenu();
            }

            return GetMenu();
        }

        // ===================== CONSTRUCTOR =====================

        public KeywordResponder()
        {
            memory.FavouriteTopic =
                memory.Recall("FavouriteTopic");
        }

        // ===================== RETURN SAVED USER =====================

        public string GetSavedUserName()
        {
            return userName;
        }

        // ===================== CHATBOT =====================

        public string GetResponse(string userMessage)
        {
            string message = userMessage.ToLower();

            // ===================== EXIT =====================

            if (message == "0")
            {
                Environment.Exit(0);
            }

            // ===================== SENTIMENT =====================

            Sentiment sentiment = detector.Detect(message);

            string emotionalResponse =
                detector.GetSentimentResponse(sentiment, userName);

            // ===================== CAPTURE NAME =====================

            if (!nameCaptured)
            {
                userName = userMessage;

                string savedName = memory.Recall("UserName");

                // Returning user
                if (!string.IsNullOrEmpty(savedName) &&
                    savedName.ToLower() == userName.ToLower())
                {
                    memory.UserName = savedName;

                    nameCaptured = true;
                    conversationStarted = true;

                    return $"Welcome back {userName}! " +
                           memory.GetPersonalisedOpener() +
                           "ready to continue learning about cybersecurity?"
                           + GetMenu();
                }

                // New user
                memory.UserName = userName;
                memory.Store("UserName", userName);

                nameCaptured = true;
                askedHowAreYou = true;

                return $"Hello {userName}! How are you today?";
            }

            // ===================== HOW ARE YOU =====================

            if (askedHowAreYou && !conversationStarted)
            {
                conversationStarted = true;

                return emotionalResponse + GetMenu();
            }

            // ===================== CYBER SECURITY =====================

            if (message.Contains("cyber security") ||
                message.Contains("cybersecurity"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("cybersecurity")
                       + CheckTopicInterest();
            }

            // ===================== PHISHING =====================

            else if (message.Contains("phishing"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("phishing")
                       + CheckTopicInterest();
            }

            // ===================== MALWARE =====================

            else if (message.Contains("malware"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("malware")
                       + CheckTopicInterest();
            }

            // ===================== RANSOMWARE =====================

            else if (message.Contains("ransomware"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("ransomware")
                       + CheckTopicInterest();
            }

            // ===================== FIREWALL =====================

            else if (message.Contains("firewall"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("firewall")
                       + CheckTopicInterest();
            }

            // ===================== VPN =====================

            else if (message.Contains("vpn"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("vpn")
                       + CheckTopicInterest();
            }

            // ===================== PASSWORD =====================

            else if (message.Contains("password"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("password")
                       + CheckTopicInterest();
            }

            // ===================== 2FA =====================

            else if (message.Contains("two-factor") ||
                     message.Contains("2fa"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("2fa")
                       + CheckTopicInterest();
            }

            // ===================== PRIVACY =====================

            else if (message.Contains("privacy") ||
                     message.Contains("personal data"))
            {
                topicCounter++;

                return memory.GetPersonalisedOpener() +
                       GetRandomResponse("privacy")
                       + CheckTopicInterest();
            }

            // ===================== THANKS =====================

            else if (message.Contains("thank"))
            {
                return $"You are welcome {userName}! Stay safe online."
                       + GetMenu();
            }

            // ===================== GOODBYE =====================

            else if (message.Contains("bye"))
            {
                return $"Goodbye {userName}! Stay safe online."
                       + GetMenu();
            }

            // ===================== DEFAULT =====================

            else
            {
                return "Sorry, I don't understand that yet. Please ask a cybersecurity-related question."
                       + GetMenu();
            }
        }
    }
}