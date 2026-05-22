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
        public MainWindow()
        {
            InitializeComponent();

            // Play Sound
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
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text;

            // Ignore empty messages
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            // Show user message
            ChatHistory.AppendText("\nYou: " + userMessage);

            // Bot response
            ChatHistory.AppendText("\nBot: Stay safe online!\n");

            // Auto-scroll
            ChatHistory.ScrollToEnd();

            // Clear input box
            UserInput.Clear();
        }
    }
}