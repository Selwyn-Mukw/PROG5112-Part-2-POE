namespace CybersecurityChatbot
{
    public class QuizQuestion
    {
        public string Question { get; set; } = "";

        public List<string> Options { get; set; } = new();

        public string CorrectAnswer { get; set; } = "";

        public string Explanation { get; set; } = "";

        public bool IsTrueFalse { get; set; }
    }
}