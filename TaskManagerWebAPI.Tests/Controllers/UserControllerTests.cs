using TaskManagerWebAPI.Controllers;
using BusinessLayer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
        public void GetInvalidIdReturnNullTest()
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
            var result = controller.Get(44);
            Assert.IsNull(result);            
        }
        [Test()]
        public void PutTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<UserDO>())).Returns(1);

            UserController controller = new UserController(mockRepos.Object);
            var result = controller.Put(new Models.User()
            {
                id = 42,
                employeeId = 122,
                firstName = "Jack",
                lastName = "Jill"
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);

        }

        [Test()]
        public void GetTest1()
        {
            var mockRepos = new Mock<IUserService>();
            var mockData = new List<UserDO>();
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
            UserController controller = new UserController(mockRepos.Object);
            var result = controller.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(42, result.FirstOrDefault().id);
            Assert.AreEqual(122, result.FirstOrDefault().employeeId);
            Assert.AreEqual("Jack", result.FirstOrDefault().firstName);
            Assert.AreEqual("Jill", result.FirstOrDefault().lastName);
        }

        [Test()]
        public void PostTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Add(It.IsAny<UserDO>())).Returns(1);

            var controller = new UserController(mockRepos.Object);
            var result = controller.Post(new Models.User()
            {
                id = 42,
                employeeId = 122,
                firstName = "Jack",
                lastName = "Jill"
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test()]
        public void DeleteTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Delete(It.IsAny<int>())).Returns(1);

            UserController controller = new UserController(mockRepos.Object);
            var result = controller.Delete(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
        [Test()]
        public void PostExceptionTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Add(It.IsAny<UserDO>())).Throws(new System.Exception("Error"));

            var controller = new UserController(mockRepos.Object);
            var result = controller.Post(new Models.User()
            {
                id = 12,
                firstName = "PR1",
                employeeId = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }
        [Test()]
        public void PostNullTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Add(It.IsAny<UserDO>())).Returns(1);

            var controller = new UserController(mockRepos.Object);
            var result = controller.Post(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }
        [Test()]
        public void PutNullTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<UserDO>())).Returns(1);

            var controller = new UserController(mockRepos.Object);
            var result = controller.Put(null);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }
        [Test()]
        public void PutExceptionTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Edit(It.IsAny<UserDO>())).Throws(new System.Exception("Error"));

            var controller = new UserController(mockRepos.Object);
            var result = controller.Put(new Models.User()
            {
                id = 12,
                firstName = "PR1",
                employeeId = 1233
            });
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }

        [Test()]
        public void DeleteThrowExceptionTest()
        {
            var mockRepos = new Mock<IUserService>();

            mockRepos.Setup(x => x.Delete(It.IsAny<int>())).Throws(new System.Exception("Error"));

            var controller = new UserController(mockRepos.Object);
            var result = controller.Delete(12);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);

        }
    }
}