using System;

namespace Lab1
{
    public interface ITaskQueue : IDisposable
    {
        public delegate void TaskDelegate();

        public void EnqueueTask(TaskDelegate task);
    }
}