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
        static void Main()
        {
            using var taskQueue = new TaskQueue(3);
            taskQueue.EnqueueTask(TaskForThread);
            taskQueue.EnqueueTask(TaskForThread);
            taskQueue.EnqueueTask(TaskForThread);
            taskQueue.EnqueueTask(TaskForThread);
            taskQueue.EnqueueTask(TaskForThread);
            taskQueue.EnqueueTask(TaskForThread);
        }
    }
}