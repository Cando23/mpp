using System;
using System.IO;
using Lab1;

namespace Lab2
{
    public class FileHandler:IDisposable
    {
        public FileHandler(ITaskQueue taskQueue)
        {
            _taskQueue = taskQueue;
        }
        private ITaskQueue _taskQueue;
        
        private void CopyFiles(string[] files, string destination)
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

        public CopyInfo Copy(string source, string destination)
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

        public void Dispose()
        {
            _taskQueue.Dispose();
        }
    }
}