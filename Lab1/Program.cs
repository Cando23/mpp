using System;
using System.Threading;

namespace Lab1
{
    static class Program
    {
        static void TaskForThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }

        private static TaskQueue _taskQueue;

        static void Main()
        {
            _taskQueue = new TaskQueue(3);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.Stop();
        }
    }
}