using System;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create responder object
        private KeywordResponder responder;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize keyword responder
            responder = new KeywordResponder();

            // Play greeting sound
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"C:\Users\mukwe\source\repos\CybersecurityChatbot\CybersecurityChatbot\CyberGreeting.wav";
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sound could not play: " + ex.Message);
            }

            // ASCII Art
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

            //welcome message for the user
            Paragraph welcomeParagraph = new Paragraph();
            welcomeParagraph.Foreground = Brushes.White;

            welcomeParagraph.Inlines.Add(
                new Run(
                    "Bot: Welcome to the Cyber Security Hub!\n" +
                    "Bot: What is your name?\n"));

            ChatHistory.Document.Blocks.Add(welcomeParagraph);

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();

            // Ignore empty messages
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            // USER MESSAGE
            Paragraph userParagraph = new Paragraph();
            userParagraph.Foreground = Brushes.Lime;
            userParagraph.Inlines.Add(new Run("You: " + userMessage));

            ChatHistory.Document.Blocks.Add(userParagraph);

            // BOT RESPONSE
            string botResponse = responder.GetResponse(userMessage);

            Paragraph botParagraph = new Paragraph();
            botParagraph.Foreground = Brushes.White;
            botParagraph.Inlines.Add(new Run("Bot: " + botResponse));

            ChatHistory.Document.Blocks.Add(botParagraph);

            // Scroll automatically
            ChatHistory.ScrollToEnd();

            // Clear input
            UserInput.Clear();
        }
    }
}