using NUnit.Framework;
using TaskManagerWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Moq;

namespace TaskManagerWebAPI.Controllers.Tests
{
    [TestFixture()]
    public class TaskControllerTests
    {
    
        [Test()]
        public void GetTest()
        {
            var mockRepos = new Mock<ITaskService>();
            mockRepos.Setup(x => x.GetById(42)).Returns(new TaskDO()
            {
                TaskId = 12,
                 IsParentTask=true, Task="MyTask"
            });
            var controller = new TaskController(mockRepos.Object);
            var result = controller.Get(42);
            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.TaskId);
            Assert.AreEqual("MyTask", result.TaskName);
            Assert.AreEqual(true, result.IsParentTask);
        }

        [Test()]
        public void GetTest1()
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

        [Test()]
        public void PostTest()
        {
            var mockRepos = new Mock<ITaskService>();

            mockRepos.Setup(x => x.Add(It.IsAny<TaskDO>())).Returns(1);

            var controller = new TaskController(mockRepos.Object);
            var result = controller.Post(new Models.TaskModel()
            {
                TaskId = 12,
                TaskName = "PR1",
                ParentTask = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test()]
        public void PutTest()
        {
            var mockRepos = new Mock<ITaskService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<TaskDO>())).Returns(1);

            var controller = new TaskController(mockRepos.Object);
            var result = controller.Put(new Models.TaskModel()
            {
                TaskId = 12,
                TaskName = "PR1",
                ParentTask = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test()]
        public void DeleteTest()
        {
            var mockRepos = new Mock<ITaskService>();

            mockRepos.Setup(x => x.Delete(It.IsAny<int>())).Returns(1);

            var controller = new TaskController(mockRepos.Object);
            var result = controller.Delete(12);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
    }
}