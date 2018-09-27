using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using TaskManagerWebAPI.Controllers;

namespace WebAPI_LoadTest
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void GetTest1()
        {
            var mockRepos = new Mock<IUserService>();
            var mockData = new System.Collections.Generic.List<UserDO>();
            mockData.Add(new UserDO()
            {
                User_id = 42,
                EmployeeId = 122,
                FirstName = "Jack",
                LastName = "Jill"
            });
            mockData.Add(new UserDO()
            {
                User_id = 44,
                EmployeeId = 1232,
                FirstName = "Tom",
                LastName = "Jerry"
            });
            mockRepos.Setup(x => x.GetAll()).Returns(mockData);
            var controller = new UserController(mockRepos.Object);
            var result = controller.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(42, result.FirstOrDefault().id);
            Assert.AreEqual(122, result.FirstOrDefault().employeeId);
            Assert.AreEqual("Jack", result.FirstOrDefault().firstName);
            Assert.AreEqual("Jill", result.FirstOrDefault().lastName);
        }
    }
}
