namespace Phonebook.Command
{
    public interface IPhonebookCommand
    {
        void Execute(string[] arguments, IPhonebookRepository repository, IPhoneNumberConverter converter, IPrinter printer);
    }
}
