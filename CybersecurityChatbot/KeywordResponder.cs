using System;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        // Store user's name
        private string userName = "";

        // Conversation stages
        private bool nameCaptured = false;
        private bool askedHowAreYou = false;
        private bool conversationStarted = false;

        // Sentiment detector object
        private SentimentDetector detector = new SentimentDetector();

        // ===================== MENU METHOD =====================

        private string GetMenu()
        {
            return "\n\nHere are some cybersecurity topics you can ask me about.Please type the word which you would like to learn about :\n\n" +

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

        // ===================== CHATBOT =====================

        public string GetResponse(string userMessage)
        {
            string message = userMessage.ToLower();

            // Exit application
            if (message == "0")
            {
                Environment.Exit(0);
            }

            // Detect sentiment
            Sentiment sentiment = detector.Detect(message);

            // Emotional response
            string emotionalResponse =
                detector.GetSentimentResponse(sentiment, userName);

            // ===================== STAGE 1 =====================
            // Capture user name

            if (!nameCaptured)
            {
                userName = userMessage;

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
                return "Cyber security is the practice of protecting computers, networks, and data from unauthorized access or attacks."
                       + GetMenu();
            }

            // Phishing
            else if (message.Contains("phishing"))
            {
                return "Phishing is a cyber attack that tricks people into revealing sensitive information like passwords or banking details."
                       + GetMenu();
            }

            // Malware
            else if (message.Contains("malware"))
            {
                return "Malware is harmful software designed to damage or exploit devices and networks."
                       + GetMenu();
            }

            // Ransomware
            else if (message.Contains("ransomware"))
            {
                return "Ransomware encrypts files and demands payment to restore access."
                       + GetMenu();
            }

            // Firewall
            else if (message.Contains("firewall"))
            {
                return "A firewall monitors and controls incoming and outgoing network traffic."
                       + GetMenu();
            }

            // VPN
            else if (message.Contains("vpn"))
            {
                return "A VPN creates a secure encrypted connection over the internet."
                       + GetMenu();
            }

            // Passwords
            else if (message.Contains("password"))
            {
                return "A strong password should include uppercase letters, lowercase letters, numbers, and symbols."
                       + GetMenu();
            }

            // Two-Factor Authentication
            else if (message.Contains("two-factor") ||
                     message.Contains("2fa"))
            {
                return "Two-factor authentication adds extra security by requiring another verification step."
                       + GetMenu();
            }

            // Personal Data
            else if (message.Contains("privacy") ||
                     message.Contains("personal data"))
            {
                return "Protect your personal data by avoiding suspicious links and using privacy settings."
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