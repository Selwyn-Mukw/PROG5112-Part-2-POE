
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
        private QuizManager quizManager = new QuizManager();
        private IntentDetector intentDetector = new IntentDetector();

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
            string intent =
    intentDetector.DetectIntent(userMessage);

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

            switch (intent)
            {
                case "Quiz":

                    quizManager.ResetQuiz();
                    LoadQuestion();

                    AddBotMessage("Starting the Cybersecurity Quiz!");
                    return;

                case "AddTask":

                    string taskTitle = ExtractTaskTitle(userMessage);

                    taskManager.AddTask(
                        taskTitle,
                        "",
                        "");

                    LoadTasks();

                    AddBotMessage($"Task added: {taskTitle}");

                    return;

                case "Reminder":

                    string reminderTask = ExtractReminder(userMessage);

                    taskManager.AddTask(
                        reminderTask,
                        "",
                        "Reminder");

                    LoadTasks();

                    AddBotMessage(
                        $"Reminder set for  '{reminderTask}'.");

                    return;
            }
            // BOT RESPONSE

            string botResponse =
    responder.GetResponse(userMessage);

            AddBotMessage(botResponse);

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

            string selectedAnswer = lstOptions.SelectedItem.ToString();

            QuizQuestion currentQuestion =
                quizManager.GetCurrentQuestion();

            if (currentQuestion == null)
                return;

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

        
        private void AddBotMessage(string message)
        {
            Paragraph botParagraph = new Paragraph();

            botParagraph.Foreground = Brushes.White;

            botParagraph.Inlines.Add(
                new Run("Bot: " + message));

            ChatHistory.Document.Blocks.Add(botParagraph);

            ChatHistory.ScrollToEnd();
        }
        private string ExtractTaskTitle(string input)
        {
            input = input.ToLower();

            input = input.Replace("add task", "");
            input = input.Replace("add a task", "");
            input = input.Replace("create task", "");
            input = input.Replace("create a task", "");
            input = input.Replace("i need to", "");
            input = input.Replace("enable", "");
            input = input.Replace("set up", "");

            return input.Trim();
        }

        private string ExtractReminder(string input)
        {
            input = input.ToLower();

            input = input.Replace("remind me to", "");
            input = input.Replace("remind me", "");
            input = input.Replace("set a reminder to", "");
            input = input.Replace("set reminder to", "");
            input = input.Replace("remember to", "");

            return input.Trim();
        }

    }
}




