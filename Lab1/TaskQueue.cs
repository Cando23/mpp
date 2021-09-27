using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Lab1
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();

        private bool _Working = true;
        private Thread[] _threads;
        private readonly Queue<TaskDelegate> _taskQueue;

        public TaskQueue(int count)
        {
            _taskQueue = new Queue<TaskDelegate>();
            _threads = new Thread[count];
            for (var i = 0; i < count; i++)
            {
                _threads[i] = new Thread(ProcessQueue);
                _threads[i].Start();
            }
        }

        private void ProcessQueue()
        {
            while (_Working)
            {
                TaskDelegate task = null;
                if (_taskQueue.Count > 0)
                {
                    lock (_taskQueue)
                    {
                        if (_taskQueue.Count > 0)
                            task = _taskQueue.Dequeue();
                    }

                    task?.Invoke();
                }
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            if (task != null)
            {
                lock (_taskQueue)
                {
                    _taskQueue.Enqueue(task);
                }
            }
        }

        public bool Working()
        {
            lock (_taskQueue)
            {
                return _taskQueue.Count == 0;
            }
        }

        public void Stop()
        {
            while (!Working())
            {
                Thread.Sleep(100);
            }
            _Working = false;
        }
    }
}