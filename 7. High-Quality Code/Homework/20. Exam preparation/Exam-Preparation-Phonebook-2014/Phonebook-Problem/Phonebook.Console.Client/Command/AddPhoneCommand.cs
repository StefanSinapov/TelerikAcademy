namespace Phonebook.Command
{
    using System.Linq;

    public class AddPhoneCommand : IPhonebookCommand
    {
        public void Execute(string[] arguments, IPhonebookRepository repository, IPhoneNumberConverter converter, IPrinter printer)
        {
            string str0 = arguments[0];
            var str1 = arguments.Skip(1).ToList();
            for (int i = 0; i < str1.Count; i++)
            {
                str1[i] = converter.Convert(str1[i]);
            }

            bool isNewEntry = repository.AddPhone(str0, str1);
            if (isNewEntry)
            {
                printer.Print("Phone entry created");
            }
            else
            {
                printer.Print("Phone entry merged");
            }
        }
    }
}
