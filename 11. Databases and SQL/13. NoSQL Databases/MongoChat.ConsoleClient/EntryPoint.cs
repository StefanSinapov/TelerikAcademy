namespace MongoChat.ConsoleClient
{
    using System;
    using Data;
    using Models;

    class EntryPoint
    {
        private static readonly MongoChatController ChatController  = new MongoChatController();

        static void Main()
        {
            Console.WriteLine("Connection to server...");
            
            TestPrintAllMassages();

            //TestAddNewMessage();
        }

        private static void TestAddNewMessage()
        {
            var message = new Message
            {
                PostDate = DateTime.Now,
                Text = "Message Send from Console Client",
                User = new User
                {
                    Username = "Admin"
                }
            };

            ChatController.PostMessage(message);
        }

        private static void TestPrintAllMassages()
        {
            var allMassages = ChatController.GetAllMessagesAsString();
            Console.WriteLine(allMassages);
        }
    }
}
