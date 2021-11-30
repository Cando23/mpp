using System;
using System.IO;
using Lab1;

namespace Lab2
{
    class Program
    {
   
        static void Main(string[] args)
        {
            /*if (args.Length != 2)
            {
                return;
            }
            var source = args[0];
            var destination = args[1];*/
            Console.Write("Source: ");
            var source = Console.ReadLine();
            Console.Write("Destination: ");
            var destination = Console.ReadLine();
            var handler = new FileHandler(new TaskQueue(5));
            CopyInfo copyInfo = handler.Copy(source, destination);
            Console.WriteLine($"Directories copied: {copyInfo.Directories}");
            Console.WriteLine($"Files copied: {copyInfo.Files}");
            handler.Dispose();
        }
    }
}