namespace Phonebook
{
    using System;
    using Command;

    public class PhonebookEntryPoint
    {
        public static void Main()
        {
            IPhonebookRepository repository = new PhonebookRepository();
            IPhoneNumberConverter converter = new PhoneNumberConverter();
            IPrinter printer = new PrinterWithStringBuilder();
            ICommandBuilder commandBuilder = new CommandBuilderWithLazyLoading();

            while (true)
            {
                string userInputLine = Console.ReadLine();
                if (userInputLine == "End" || userInputLine == null)
                {
                    break;
                }

                int indexOfFirstBracket = userInputLine.IndexOf('(');
                if (indexOfFirstBracket == -1)
                {
                    throw new Exception("Invalid command format");
                }

                string name = userInputLine.Substring(0, indexOfFirstBracket);
                if (!userInputLine.EndsWith(")"))
                {
                    throw new Exception("Invalid command format");
                }

                string argumentsAsString = userInputLine.Substring(indexOfFirstBracket + 1, userInputLine.Length - indexOfFirstBracket - 2);
                string[] arguments = argumentsAsString.Split(',');

                for (int j = 0; j < arguments.Length; j++)
                {
                    arguments[j] = arguments[j].Trim();
                }

                IPhonebookCommand command = commandBuilder.GetCommand(name, arguments);
                command.Execute(arguments, repository, converter, printer);
            }

            Console.Write(printer.GetAllAsString());
        }
    }
}
