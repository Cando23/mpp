using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab5
{
    public class Parallel
    {
        private static readonly TaskQueue TaskQueue = new TaskQueue(3);
        
        public static void WaitAll(IEnumerable<TaskQueue.TaskDelegate> tasks)
        {
            foreach (var task in tasks)
            {
                TaskQueue.EnqueueTask(task);
            }
            TaskQueue.Stop();
            Console.WriteLine("Computing ended!");
        }
    }
}