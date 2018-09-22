using NUnit.Framework;
using TaskManagerWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BusinessLayer;

namespace TaskManagerWebAPI.Controllers.Tests
{
    [TestFixture()]
    public class UserControllerTests
    {
        [Test()]
        public void GetTest()
        {
            var mockRepos = new Mock<IUserService>();
            mockRepos.Setup(x => x.GetById(42)).Returns(new UserDO()
            {
                User_id = 42,
                EmployeeId = 122,
                FirstName = "Jack",
                LastName = "Jill"
            });
            UserController controller = new UserController(mockRepos.Object);
            var result = controller.Get(42);
            Assert.IsNotNull(result);
            Assert.AreEqual(42, result.id);
            Assert.AreEqual(122, result.employeeId);
            Assert.AreEqual("Jack", result.firstName);
            Assert.AreEqual("Jill", result.lastName);
        }

        [Test()]
        public void PutTest()
        {
            var mockRepos = new Mock<IUserService>();
            mockRepos.Setup(x => x.Edit(new UserDO()
            {
                User_id = 42,
                EmployeeId = 122,
                FirstName = "Jack",
                LastName = "Jill"
            })).Returns(0);
            UserController controller = new UserController(mockRepos.Object);
            var result = controller.Put(new Models.User() {
                id = 42,
                employeeId = 122,
                firstName = "Jack",
                lastName = "Jill"
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
            
        }
    }
}