using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab5
{
    public class Parallel
    {
        private static TaskQueue _taskQueue;
        public static void WaitAll(TaskQueue.TaskDelegate[] tasks)
        {
            _taskQueue = new TaskQueue(3);
            var signal = new ManualResetEvent(false);
            var taskCount = tasks.Length;
            foreach (var task in tasks)
            {
                _taskQueue.EnqueueTask(()=>{
                task();
                CompleteTask(ref taskCount, signal);
                });
            }
            signal.WaitOne();
            _taskQueue.Dispose();
            Console.WriteLine("Computing ended!");
        }
        private static void CompleteTask(ref int taskCount,  EventWaitHandle signal) {
            if (Interlocked.Decrement(ref taskCount) == 0)
            {
                signal.Set();
            }
        }
    }
}