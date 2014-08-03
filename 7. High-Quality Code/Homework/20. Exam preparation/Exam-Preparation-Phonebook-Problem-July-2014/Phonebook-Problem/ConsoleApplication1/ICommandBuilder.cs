namespace Phonebook
{
    using Phonebook.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommandBuilder
    {
        IPhonebookCommand GetCommand(string commandName, string[] arguments);
    }
}
