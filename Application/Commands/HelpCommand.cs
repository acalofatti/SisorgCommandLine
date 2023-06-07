using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class HelpCommand : ICommand
    {
        public string Description => "Permite ver un listado de cada comando y su descripción";
        public string CommandName => "help";

        private readonly Dictionary<string, ICommand> _commands;
        public HelpCommand(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
        }
        public string Execute(string[] commandArguments)
        {
            if (commandArguments.Length == 1)
            {
                string commandName = commandArguments[0];

                if (_commands.ContainsKey(commandName))
                {
                    ICommand command = _commands[commandName];
                    return ShowCommandDescription(command);
                }
                else
                    throw new CommandException("Comando no reconocido.");
            }
            else
                return ShowAllCommandsDescription();
        }

        private string ShowCommandDescription(ICommand command)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comando: {command.CommandName}");
            sb.AppendLine($"Descripción: {command.Description}");
            return sb.ToString();
        }

        private string ShowAllCommandsDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Comandos disponibles:");

            foreach (KeyValuePair<string, ICommand> command in _commands)
            {
                sb.AppendLine($"- {command.Value.CommandName}: {command.Value.Description}");
            }

            sb.AppendLine("- exit: Permite cerrar el programa");
            return sb.ToString();
        }
    }
}
