using Application;
using Application.Commands;
using System;
using System.Linq;
using System.Xml.Schema;

namespace Presentation
{
    public class ConsoleInterface
    {
        private readonly CommandProcessor _commandProcessor;

        public ConsoleInterface()
        {
            _commandProcessor = new CommandProcessorBuilder()
                .RegisterCommand(new CreateFileCommand())
                .RegisterCommand(new ChangeDirectoryCommand())
                .RegisterCommand(new MoveCommand())
                .RegisterCommand(new ListFilesCommand())
                .Build();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ingrese un comando: ");
                    string input = Console.ReadLine().Trim();
                    string[] commandParts = input.Split(' ');

                    if (commandParts.Length == 0)
                        throw new CommandException("Comando inválido.");

                    string commandName = commandParts[0];
                    string[] commandArguments = commandParts.Skip(1).ToArray();

                    if (commandName == "exit")
                    {
                        break;
                    }

                    string result = _commandProcessor.ProcessCommand(commandName, commandArguments);
                    Console.WriteLine(result);
                }
                catch (CommandException commandException)
                {
                    Console.WriteLine(commandException.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
