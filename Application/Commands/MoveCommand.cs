using System.IO;

namespace Application.Commands
{
    public class MoveCommand : ICommand
    {
        public string Description => "Cambia de nombre un archivo o mueve un archivo de directorio";
        public string CommandName => "mv";

        public string Execute(string[] commandArguments)
        {
            if (commandArguments.Length != 2)
                throw new CommandException("Uso incorrecto. Formato: mv [origen] [destino]");

            string source = commandArguments[0];
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), source);

            if (!File.Exists(sourcePath))
                throw new CommandException("El archivo de origen no existe.");

            string destination = commandArguments[1];
            string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), destination);

            if (Directory.Exists(destinationPath))
            {
                MoveFileToDirectory(sourcePath, destinationPath);
                return "Archivo movido exitosamente.";
            }
            else
            {
                ValidateFileRenameArguments(source, destination);
                RenameFile(sourcePath, destinationPath);
                return "Archivo renombrado exitosamente.";
            }
        }

        private void MoveFileToDirectory(string sourcePath, string destinationPath)
        {
            string fileName = Path.GetFileName(sourcePath);
            string destinationFilePath = Path.Combine(destinationPath, fileName);
            File.Move(sourcePath, destinationFilePath);
        }

        private void RenameFile(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }

        private void ValidateFileRenameArguments(string source, string destination)
        {
            if (ContainsFolderSeparator(source))
                throw new CommandException("El parámetro origen no debe contener una carpeta.");

            if (ContainsFolderSeparator(destination))
                throw new CommandException("El parámetro destino no debe contener una carpeta.");
        }

        private bool ContainsFolderSeparator(string path)
        {
            return path.Contains("/") || path.Contains("\\");
        }
    }
}
