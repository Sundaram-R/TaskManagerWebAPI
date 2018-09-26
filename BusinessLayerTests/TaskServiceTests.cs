using NUnit.Framework;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using DataAccessLayer;

namespace BusinessLayer.Tests
{
    [TestFixture()]
    public class TaskServiceTests
    {
        public ProjectTaskManagerEntities dbContext;
        public TaskServiceTests()
        {
            dbContext = new ProjectTaskManagerEntities();
        }
        [Test()]
        public void AddTest()
        {
            var mockSet = new Mock<DbSet<tblTask>>();

            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblTasks).Returns(mockSet.Object);

            var service = new TaskService(mockContext.Object);
            service.Add(new TaskDO() { TaskId = 12 });

            mockSet.Verify(m => m.Add(It.IsAny<tblTask>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test()]
        public void DeleteTest()
        {
            var data = new List<tblTask>() {
                new tblTask() { TaskId=1 },
            new tblTask() { TaskId=2 },
            new tblTask() { TaskId=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblTask>>();
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.ElementType).Returns(data.ElementType);
            
            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblTasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);
            var projects = service.Delete(1);
            mockSet.Verify(m => m.Remove(It.IsAny<tblTask>()), Times.Once());
        }

        [Test()]
        public void EditTest()
        {
            var data = new List<tblTask>() {
                new tblTask() { TaskId=12 },
            new tblTask() { TaskId=2 },
            new tblTask() { TaskId=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblTask>>();
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.ElementType).Returns(data.ElementType);

            dbContext.tblTasks = mockSet.Object;
            var service = new TaskService(dbContext);
            var returnValue = service.Edit(new TaskDO() { TaskId = 12 });
            Assert.IsNotNull(returnValue);

        }

        [Test()]
        public void GetAllTest()
        {
            var data = new List<tblTask>() {
                new tblTask() { TaskId=1 },
            new tblTask() { TaskId=2 },
            new tblTask() { TaskId=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblTask>>();
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblTasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);
            var tasks = service.GetAll();
            Assert.AreEqual(3, tasks.Count);
            Assert.AreEqual(1, tasks[0].TaskId);
        }

        [Test()]
        public void GetByIdTest()
        {
            var data = new List<tblTask>() {
                new tblTask() { TaskId=1 },
            new tblTask() { TaskId=2 },
            new tblTask() { TaskId=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblTask>>();
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblTask>>().Setup(m => m.ElementType).Returns(data.ElementType);
            
            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblTasks).Returns(mockSet.Object);
            var service = new TaskService(mockContext.Object);
            var tasks = service.GetById(2);
            Assert.AreEqual(2, tasks.TaskId);
            
        }
    }
}