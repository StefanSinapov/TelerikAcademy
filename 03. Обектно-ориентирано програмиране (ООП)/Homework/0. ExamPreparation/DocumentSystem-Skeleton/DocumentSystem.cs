using System;
using System.Collections.Generic;

namespace DocumentSystem
{

	public class DocumentSystem
	{
		static void Main()
		{
			IList<string> allCommands = ReadAllCommands();
			ExecuteCommands(allCommands);
		}

		private static IList<string> ReadAllCommands()
		{
			List<string> commands = new List<string>();
			while (true)
			{
				string commandLine = Console.ReadLine();
				if (commandLine == "")
				{
					// End of commands
					break;
				}
				commands.Add(commandLine);
			}
			return commands;
		}

		private static void ExecuteCommands(IList<string> commands)
		{
			foreach (var commandLine in commands)
			{
				int paramsStartIndex = commandLine.IndexOf("[");
				string cmd = commandLine.Substring(0, paramsStartIndex);
				int paramsEndIndex = commandLine.IndexOf("]");
				string parameters = commandLine.Substring(
					paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
				ExecuteCommand(cmd, parameters);
			}
		}

		private static void ExecuteCommand(string cmd, string parameters)
		{
			string[] cmdAttributes = parameters.Split(
				new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

			DocumentSystemHandler handler = new DocumentSystemHandler();

			if (cmd == "AddTextDocument")
			{
				Console.WriteLine(handler.AddTextDocument(cmdAttributes));
				
			}
			else if (cmd == "AddPDFDocument")
			{
				Console.WriteLine(handler.AddPdfDocument(cmdAttributes));
			}
			else if (cmd == "AddWordDocument")
			{
				Console.WriteLine(handler.AddWordDocument(cmdAttributes));
			}
			else if (cmd == "AddExcelDocument")
			{
				Console.WriteLine(handler.AddExcelDocument(cmdAttributes));
			}
			else if (cmd == "AddAudioDocument")
			{
				Console.WriteLine(handler.AddAudioDocument(cmdAttributes));
			}
			else if (cmd == "AddVideoDocument")
			{
				Console.WriteLine(handler.AddVideoDocument(cmdAttributes));
			}
			else if (cmd == "ListDocuments")
			{
				Console.WriteLine(handler.ListDocuments());
			}
			else if (cmd == "EncryptDocument")
			{
				Console.WriteLine(handler.EncryptDocument(parameters));
			}
			else if (cmd == "DecryptDocument")
			{
				Console.WriteLine(handler.DecryptDocument(parameters));
			}
			else if (cmd == "EncryptAllDocuments")
			{
				Console.WriteLine(handler.EncryptAllDocuments());
			}
			else if (cmd == "ChangeContent")
			{
				Console.WriteLine(handler.ChangeContent(cmdAttributes[0], cmdAttributes[1]));
			}
			else
			{
				throw new InvalidOperationException("Invalid command: " + cmd);
			}
		}

		
	}
}