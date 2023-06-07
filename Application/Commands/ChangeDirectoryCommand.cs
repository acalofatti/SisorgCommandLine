using System.IO;

namespace Application.Commands
{
    public class ChangeDirectoryCommand : ICommand
    {
        public string Description => "Permite navegar entre los diferentes directorios";
        public string CommandName => "cd";
        public string Execute(string[] commandArguments)
        {
            if (commandArguments.Length != 1)
                throw new CommandException("Uso incorrecto. Formato: cd [path]");

            string path = commandArguments[0];

            if (!Directory.Exists(path))
                throw new CommandException("El directorio no existe.");

            Directory.SetCurrentDirectory(path);
            return "Directorio actual cambiado a: " + Directory.GetCurrentDirectory();
        }
    }
}
