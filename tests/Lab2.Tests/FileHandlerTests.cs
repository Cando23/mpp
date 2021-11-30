using System;
using System.IO;
using System.Threading;
using Lab1;
using Moq;
using Xunit;

namespace Lab2.Tests
{
    public class FileHandlerTests
    {
        private const string src = "C:/Users/Acer/Desktop/Test2";
        private const string dest = "C:/Users/Acer/Desktop";

        [Fact]
        public void CopyFiles_CallsEnqueueTask_Once()
        {
            var mock = new Mock<ITaskQueue>();
            mock.Setup(x => x.EnqueueTask(It.IsAny<ITaskQueue.TaskDelegate>()));
            using var fileHandler = new FileHandler(mock.Object);
            fileHandler.Copy(src, dest);
            mock.Verify(x => x.EnqueueTask(It.IsAny<ITaskQueue.TaskDelegate>()), Times.Once());
        }

        [Theory]
        [InlineData("C:/Users/Acer/Desktop/Test")]
        [InlineData("C:/Users/Acer/Desktop/Test2")]
        public void Copy_ReturnsExpectedCopyInfo(string source)
        {
            var directoryInfo = new DirectoryInfo(source);
            var directories = directoryInfo.GetDirectories("*", SearchOption.AllDirectories).Length;
            var files = directoryInfo.GetFiles("*", SearchOption.AllDirectories).Length;
            var queue = new TaskQueue(4);
            using var fileHandler = new FileHandler(queue);
            var info = fileHandler.Copy(source, dest);
            Assert.Equal(files, info.Files);
            Assert.Equal(directories, info.Directories);
        }
    }
}