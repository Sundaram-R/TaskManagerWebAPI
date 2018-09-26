using BusinessLayer;
using DataAccessLayer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer.Tests
{
    [TestFixture()]
    public class ProjectServiceTests
    {
        public ProjectTaskManagerEntities dbContext;
        public ProjectServiceTests()
        {
            dbContext = new ProjectTaskManagerEntities();
        }
        [Test()]
        public void AddTest()
        {
            var mockSet = new Mock<DbSet<tblProject>>();

            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblProjects).Returns(mockSet.Object);

            var service = new ProjectService(mockContext.Object);
            service.Add(new ProjectDO() { Project_Id = 12 });

            mockSet.Verify(m => m.Add(It.IsAny<tblProject>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [Test()]
        public void DeleteTest()
        {
            var data = new List<tblProject>() {
                new tblProject() { Project_Id=1 },
            new tblProject() { Project_Id=2 },
            new tblProject() { Project_Id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblProject>>();
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblProjects).Returns(mockSet.Object);
            var service = new ProjectService(mockContext.Object);
            var projects = service.Delete(1);
            mockSet.Verify(m => m.Remove(It.IsAny<tblProject>()), Times.Once());
        }

        [Test()]
        public void EditTest()
        {
            var data = new List<tblProject>() {
                new tblProject() { Project_Id=1, Project="Sample Project" },
            new tblProject() { Project_Id=2 },
            new tblProject() { Project_Id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblProject>>();
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.ElementType).Returns(data.ElementType);

            dbContext.tblProjects = mockSet.Object;
            var service = new ProjectService(dbContext);
            var projects = service.Edit(new ProjectDO() { Project_Id = 1, Project = "MyProject" });
            Assert.IsNotNull(projects);

        }

        [Test()]
        public void GetAllTest()
        {
            var data = new List<tblProject>() {
                new tblProject() { Project_Id=1 },
            new tblProject() { Project_Id=2 },
            new tblProject() { Project_Id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblProject>>();
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            dbContext.tblProjects = mockSet.Object;
            var service = new ProjectService(dbContext);
            var projects = service.GetAll();
            Assert.AreEqual(3, projects.Count);
            Assert.AreEqual(1, projects[0].Project_Id);
        }

        [Test()]
        public void GetByIdTest()
        {
            var data = new List<tblProject>() {
                new tblProject() { Project_Id=1 },
            new tblProject() { Project_Id=2 },
            new tblProject() { Project_Id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblProject>>();
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblProject>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblProjects).Returns(mockSet.Object);
            var service = new ProjectService(mockContext.Object);
            var project = service.GetById(3);
            Assert.AreEqual(3, project.Project_Id);

        }

        [Test()]
        public void AddThrowExceptionTest()
        {
            var mockSet = new Mock<DbSet<tblProject>>();

            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblProjects).Throws(new System.Exception("Error"));

            var service = new ProjectService(mockContext.Object);
          var returnValue=  service.Add(new ProjectDO() { Project_Id = 12 });
            Assert.IsNotNull(returnValue);
            Assert.AreEqual(0, returnValue);
        }
    }
}