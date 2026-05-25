using System;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        // Store user's name
        private string userName;

        // Conversation stages
        private bool nameCaptured = false;
        private bool askedHowAreYou = false;
        private bool conversationStarted = false;

        // Sentiment detector object
        private SentimentDetector detector = new SentimentDetector();

        // Memory storage object
        private MemoryStore memory = new MemoryStore();

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

        // ===================== CONSTRUCTOR =====================

        public KeywordResponder()
        {
            // Load saved favourite topic only
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

            // ===================== EXIT APPLICATION =====================

            if (message == "0")
            {
                Environment.Exit(0);
            }

            // ===================== DETECT SENTIMENT =====================

            Sentiment sentiment = detector.Detect(message);

            string emotionalResponse =
                detector.GetSentimentResponse(sentiment, userName);

            // ===================== STAGE 1 =====================
            // Capture user name

            if (!nameCaptured)
            {
                userName = userMessage;

                // Check if returning user
                string savedName = memory.Recall("UserName");

                if (!string.IsNullOrEmpty(savedName) &&
                    savedName.ToLower() == userName.ToLower())
                {
                    // Restore previous user
                    memory.UserName = savedName;

                    nameCaptured = true;
                    conversationStarted = true;

                    return $"Welcome back {userName}! " +

                           memory.GetPersonalisedOpener() +

                           "ready to continue learning about cybersecurity?"

                           + GetMenu();
                }

                // ===================== NEW USER =====================

                memory.UserName = userName;
                memory.Store("UserName", userName);

                nameCaptured = true;
                askedHowAreYou = true;

                return $"Hello {userName}! How are you today?";
            }

            // ===================== STAGE 2 =====================
            // User responds to "How are you?"

            if (askedHowAreYou && !conversationStarted)
            {
                conversationStarted = true;

                return emotionalResponse + GetMenu();
            }

            // ===================== STORE FAVOURITE TOPIC =====================

            if (message.Contains("interested in"))
            {
                if (message.Contains("privacy"))
                {
                    memory.FavouriteTopic = "privacy";
                    memory.Store("FavouriteTopic", "privacy");

                    return $"Great choice {userName}! I will remember that you are interested in privacy."
                           + GetMenu();
                }

                else if (message.Contains("phishing"))
                {
                    memory.FavouriteTopic = "phishing";
                    memory.Store("FavouriteTopic", "phishing");

                    return $"Great choice {userName}! I will remember that you are interested in phishing."
                           + GetMenu();
                }

                else if (message.Contains("malware"))
                {
                    memory.FavouriteTopic = "malware";
                    memory.Store("FavouriteTopic", "malware");

                    return $"Great choice {userName}! I will remember that you are interested in malware."
                           + GetMenu();
                }

                else if (message.Contains("vpn"))
                {
                    memory.FavouriteTopic = "VPNs";
                    memory.Store("FavouriteTopic", "VPNs");

                    return $"Great choice {userName}! I will remember that you are interested in VPNs."
                           + GetMenu();
                }
            }

            // ===================== CHATBOT RESPONSES =====================

            // Greetings
            if (message == "hello" ||
                message == "hi" ||
                message == "hey")
            {
                return $"Hello {userName}! How can I help you today?"
                       + GetMenu();
            }

            // Cyber Security
            else if (message.Contains("cyber security") ||
                     message.Contains("cybersecurity"))
            {
                return memory.GetPersonalisedOpener() +

                       "Cyber security is the practice of protecting computers, networks, and data from unauthorized access or attacks."

                       + GetMenu();
            }

            // Phishing
            else if (message.Contains("phishing"))
            {
                return memory.GetPersonalisedOpener() +

                       "Phishing is a cyber attack that tricks people into revealing sensitive information like passwords or banking details."

                       + GetMenu();
            }

            // Malware
            else if (message.Contains("malware"))
            {
                return memory.GetPersonalisedOpener() +

                       "Malware is harmful software designed to damage or exploit devices and networks."

                       + GetMenu();
            }

            // Ransomware
            else if (message.Contains("ransomware"))
            {
                return memory.GetPersonalisedOpener() +

                       "Ransomware encrypts files and demands payment to restore access."

                       + GetMenu();
            }

            // Firewall
            else if (message.Contains("firewall"))
            {
                return memory.GetPersonalisedOpener() +

                       "A firewall monitors and controls incoming and outgoing network traffic."

                       + GetMenu();
            }

            // VPN
            else if (message.Contains("vpn"))
            {
                return memory.GetPersonalisedOpener() +

                       "A VPN creates a secure encrypted connection over the internet."

                       + GetMenu();
            }

            // Passwords
            else if (message.Contains("password"))
            {
                return memory.GetPersonalisedOpener() +

                       "A strong password should include uppercase letters, lowercase letters, numbers, and symbols."

                       + GetMenu();
            }

            // Two-Factor Authentication
            else if (message.Contains("two-factor") ||
                     message.Contains("2fa"))
            {
                return memory.GetPersonalisedOpener() +

                       "Two-factor authentication adds extra security by requiring another verification step."

                       + GetMenu();
            }

            // Personal Data
            else if (message.Contains("privacy") ||
                     message.Contains("personal data"))
            {
                return memory.GetPersonalisedOpener() +

                       "Protect your personal data by avoiding suspicious links and using privacy settings."

                       + GetMenu();
            }

            // Thanks
            else if (message.Contains("thank"))
            {
                return $"You are welcome {userName}! Stay safe online."
                       + GetMenu();
            }

            // Goodbye
            else if (message.Contains("bye"))
            {
                return $"Goodbye {userName}! Stay safe online."
                       + GetMenu();
            }

            // Default
            else
            {
                return "Sorry, I don't understand that yet. Please ask a cybersecurity-related question."
                       + GetMenu();
            }
        }
    }
}