namespace MongoChat.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IMongoChatController
    {
        bool PostMessage(Message message);

        string GetAllMessagesAsString();

        string GetAllMessagesByDates(DateTime startDate, DateTime endDate);

        string GetAllMassagesByDate(DateTime startDate);

        ICollection<Message> GetAllMessages();

        System.Threading.Tasks.Task<int> MessagesCount();
    }
}