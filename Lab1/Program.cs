using System;
using System.Threading;

namespace Lab1
{
    static class Program
    {
        private static TaskQueue _taskQueue;
        static void Main(string[] args)
        { 
            _taskQueue = new TaskQueue(3);
            Console.ReadLine();
        }
    }
}