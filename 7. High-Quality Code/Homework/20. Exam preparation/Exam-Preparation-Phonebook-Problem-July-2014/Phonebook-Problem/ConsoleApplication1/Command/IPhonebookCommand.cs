using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Command
{
    public interface IPhonebookCommand
    {
        void Execute(string[] arguments, IPhonebookRepository repository, IPhoneNumberConverter converter, IPrinter printer);
    }
}
