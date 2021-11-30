using System.Collections.Generic;
using Lab1;
using Moq;
using Xunit;
using System.Linq;
namespace Lab5.tests
{

    public class ParallelTests
    {
        [Fact]
        public void WaitAll_CallsEachTaskDelegate_EachTaskDelegateWasCalledOnce()
        {
            var mocks = new[]
            {
                new Mock<ITaskQueue.TaskDelegate>(),
                new Mock<ITaskQueue.TaskDelegate>(),
                new Mock<ITaskQueue.TaskDelegate>(),
            };
            IEnumerable<ITaskQueue.TaskDelegate> tasks = mocks.Select(i => i.Object);
            Parallel.WaitAll(tasks.ToArray());
            foreach (var mock in mocks)
            {
                mock.Verify(f => f(), Times.Once);
            }
        }
    }
}