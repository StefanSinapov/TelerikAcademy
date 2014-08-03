namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
