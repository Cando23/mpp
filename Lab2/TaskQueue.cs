    using System;
    using System.Collections.Generic;
    using System.Threading;

    namespace Lab2
    {
        public class TaskQueue :IDisposable
        {
            public delegate void TaskDelegate();

            private bool _working = true;
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
                while (_working)
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
                if (_disposed)
                    throw new ObjectDisposedException(ToString());
                if (task != null)
                {
                    lock (_taskQueue)
                    {
                        _taskQueue.Enqueue(task);
                    }
                }
            }

            private bool Empty()
            {
                lock (_taskQueue)
                {
                    return _taskQueue.Count == 0;
                }
            }

            private bool _disposed;
            
            public void Dispose()
            {
                if (!_disposed)
                {
                    while (true)
                    {
                        if (Empty())
                            break;
                        Thread.Sleep(1000);
                    }
                    _working = false;
                    _disposed = true;
                }
            }
        }
    }