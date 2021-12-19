using System;
using System.IO;
using System.Collections.Generic;
namespace DirectoryWatcher
{
    class Watcher
    {
        private static readonly string sourceFolder = "/home/neko/Downloads/";
        private FileSystemWatcher watcher = new FileSystemWatcher("/home/neko/Downloads/");
        public Watcher()
        {
            Console.WriteLine("Initializing watcher");
            watcher.NotifyFilter = NotifyFilters.Attributes 
                                |   NotifyFilters.CreationTime
                                |   NotifyFilters.DirectoryName
                                |   NotifyFilters.FileName
                                |   NotifyFilters.LastAccess
                                |   NotifyFilters.LastWrite
                                |   NotifyFilters.Security
                                | NotifyFilters.Size;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Error += OnError;

            watcher.EnableRaisingEvents = true;
        }
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            string file = e.Name;

            string destinationPath = MIMEAssistant.GetMIMEType(e.Name);
            Console.WriteLine($"Created: {file}\n moving to {destinationPath}");

            MoveFileToFolder(file, destinationPath);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");


        private void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
        private void MoveFileToFolder(string file, string destinationPath)
        {

            var destinationFile = Path.Combine(destinationPath,file);
            var sourceFile = Path.Combine(sourceFolder,file);
            
            Directory.CreateDirectory(destinationPath);

            File.Move(sourceFile, destinationFile);
        }
    }
}

