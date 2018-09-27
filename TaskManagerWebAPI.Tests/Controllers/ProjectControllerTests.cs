using TaskManagerWebAPI.Controllers;
using BusinessLayer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerWebAPI.Controllers.Tests
{
    [TestFixture()]
    public class ProjectControllerTests
    {

        [Test()]
        public void GetTest()
        {
            var mockRepos = new Mock<IProjectService>();
            mockRepos.Setup(x => x.GetById(42)).Returns(new ProjectDO()
            {
                Project_Id = 12,
                Project = "Project 1"
            });
            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Get(42);
            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.Project_Id);
            Assert.AreEqual("Project 1", result.Project);
        }
        [Test()]
        public void GetInvalidDataTest()
        {
            var mockRepos = new Mock<IProjectService>();
            mockRepos.Setup(x => x.GetById(42)).Returns(new ProjectDO()
            {
                Project_Id = 42,
                Project = "Project 1"
            });
            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Get(4);
            Assert.IsNull(result);
            
        }
        [Test()]
        public void GetTest1()
        {
            var mockRepos = new Mock<IProjectService>();
            var mockData = new List<ProjectDO>();
            mockData.Add(new ProjectDO()
            {
                Project_Id = 12,
                Project = "PR1",
                ManagerId = 1233
            });
            mockData.Add(new ProjectDO()
            {
                Project_Id = 23,
                Project = "PR2",
                ManagerId = 113
            });
            mockRepos.Setup(x => x.GetAll()).Returns(mockData);
            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(12, result.FirstOrDefault().Project_Id);
            Assert.AreEqual("PR1", result.FirstOrDefault().Project);
            Assert.AreEqual(1233, result.FirstOrDefault().ManagerId);

        }

        [Test()]
        public void PostTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Add(It.IsAny<ProjectDO>())).Returns(1);

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Post(new Models.ProjectModel()
            {
                Project_Id = 12,
                Project = "PR1",
                ManagerId = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test()]
        public void PutTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<ProjectDO>())).Returns(1);

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Put(new Models.ProjectModel()
            {
                Project_Id = 12,
                Project = "PR1",
                ManagerId = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test()]
        public void DeleteTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Delete(It.IsAny<int>())).Returns(1);

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Delete(12);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test()]
        public void PostNullTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Add(It.IsAny<ProjectDO>())).Returns(1);

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Post(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }

        [Test()]
        public void PutNullTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<ProjectDO>())).Returns(1);

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Put(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }
        [Test()]
        public void PutExceptionTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<ProjectDO>())).Throws(new System.Exception("Error"));

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Put(new Models.ProjectModel()
            {
                Project_Id = 12,
                Project = "PR1",
                ManagerId = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }
        [Test()]
        public void PostExceptionTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Add(It.IsAny<ProjectDO>())).Throws(new System.Exception("Error"));

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Post(new Models.ProjectModel()
            {
                Project_Id = 12,
                Project = "PR1",
                ManagerId = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }
        [Test()]
        public void DeleteThrowExceptionTest()
        {
            var mockRepos = new Mock<IProjectService>();

            mockRepos.Setup(x => x.Delete(It.IsAny<int>())).Throws(new System.Exception("Error"));

            var controller = new ProjectController(mockRepos.Object);
            var result = controller.Delete(12);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }
    }
}