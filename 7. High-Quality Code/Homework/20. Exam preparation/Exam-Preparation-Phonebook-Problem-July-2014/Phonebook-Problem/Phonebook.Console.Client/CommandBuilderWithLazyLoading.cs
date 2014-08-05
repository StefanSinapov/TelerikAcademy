namespace Phonebook
{
    using System;
    using Command;

    public class CommandBuilderWithLazyLoading : ICommandBuilder
    {
        private readonly Lazy<AddPhoneCommand> lazyAddPhoneCommand = new Lazy<AddPhoneCommand>(() => new AddPhoneCommand());

        private Lazy<ChangePhoneCommand> lazyChangePhoneCommad = new Lazy<ChangePhoneCommand>(() => new ChangePhoneCommand());

        private Lazy<ListCommand> lazyListCommand = new Lazy<ListCommand>(() => new ListCommand());

        public IPhonebookCommand GetCommand(string commandName, string[] arguments)
        {
            if (commandName.StartsWith("AddPhone") && (arguments.Length >= 2))
            {
                return this.lazyAddPhoneCommand.Value;
            }

            if ((commandName == "ChangePhone") && (arguments.Length == 2))
            {
                return this.lazyChangePhoneCommad.Value;
            }

            if ((commandName == "List") && (arguments.Length == 2))
            {
                return this.lazyListCommand.Value;
            }

            throw new ArgumentException("Invalid command.");
        }
    }
}
