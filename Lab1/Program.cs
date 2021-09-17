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
        private static void Task3()
        {
            while (true)
            {
                Console.WriteLine(new string(' ', 20) +Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
        }

        private static void Task2()
        {
            while (true)
            {
                Console.WriteLine(new string(' ', 10) + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
        }
        private static void Task1()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
            }
        }
        
        private static TaskQueue _taskQueue;
        static void Main()
        { 
            _taskQueue = new TaskQueue(2);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.EnqueueTask(TaskForThread);
            _taskQueue.EnqueueTask(TaskForThread);

            Console.ReadLine();
        }
    }
}