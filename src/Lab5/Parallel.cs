using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Lab1;

namespace Lab5
{
    public class Parallel
    {
        public static void WaitAll(ITaskQueue.TaskDelegate[] tasks)
        {
            using var taskQueue = new TaskQueue(3);
            var signal = new ManualResetEvent(false);
            var taskCount = tasks.Length;
            foreach (var task in tasks)
            {
                taskQueue.EnqueueTask(() =>
                {
                    task();
                    CompleteTask(ref taskCount, signal);
                });
            }

            signal.WaitOne();
            Console.WriteLine("Computing ended!");
        }

        private static void CompleteTask(ref int taskCount, EventWaitHandle signal)
        {
            if (Interlocked.Decrement(ref taskCount) == 0)
            {
                signal.Set();
            }
        }
    }
}