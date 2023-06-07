using System;
using System.Collections.Generic;

namespace Application
{
    public class CommandProcessor
    {
        public readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public void RegisterCommand(ICommand command)
        {
          commands[command.CommandName] = command;
        }

        public string ProcessCommand(string commandName, string[] args)
        {
            if (commands.ContainsKey(commandName))
            {
                ICommand command = commands[commandName];
                return command.Execute(args);
            }
            else
                throw new CommandException("Comando no reconocido. Escribe 'help' para ver la lista de comandos disponibles.");
        }
    }
}
