using System;
using Xunit;
using Moq;
using BLL.DomainService;

namespace UnitTest
{
    public class TaskRepositoryTest
    {
        public TaskRepositoryTest()
        {

        }

        [Fact]
        public void Test()
        {
            Mock<ITaskRepo> readRepositoryMock = new Mock<ITaskRepo>();

        }

    }
}
