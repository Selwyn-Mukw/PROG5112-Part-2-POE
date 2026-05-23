using System;
using System.Media;
using System.Windows;

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


            ChatHistory.AppendText(
        "Bot: Welcome to the Cyber Security Hub!\n" +
        "You can ask me about:\n" +
        "- Phishing\n" +
        "- Malware\n" +
        "- VPNs\n" +
        "- Passwords\n" +
        "- Firewalls\n" +
        "- Privacy\n\n");

        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text;

            // Ignore empty messages
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            // Display user message
            ChatHistory.AppendText("\nYou: " + userMessage);

            // Get chatbot response
            string botResponse = responder.GetResponse(userMessage);

            // Display bot response
            ChatHistory.AppendText("\nBot: " + botResponse + "\n");

            // Auto-scroll to latest message
            ChatHistory.ScrollToEnd();

            // Clear input box
            UserInput.Clear();
        }
    }
}