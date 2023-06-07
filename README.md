# SisorgCommandLine
Ejercicio técnico

Esta es una aplicación de línea de comandos que permite realizar varias operaciones en archivos y directorios. A continuación se proporciona información sobre cómo ejecutar y utilizar la aplicación.

## Requisitos previos
Antes de ejecutar la aplicación, asegúrate de tener instalado lo siguiente:

- .NET Framework 4.7.2 o superior

## Instalación
1. Clona el repositorio desde GitHub:

   ```shell
   git clone https://github.com/acalofatti/SisorgCommandLine.git

2.  Compila la solución utilizando Visual Studio o mediante el siguiente comando en la línea de comandos:
    dotnet build
## Uso
Una vez que hayas compilado la solución, puedes ejecutar la aplicación desde la línea de comandos. A continuación se muestran los comandos disponibles:

tch [nombre de archivo]: Crea un archivo nuevo vacío con el nombre y extensión especificados.
mv [archivo1] [archivo2]: Cambia el nombre de un archivo.
mv [path1] [path2]: Mueve un archivo de un directorio a otro.
ls: Muestra los archivos y carpetas en el directorio actual.
ls -R: Muestra el contenido de todos los subdirectorios de forma recursiva (opcional).
cd [path]: Permite cambiar el directorio actual.
help [comando]: Muestra una descripción de cada comando y su uso.

