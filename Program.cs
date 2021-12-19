using System;
using System.IO;

namespace DirectoryWatcher
{
    class Program
    {
        public static Watcher watcher;
        static void Main(string[] args)
        {
            watcher = new Watcher();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
        