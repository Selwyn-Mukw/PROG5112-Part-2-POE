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

        public string GetResponse(string userMessage)
        {
            string message = userMessage.ToLower();

            // ===================== STAGE 1 =====================
            // Capture User Name

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

                // SAD / NEGATIVE RESPONSES
                if (message.Contains("sad") ||
                    message.Contains("depressed") ||
                    message.Contains("upset") ||
                    message.Contains("stressed") ||
                    message.Contains("bad") ||
                    message.Contains("not okay"))
                {
                    return $"I am sorry to hear that {userName}. " +
                           $"Remember that difficult moments do not last forever.\n\n" +

                           "Sometimes online dangers like scams, cyberbullying, and hacked accounts can also affect people emotionally.\n\n" +

                           "I am here to help you stay safe online while also teaching you more about cybersecurity.\n\n" +

                           "Here are some topics we can explore together:\n\n" +

                           "- Cyber Security\n" +
                           "- Phishing\n" +
                           "- Malware\n" +
                           "- Ransomware\n" +
                           "- Firewalls\n" +
                           "- VPNs\n" +
                           "- Password Safety\n" +
                           "- Two-Factor Authentication\n" +
                           "- Personal Data Protection";
                }

                // HAPPY / POSITIVE RESPONSES
                else if (message.Contains("good") ||
                         message.Contains("great") ||
                         message.Contains("happy") ||
                         message.Contains("fine") ||
                         message.Contains("awesome"))
                {
                    return $"That is wonderful to hear {userName}!\n\n" +

                           "I am here to assist you with cybersecurity safety and awareness.\n\n" +

                           "Here are some cybersecurity topics you can ask me about:\n\n" +

                           "- Cyber Security\n" +
                           "- Phishing\n" +
                           "- Malware\n" +
                           "- Ransomware\n" +
                           "- Firewalls\n" +
                           "- VPNs\n" +
                           "- Password Safety\n" +
                           "- Two-Factor Authentication\n" +
                           "- Personal Data Protection";
                }

                // DEFAULT RESPONSE
                else
                {
                    return $"Thank you for sharing {userName}.\n\n" +

                           "I am here to help you learn about cybersecurity and online safety.\n\n" +

                           "Here are some topics you can ask me about:\n\n" +

                           "- Cyber Security\n" +
                           "- Phishing\n" +
                           "- Malware\n" +
                           "- Ransomware\n" +
                           "- Firewalls\n" +
                           "- VPNs\n" +
                           "- Password Safety\n" +
                           "- Two-Factor Authentication\n" +
                           "- Personal Data Protection";
                }
            }

            // ===================== CHATBOT RESPONSES =====================

            // Greetings
            if (message == "hello" ||
                message == "hi" ||
                message == "hey")
            {
                return $"Hello {userName}! How can I help you today?";
            }

            // Cyber Security
            else if (message.Contains("cyber security") ||
                     message.Contains("cybersecurity"))
            {
                return "Cyber security is the practice of protecting computers, networks, and data from unauthorized access or attacks.";
            }

            // Phishing
            else if (message.Contains("phishing"))
            {
                return "Phishing is a cyber attack that tricks people into revealing sensitive information like passwords or credit card details.";
            }

            // Malware
            else if (message.Contains("malware"))
            {
                return "Malware is harmful software designed to damage or exploit devices and networks.";
            }

            // Ransomware
            else if (message.Contains("ransomware"))
            {
                return "Ransomware encrypts files and demands payment to restore access.";
            }

            // Firewall
            else if (message.Contains("firewall"))
            {
                return "A firewall monitors and controls incoming and outgoing network traffic.";
            }

            // VPN
            else if (message.Contains("vpn"))
            {
                return "A VPN creates a secure encrypted connection over the internet.";
            }

            // Passwords
            else if (message.Contains("password"))
            {
                return "A strong password should contain uppercase letters, lowercase letters, numbers, and symbols and be at least 12 characters long.";
            }

            // Two-Factor Authentication
            else if (message.Contains("two-factor") ||
                     message.Contains("2fa") ||
                     message.Contains("authentication"))
            {
                return "Two-factor authentication adds extra security by requiring another verification method.";
            }

            // Personal Data
            else if (message.Contains("personal data") ||
                     message.Contains("privacy"))
            {
                return "Protect your personal data by using privacy settings and avoiding suspicious links.";
            }

            // Cyber Attacks
            else if (message.Contains("cyber attack") ||
                     message.Contains("protect"))
            {
                return "To protect yourself online, keep software updated, avoid suspicious links, and use antivirus software.";
            }

            // Thanks
            else if (message.Contains("thank"))
            {
                return $"You are welcome {userName}! Stay safe online.";
            }

            // Goodbye
            else if (message.Contains("bye"))
            {
                return $"Goodbye {userName}! Stay safe online.";
            }

            // Default
            else
            {
                return "Sorry, I don't understand that yet. Please ask a cybersecurity-related question.";
            }
        }
    }
}