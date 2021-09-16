using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab1
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();

        private readonly Thread[] _threads;
        
        public TaskQueue(int count)
        {
            _threads = new Thread[count];
            for(var i = 0; i < count; i++)
            {
                _threads[i] = new Thread(task) {Name = "Name " + i};
                _threads[i].Start();
            }
        }

        private void task()
        {
            for (var i = 0; i < 2; i++)
            {
                var a = Thread.CurrentThread.Name;
                Console.WriteLine(a);
                Thread.Sleep(200);
            }
        }

    }
}