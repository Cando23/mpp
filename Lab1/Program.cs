using System;
using System.Threading;

namespace Lab1
{
    static class Program
    {
        static void TaskForThread()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("цикл {0}, выполнение внутри потока из пула {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }
        
        static void AddNewTasks(int count, TaskQueue.TaskDelegate task)
        {
            for(var i=0; i < count; i++)
                _taskQueue.EnqueueTask(task);
        }

        private static TaskQueue _taskQueue;
        static void Main()
        { 
            _taskQueue = new TaskQueue(2);
            AddNewTasks(2,TaskForThread);
            Console.ReadLine();
        }
    }
}