using System.Windows;

namespace MongoChat.WPF
{
    using Data;
    using Data.Contracts;
    using Models;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private static readonly IValidationController ValidationController = new ValidationController();

        public LoginWindow()
        {
            InitializeComponent();
            this.UsernameTextBox.Focus();
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var username = this.UsernameTextBox.Text;

            if (!ValidationController.IsValidUsername(username))
            {
                return;
            }

            this.Hide();
            this.ShowMongoChatWindow(username);
            this.Close();
        }

        private void ShowMongoChatWindow(string username)
        {
            var user = new User(username);
            var mainWindow = new MongoChatWindow(user);
            mainWindow.Show();
        }

    }
}
