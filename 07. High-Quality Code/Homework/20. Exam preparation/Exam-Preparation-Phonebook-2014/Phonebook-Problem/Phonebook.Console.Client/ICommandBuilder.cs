namespace Phonebook
{
    using Phonebook.Command;

    public interface ICommandBuilder
    {
        IPhonebookCommand GetCommand(string commandName, string[] arguments);
    }
}
