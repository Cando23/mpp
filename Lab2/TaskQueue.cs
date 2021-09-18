﻿using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Lab2
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();

        private readonly Thread[] _threads;

        private readonly BlockingCollection<TaskDelegate> _taskQueue;
        public TaskQueue(int count)
        {
            _taskQueue = new BlockingCollection<TaskDelegate>();
            _threads = new Thread[count];
            for(var i = 0; i < count; i++)
            {
                _threads[i] = new Thread(ProcessQueue);
                _threads[i].Start();
            }
        }

        private void ProcessQueue()
        {
            while (true)
            {
                var task = _taskQueue.Take();
                try
                {
                    task?.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public void EnqueueTask(TaskDelegate task)
        { 
            _taskQueue.Add(task);
        }
    }
}