using System.IO;
using System.Text;

namespace Application.Commands
{ 
    public class ListFilesCommand : ICommand
    {
        string ICommand.Description => "Muestra los archivos/carpetas que se encuentran en el directorio.";
        string ICommand.CommandName => "ls";

        public string Execute(string[] commandArguments)
        {
            bool isRecursive = false;

            if (commandArguments.Length == 1 && commandArguments[0] == "-R")
                isRecursive = true;
            else if(commandArguments.Length != 0)
                throw new CommandException("Uso incorrecto. Formato: ls o ls -R");

            string directoryPath = Directory.GetCurrentDirectory();
            StringBuilder sb = new StringBuilder();

            if (isRecursive)
                ListDirectoriesRecursively(directoryPath, sb);
            else
                ListDirectories(directoryPath, sb);

            return sb.ToString();
        }

        private void ListDirectories(string directoryPath, StringBuilder sb)
        {
            string[] files = Directory.GetFiles(directoryPath);
            string[] directories = Directory.GetDirectories(directoryPath);

            ListNames("Archivos:", files, sb);
            ListNames("Carpetas:", directories, sb);
        }

        private void ListDirectoriesRecursively(string directoryPath, StringBuilder sb)
        {
            ListDirectories(directoryPath, sb);

            string[] directories = Directory.GetDirectories(directoryPath);

            foreach (string directory in directories)
            {
               ListDirectoriesRecursively(directory, sb);
            }
        }
        private void ListNames(string headerName, string[] names, StringBuilder sb)
        {
            if (names.Length > 0)
            {
                sb.AppendLine(headerName);
                foreach (string name in names)
                {
                    sb.AppendLine(name);
                }
                sb.AppendLine();
            }
        }
    }
}
  

