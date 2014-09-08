namespace MongoChat.Data.Contracts
{
    using Models;

    public interface IValidationController
    {
        bool ValidateMessage(Message message);

        bool IsValidUsername(string username);
    }
}