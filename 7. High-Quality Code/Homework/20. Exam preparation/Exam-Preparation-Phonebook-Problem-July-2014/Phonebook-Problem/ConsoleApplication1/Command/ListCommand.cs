namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListCommand: IPhonebookCommand
    {
        public void Execute(string[] arguments, IPhonebookRepository repository, IPhoneNumberConverter converter, IPrinter printer)
        {
            try
            {
                int startIndex = int.Parse(arguments[0]);
                int count = int.Parse(arguments[1]);
                IEnumerable<PhoneEntry> entries = repository.ListEntries(startIndex, count);
                
                foreach (var entry in entries)
                {
                    printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                printer.Print("Invalid range");
            }
        }
    }
}
