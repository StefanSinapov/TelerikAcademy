namespace MongoChat.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Models;
    using MongoDB.Driver.Builders;

    public class MongoChatController : IMongoChatController
    {
        private readonly MongoChatContext mongoChatContext;

        public MongoChatController()
            : this(new MongoChatContext(), new ValidationController())
        {
            
        }

        public MongoChatController(MongoChatContext context, IValidationController validationController)
        {
            this.mongoChatContext = context;
            this.ValidationController = validationController;
        }

        public IValidationController ValidationController { get; set; }

        public bool PostMessage(Message message)
        {
            if (this.ValidationController.ValidateMessage(message))
            {
                this.mongoChatContext.Messages.Insert(message);
                return true;
            }
            return false;
        }

        public string GetAllMessagesAsString()
        {
            return this.GetAllMassagesByDate(DateTime.MinValue);
        }

        public string GetAllMessagesByDates(DateTime startDate, DateTime endDate)
        {
            var messagesAsString = new StringBuilder();

            var findPostsInDateRangeQuery = Query<Message>
                                        .Where(message => message.PostDate >= startDate && 
                                                    message.PostDate <= endDate);

            var messagesInRange = this.mongoChatContext.Messages.Find(findPostsInDateRangeQuery);

            foreach (var message in messagesInRange)
            {
                messagesAsString.AppendLine(message.ToString());
            }

            return messagesAsString.ToString();
        }

        public string GetAllMassagesByDate(DateTime startDate)
        {
            return this.GetAllMessagesByDates(startDate, DateTime.Now);
        }

        public ICollection<Message> GetAllMessages()
        {
            return this.mongoChatContext.Messages.FindAll().ToList();
        }


        public Task<int> MessagesCount()
        {
            return Task.Run(() => (int)this.mongoChatContext.Messages.Count());
        }
    }
}