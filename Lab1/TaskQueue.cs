using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Lab1
{
    public class TaskQueue
    {
        public delegate void TaskDelegate();

        private readonly ConcurrentQueue<TaskDelegate> _taskQueue;
        public TaskQueue(int count)
        {
            _taskQueue = new ConcurrentQueue<TaskDelegate>();
            var threads = new Thread[count];
            for(var i = 0; i < count; i++)
            {
                threads[i] = new Thread(ProcessQueue) {Name = "Name " + i};
                threads[i].Start();
            }
        }
        private void ProcessQueue()
        {
            while (true)
            {
                _taskQueue.TryDequeue(out var task);
                try
                {
                    task?.Invoke();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public void EnqueueTask(TaskDelegate task)
        { 
            _taskQueue.Enqueue(task);
        }
        
    }
}