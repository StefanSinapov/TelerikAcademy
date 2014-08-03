namespace Phonebook
{
    using System;
    using Phonebook.Command;

    public class CommandBuilderWithLazyLoading : ICommandBuilder
    {
        private Lazy<AddPhoneCommand> lazyAddPhoneCommand = new Lazy<AddPhoneCommand>(() =>
                                                                        {
                                                                            return new AddPhoneCommand();
                                                                        });

        private Lazy<ChangePhoneCommand> lazyChangePhoneCommad = new Lazy<ChangePhoneCommand>(() =>
                                                                        {
                                                                            return new ChangePhoneCommand();
                                                                        });

        private Lazy<ListCommand> lazyListCommand = new Lazy<ListCommand>(() =>
                                                                        {
                                                                            return new ListCommand();
                                                                        });

        public IPhonebookCommand GetCommand(string commandName, string[] arguments)
        {
            if (commandName.StartsWith("AddPhone") && (arguments.Length >= 2))
            {
                return this.lazyAddPhoneCommand.Value;
            }
            else if ((commandName == "ChangePhone") && (arguments.Length == 2))
            {
                return this.lazyAddPhoneCommand.Value;
            }
            else if ((commandName == "List") && (arguments.Length == 2))
            {
                return this.lazyListCommand.Value;
            }
            else
            {
                throw new ArgumentException("Invalid command.");
            }
        }
    }
}
