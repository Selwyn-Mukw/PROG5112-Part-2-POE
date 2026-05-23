using System;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        public string GetResponse(string userMessage)
        {
            string message = userMessage.ToLower();

            // Greetings
            if (message.Contains("hello") ||
                message.Contains("hi") ||
                message.Contains("hey"))
            {
                return "Hello! Welcome to the Cyber Security Hub. Ask me anything about cybersecurity.";
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
                return "You are welcome! Stay safe online.";
            }

            // Goodbye
            else if (message.Contains("bye"))
            {
                return "Goodbye! Stay safe online.";
            }

            // Default Response
            else
            {
                return "Sorry, I don't understand that yet. Please ask a cybersecurity-related question.";
            }
        }
    }
}