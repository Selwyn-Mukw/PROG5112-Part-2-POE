using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class QuizManager
    {
        private List<QuizQuestion> _questions;

        private int _currentIndex = 0;

        private int _score = 0;

        public QuizManager()
        {
            _questions = new List<QuizQuestion>();

            LoadQuestions();
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (_currentIndex >= _questions.Count)
            {
                return null;
            }

                return _questions[_currentIndex];


}
        public void MoveNextQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                _currentIndex++;
            }
        }

        public bool IsLastQuestion()
        {
            return _currentIndex >= _questions.Count - 1;
        }

        public bool SubmitAnswer(string answer)
        {
            bool correct =
                answer == _questions[_currentIndex].CorrectAnswer;

            if (correct)
                _score++;

            return correct;
        }

       



        public bool IsFinished()
        {
            return _currentIndex >= _questions.Count;
        }

        public int GetScore()
        {
            return _score;
        }

        public int TotalQuestions()
        {
            return _questions.Count;
        }

        public void ResetQuiz()
        {
            _currentIndex = 0;
            _score = 0;
        }

        private void LoadQuestions()
        {
            // questions go here
            _questions.Add(new QuizQuestion
            {
                Question = "What should you do if you receive an email asking for your password?",
                Options = new List<string>
    {
        "Reply with your password",
        "Delete the email",
        "Report the email as phishing",
        "Ignore it"
    },
                CorrectAnswer = "Report the email as phishing",
                Explanation = "Reporting phishing emails helps prevent scams.",
                IsTrueFalse = false
            });
            _questions.Add(new QuizQuestion
            {
                Question = "Which password is the strongest?",
                Options = new List<string>
    {
        "123456",
        "Password123",
        "Qwerty",
        "T#9vP!2xL@7z"
    },
                CorrectAnswer = "T#9vP!2xL@7z",
                Explanation = "Strong passwords use a mix of letters, numbers, and symbols.",
                IsTrueFalse = false
            });

            _questions.Add(new QuizQuestion
            {
                Question = "You should use the same password for all your accounts.",
                Options = new List<string>
    {
        "True",
        "False"
    },
                CorrectAnswer = "False",
                Explanation = "Using unique passwords reduces risk if one account is compromised.",
                IsTrueFalse = true
            });

            _questions.Add(new QuizQuestion
            {
                Question = "What does HTTPS indicate?",
                Options = new List<string>
    {
        "The website is encrypted",
        "The website is fake",
        "The website is free",
        "The website has no security"
    },
                CorrectAnswer = "The website is encrypted",
                Explanation = "HTTPS encrypts data between your browser and the website.",
                IsTrueFalse = false
            });

            _questions.Add(new QuizQuestion
            {
                Question = "Which is an example of social engineering?",
                Options = new List<string>
    {
        "Installing antivirus software",
        "Tricking someone into revealing a password",
        "Updating Windows",
        "Creating backups"
    },
                CorrectAnswer = "Tricking someone into revealing a password",
                Explanation = "Social engineering manipulates people into giving away information.",
                IsTrueFalse = false
            });

            _questions.Add(new QuizQuestion
            {
                Question = "What is the purpose of two-factor authentication (2FA)?",
                Options = new List<string>
    {
        "To make passwords shorter",
        "To add an extra layer of security",
        "To remove passwords",
        "To increase internet speed"
    },
                CorrectAnswer = "To add an extra layer of security",
                Explanation = "2FA requires an additional verification step.",
                IsTrueFalse = false
            });

            _questions.Add(new QuizQuestion
            {
                Question = "Malware is software designed to harm a computer system.",
                Options = new List<string>
    {
        "True",
        "False"
    },
                CorrectAnswer = "True",
                Explanation = "Malware includes viruses, worms, trojans, and spyware.",
                IsTrueFalse = true
            });

            _questions.Add(new QuizQuestion
            {
                Question = "Ransomware usually does what?",
                Options = new List<string>
    {
        "Improves computer performance",
        "Encrypts files and demands payment",
        "Deletes antivirus software only",
        "Updates security settings"
    },
                CorrectAnswer = "Encrypts files and demands payment",
                Explanation = "Ransomware locks data and demands money to restore access.",
                IsTrueFalse = false
            });

            _questions.Add(new QuizQuestion
            {
                Question = "Why should you regularly review your privacy settings?",
                Options = new List<string>
    {
        "To share more personal information",
        "To control who can access your data",
        "To speed up your computer",
        "To disable antivirus software"
    },
                CorrectAnswer = "To control who can access your data",
                Explanation = "Privacy settings help protect personal information.",
                IsTrueFalse = false
            });

            _questions.Add(new QuizQuestion
            {
                Question = "Backing up your data helps protect against data loss.",
                Options = new List<string>
    {
        "True",
        "False"
    },
                CorrectAnswer = "True",
                Explanation = "Backups allow you to restore important files if something goes wrong.",
                IsTrueFalse = true
            });

            _questions.Add(new QuizQuestion
            {
                Question = "What should you avoid when using public Wi-Fi?",
                Options = new List<string>
    {
        "Browsing news websites",
        "Accessing sensitive banking information",
        "Reading emails",
        "Checking the weather"
    },
                CorrectAnswer = "Accessing sensitive banking information",
                Explanation = "Public Wi-Fi networks may not be secure and can expose sensitive data.",
                IsTrueFalse = false
            });
        }
    }
}