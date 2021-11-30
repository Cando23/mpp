    using System;
    using System.Collections.Generic;
    using System.Threading;

    namespace Lab1
    {
        public class TaskQueue :ITaskQueue
        {
            private bool _working = true;
            private Thread[] _threads;
            private readonly Queue<ITaskQueue.TaskDelegate> _taskQueue;
            private bool _disposed;

            public TaskQueue(int count)
            {
                _taskQueue = new Queue<ITaskQueue.TaskDelegate>();
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
                    ITaskQueue.TaskDelegate task = null;
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

            public void EnqueueTask(ITaskQueue.TaskDelegate task)
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
                    if (_threads.Length == 0)
                        return true;
                    return _taskQueue.Count == 0;
                }
            }
            
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