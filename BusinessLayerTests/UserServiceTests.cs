using DataAccessLayer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLayer.Tests
{
    [TestFixture()]
    public class UserServiceTests
    {
        
        [Test()]
        public void AddTest()
        {
            var mockSet = new Mock<DbSet<tblUser>>();

            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblUsers).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            service.Add(new UserDO() { User_id = 12 });

            mockSet.Verify(m => m.Add(It.IsAny<tblUser>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [Test()]
        public void DeleteTest()
        {
            var data = new List<tblUser>() {
                new tblUser() { User_id=1 },
            new tblUser() { User_id=2 },
            new tblUser() { User_id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblUser>>();
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.ElementType).Returns(data.ElementType);
            
            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblUsers).Returns(mockSet.Object);
            var service = new UserService(mockContext.Object);
            var users = service.Delete(1);
            mockSet.Verify(m => m.Remove(It.IsAny<tblUser>()), Times.Once());
        }

        [Test()]
        public void EditTest()
        {
            ProjectTaskManagerEntities dbContext = new ProjectTaskManagerEntities();
            var data = new List<tblUser>() {
                new tblUser() { User_id=12 },
            new tblUser() { User_id=2 },
            new tblUser() { User_id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblUser>>();
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.ElementType).Returns(data.ElementType);
        
            dbContext.tblUsers = mockSet.Object;
            
            
            var service = new UserService(dbContext);
          var returnValue =  service.Edit(new UserDO() { User_id = 12 });
            Assert.NotNull(returnValue);
        }

        [Test()]
        public void GetAllTest()
        {
            var data = new List<tblUser>() {
                new tblUser() { User_id=1 },
            new tblUser() { User_id=2 },
            new tblUser() { User_id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblUser>>();
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblUsers).Returns(mockSet.Object);
            var service = new UserService(mockContext.Object);
            var users= service.GetAll();
            Assert.AreEqual(3, users.Count);
            Assert.AreEqual(1, users[0].User_id);
        }

        [Test()]
        public void GetByIdTest()
        {
            var data = new List<tblUser>() {
                new tblUser() { User_id=1 },
            new tblUser() { User_id=2, EmployeeId=122 },
            new tblUser() { User_id=3 }
            }.AsQueryable();
            var mockSet = new Mock<DbSet<tblUser>>();
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<tblUser>>().Setup(m => m.ElementType).Returns(data.ElementType);
            
            var mockContext = new Mock<ProjectTaskManagerEntities>();
            mockContext.Setup(m => m.tblUsers).Returns(mockSet.Object);
            var service = new UserService(mockContext.Object);
            var user = service.GetById(2);
            Assert.AreEqual(2, user.User_id);
            Assert.AreEqual(122, user.EmployeeId);
        }
    }
}