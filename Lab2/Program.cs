using System;
using System.Collections;
using System.IO;
using System.Threading;

namespace Lab2
{
    public class CopyInfo
    {
        public int Files { get; set; }
        public int Directories { get; set; }
    }
    class Program
    {
        private static TaskQueue _taskQueue;
        
        private static void CopyFiles(string[] files, string destination)
        {
            foreach (string file in files )
            {
                var fileInfo = new FileInfo(file);
                _taskQueue.EnqueueTask(() =>
                {
                    fileInfo.CopyTo(destination + "/" + Path.GetFileName(file));
                });
            }
        }

        private static CopyInfo Copy(string source, string destination)
        {
            var copyInfo = new CopyInfo();
            var files = Directory.GetFiles(source);
            var directories = Directory.GetDirectories(source);
            copyInfo.Files = files.Length;
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
                copyInfo.Directories = 1;
            }
            CopyFiles(files, destination);
            foreach (var directory in directories)
            {
                var result = Copy(directory, destination + "/" + Path.GetFileName(directory));
                copyInfo.Directories += result.Directories;
                copyInfo.Files += result.Files;
            }
            return copyInfo;
        }
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                return;
            }
            var source = args[0];
            var destination = args[1];
            /*Console.Write("Source: ");
            var source = Console.ReadLine();
            Console.Write("Destination: ");
            var destination = Console.ReadLine();*/
            _taskQueue = new TaskQueue(5);
            CopyInfo copyInfo = Copy(source, destination);
            Console.WriteLine($"Directories copied: {copyInfo.Directories}");
            Console.WriteLine($"Files copied: {copyInfo.Files}");
            Console.ReadLine();
        }
    }
}