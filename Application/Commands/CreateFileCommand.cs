using System.IO;

namespace Application.Commands
{
    public class CreateFileCommand : ICommand
    {
        string ICommand.Description => "Crea un archivo nuevo vacio con el siguiente nombre y extensión.";
        string ICommand.CommandName => "tch";
        public string Execute(string[] commandArguments)
        {
            if (commandArguments.Length != 1)
                throw new CommandException("Uso incorrecto. Formato: tch [nombre de archivo]");         

            string fileName = commandArguments[0];
            if (ContainsFolder(fileName))
                throw new CommandException("El parametro no debe contener una carpeta.");
            
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (File.Exists(filePath))
                throw new CommandException("El archivo ya existe.");

            using(File.Create(filePath))
            return "Archivo creado exitosamente.";
        }

        private bool ContainsFolder(string fileName)
        {
            return fileName.Contains("/") || fileName.Contains("\\");
        }
    }
}
