using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerWebAPI.Controllers.Tests
{
    [TestClass()]
    public class TaskControllerTests
    {
        [TestMethod()]
        public void GetAllTasksTest()
        {
            var mockRepos = new Mock<ITaskService>();
            var mockData = new List<TaskDO>();
            mockData.Add(new TaskDO()
            {
                TaskId = 12,
                Task = "PR1",
                ParentTask = 1233
            });
            mockData.Add(new TaskDO()
            {
                TaskId = 23,
                Task = "PR2",
                ParentTask = 113
            });
            mockRepos.Setup(x => x.GetAll()).Returns(mockData);
            var controller = new TaskController(mockRepos.Object);
            var result = controller.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(12, result.FirstOrDefault().TaskId);
            Assert.AreEqual("PR1", result.FirstOrDefault().TaskName);
            Assert.AreEqual(1233, result.FirstOrDefault().ParentTask);
        }
    }
}