
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class SentimentDetector
    {
        // Dictionary mapping sentiments to trigger words
        private Dictionary<Sentiment, List<string>> sentimentKeywords =
            new Dictionary<Sentiment, List<string>>()
        {
            {
                Sentiment.Worried,
                new List<string>
                {
                    "worried",
                    "scared",
                    "afraid",
                    "anxious",
                    "nervous",
                    "unsafe",
                    "sad",
                    "stressed"
                }
            },

            {
                Sentiment.Curious,
                new List<string>
                {
                    "curious",
                    "wondering",
                    "interested",
                    "want to know",
                    "how does"
                }
            },

            {
                Sentiment.Frustrated,
                new List<string>
                {
                    "frustrated",
                    "annoyed",
                    "confused",
                    "don't understand"
                }
            },

            {
                Sentiment.Happy,
                new List<string>
                {
                    "great",
                    "thanks",
                    "helpful",
                    "awesome",
                    "love it",
                    "good",
                    "fine",
                    "happy"
                }
            }
        };

        // Detect sentiment
        public Sentiment Detect(string input)
        {
            input = input.ToLower();

            foreach (var entry in sentimentKeywords)
            {
                foreach (string keyword in entry.Value)
                {
                    if (input.Contains(keyword))
                    {
                        return entry.Key;
                    }
                }
            }

            return Sentiment.Neutral;
        }

        // Emotional chatbot response
        public string GetSentimentResponse(Sentiment sentiment, string userName)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return $"I understand your concern {userName}. " +
                           $"I am here to help you stay safe online.";

                case Sentiment.Curious:
                    return $"I like your curiosity {userName}! " +
                           $"Learning cybersecurity is a great skill.";

                case Sentiment.Frustrated:
                    return $"I understand this may feel frustrating {userName}. " +
                           $"Let me help explain things step by step.";

                case Sentiment.Happy:
                    return $"That is wonderful to hear {userName}! " +
                           $"I am glad you are feeling positive today.";

                default:
                    return $"Thank you for sharing {userName}.";
            }
        }
    }
}