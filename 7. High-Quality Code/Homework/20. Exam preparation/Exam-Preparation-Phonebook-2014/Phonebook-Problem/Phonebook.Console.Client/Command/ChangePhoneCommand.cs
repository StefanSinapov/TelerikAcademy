namespace Phonebook.Command
{
    public class ChangePhoneCommand : IPhonebookCommand
    {
        public void Execute(string[] arguments, IPhonebookRepository repository, IPhoneNumberConverter converter, IPrinter printer)
        {
            var oldNumber = converter.Convert(arguments[0]);
            var newNumber = converter.Convert(arguments[1]);
            int numberOfChangedPhones = repository.ChangePhone(oldNumber, newNumber);
            printer.Print(numberOfChangedPhones + " numbers changed");
        }
    }
}
