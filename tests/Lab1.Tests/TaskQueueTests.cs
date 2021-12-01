using System;
using System.Threading;
using Moq;
using Xunit;

namespace Lab1.Tests
{
    public class TaskQueueTests
    {
        [Fact]
        public void ProcessQueue_CallsTaskDelegate_Once()
        {
            var mock = new Mock<ITaskQueue.TaskDelegate>();
            using var queue = new TaskQueue(1);
            queue.EnqueueTask(mock.Object);
            Thread.Sleep(100);
            mock.Verify(f => f(), Times.Once);
        }

        [Fact]
        public void ProcessQueue_CallsTaskDelegate_Never()
        {
            var mock = new Mock<ITaskQueue.TaskDelegate>();
            using var queue = new TaskQueue(0);
            queue.EnqueueTask(mock.Object);
            mock.Verify(f => f(), Times.Never);
        }

        [Fact]
        public void EnqueueTask_TaskDelegateAddedAfterObjectWasDisposed_ThrowsObjectDisposedException()
        {
            var mock = new Mock<ITaskQueue.TaskDelegate>();
            var queue = new TaskQueue(4);
            queue.Dispose();
            Assert.Throws<ObjectDisposedException>(() => queue.EnqueueTask(mock.Object));
        }
    }
}