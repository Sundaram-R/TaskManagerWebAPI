using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerWebAPI.Controllers.Tests
{
    [TestClass()]
    public class ProjectControllerTests
    {
        [TestMethod()]
        public void GetAllProjectTest()
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
    }
}