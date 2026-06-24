
using System;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private KeywordResponder responder;
        private TaskManager taskManager = new TaskManager();

        public MainWindow()
        {
            InitializeComponent();

            responder = new KeywordResponder();

            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation =
                    @"C:\Users\mukwe\source\repos\CybersecurityChatbot\CybersecurityChatbot\CyberGreeting.wav";

                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sound could not play: " + ex.Message);
            }

            AsciiArt.Text =
@"███████╗ █████╗ ███████╗███████╗████████╗██╗   ██╗
██╔════╝██╔══██╗██╔════╝██╔════╝╚══██╔══╝╚██╗ ██╔╝
███████╗███████║█████╗  █████╗     ██║    ╚████╔╝
╚════██║██╔══██║██╔══╝  ██╔══╝     ██║     ╚██╔╝
███████║██║  ██║██║     ███████╗   ██║      ██║
╚══════╝╚═╝  ╚═╝╚═╝     ╚══════╝   ╚═╝      ╚═╝

███████╗██╗██████╗ ███████╗████████╗
██╔════╝██║██╔══██╗██╔════╝╚══██╔══╝
█████╗  ██║██████╔╝███████╗   ██║
██╔══╝  ██║██╔══██╗╚════██║   ██║
██║     ██║██║  ██║███████║   ██║
╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝";

            Paragraph welcomeParagraph =
                new Paragraph();

            welcomeParagraph.Foreground =
                Brushes.White;

            welcomeParagraph.Inlines.Add(
                new Run(
                    "Bot: Welcome to the Cyber Security Hub!\n" +
                    "Bot: What is your name?\n"));

            ChatHistory.Document.Blocks.Add(
                welcomeParagraph);

            LoadTasks();
            LoadQuestion();
        }

        private void SendButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            string userMessage =
                UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                userMessage))
            {
                return;
            }

            // USER MESSAGE

            Paragraph userParagraph =
                new Paragraph();

            userParagraph.Foreground =
                Brushes.Lime;

            userParagraph.Inlines.Add(
                new Run("You: " + userMessage));

            ChatHistory.Document.Blocks.Add(
                userParagraph);

            // BOT RESPONSE

            string botResponse =
                responder.GetResponse(
                    userMessage);

            Paragraph botParagraph =
                new Paragraph();

            botParagraph.Foreground =
                Brushes.White;

            botParagraph.Inlines.Add(
                new Run(
                    "Bot: " + botResponse));

            ChatHistory.Document.Blocks.Add(
                botParagraph);

            ChatHistory.ScrollToEnd();

            UserInput.Clear();
        }

        // ==========================
        // TASK ASSISTANT METHODS
        // ==========================

        private void LoadTasks()
        {
            lstTasks.ItemsSource = null;
            lstTasks.ItemsSource =
                taskManager.GetAllTasks();
        }

        private void btnAddTask_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtTaskTitle.Text))
            {
                MessageBox.Show(
                    "Please enter a task title.");

                return;
            }

            taskManager.AddTask(
                txtTaskTitle.Text,
                txtTaskDescription.Text,
                txtReminder.Text);

            LoadTasks();

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            txtReminder.Clear();

            MessageBox.Show(
                "Task added successfully.");
        }

        private void btnComplete_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (lstTasks.SelectedItem
                is CyberTask task)
            {
                taskManager.MarkAsComplete(
                    task.Id);

                LoadTasks();

                MessageBox.Show(
                    "Task marked complete.");
            }
            else
            {
                MessageBox.Show(
                    "Please select a task.");
            }
        }

        private void btnDelete_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (lstTasks.SelectedItem is CyberTask task)
            {
                taskManager.DeleteTask(task.Id);
                LoadTasks();
                MessageBox.Show(
                    "Task deleted successfully.");
            }
            else
            {
                MessageBox.Show(
                    "Please select a task.");
            }
        }

        
       private QuizManager quizManager = new QuizManager();

        private void LoadQuestion()
        {
            if (quizManager.IsFinished())
            {
                txtQuestion.Text =
                $"Quiz Finished!\nScore: {quizManager.GetScore()} / {quizManager.TotalQuestions()}";


    lstOptions.ItemsSource = null;

                txtFeedback.Text =
                    quizManager.GetScore() >= (quizManager.TotalQuestions() / 2)
                    ? "Great job!"
                    : "Keep learning and try again!";

                return;
            }

            QuizQuestion question =
                quizManager.GetCurrentQuestion();

            if (question == null)
            {
                txtQuestion.Text = "No questions available.";
                return;
            }

            txtQuestion.Text = question.Question;

            lstOptions.ItemsSource = null;
            lstOptions.ItemsSource = question.Options;

            txtFeedback.Text = "";

            txtScore.Text =
                $"Score: {quizManager.GetScore()} / {quizManager.TotalQuestions()}";


}


        private void btnSubmitAnswer_Click(
    object sender,
    RoutedEventArgs e)
        {
            if (lstOptions.SelectedItem == null)
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            string selectedAnswer =
                lstOptions.SelectedItem.ToString();

            QuizQuestion currentQuestion =
                quizManager.GetCurrentQuestion();

            bool correct =
                quizManager.SubmitAnswer(selectedAnswer);

            txtFeedback.Text =
                correct
                ? "✓ Correct! " + currentQuestion.Explanation
                : "✗ Incorrect! " + currentQuestion.Explanation;

            txtScore.Text =
                $"Score: {quizManager.GetScore()} / {quizManager.TotalQuestions()}";

            quizManager.MoveNextQuestion();
            LoadQuestion();
        }

      

    }
}




