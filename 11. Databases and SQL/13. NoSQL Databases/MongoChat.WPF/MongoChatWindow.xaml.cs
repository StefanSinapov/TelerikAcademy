namespace MongoChat.WPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;

    using Data;
    using Data.Contracts;
    using Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MongoChatWindow
    {
        private readonly User sessionUser;
        private readonly IMongoChatController mongoChatController;

        public MongoChatWindow(User user)
        {
            InitializeComponent();
            this.mongoChatController = new MongoChatController();
            this.sessionUser = user;
            this.RenderAllMessages();

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

         private async void RenderAllMessages()
         {
             this.AllMessagesView.Items.Clear();
             var messages = await GetAllMessages();

             foreach (var message in messages)
             {
                 this.AllMessagesView.Items.Add(message);
             }
             this.AllMessagesView.ScrollIntoView(messages.Last());
         }

         private void dispatcherTimer_Tick(object sender, EventArgs e)
         {
             this.UpdatePosts();
         }

         private async void UpdatePosts()
         {
             int messagesCount = await this.mongoChatController.MessagesCount();
             if (this.AllMessagesView.Items.Count == messagesCount)
             {
                 return;
             }

             this.RenderAllMessages();
         }

         private Task<ICollection<Message>> GetAllMessages()
         {
             return Task.Run(() => this.mongoChatController.GetAllMessages());
         }


        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var msgText = this.MessageTextBox.Text;
            var message = new Message
            {
                Text = msgText,
                PostDate = DateTime.Now,
                User = this.sessionUser
            };

            bool messageIsSend = mongoChatController.PostMessage(message);

            if (messageIsSend)
            {
                this.MessageTextBox.Text = string.Empty;
                this.AllMessagesView.Items.Add(message);
                this.AllMessagesView.ScrollIntoView(message);
            }

        }
    }
}
