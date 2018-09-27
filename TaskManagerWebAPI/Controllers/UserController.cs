using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;
using TaskManagerWebAPI.Models;

namespace TaskManagerWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/User
        public IEnumerable<User> Get()
        {
            var users = new List<User>();
            var result = userService.GetAll();
            foreach (var user in result)
            {
                users.Add( new User() { id=user.User_id, employeeId=user.EmployeeId,
                     firstName=user.FirstName, lastName=user.LastName
                });
            }
            return users;
        }

        // GET: api/User/5
        public User Get(int id)
        {

            try
            {
                var result = userService.GetById(id);
                var user = new User()
                {
                    id = result.User_id,
                    employeeId = result.EmployeeId,
                    firstName = result.FirstName,
                    lastName = result.LastName
                };
                return user;
            }
            catch 
            {
                return null;
            }
        }

        // POST: api/User
        public int Post(User value)
        {
            if (value == null)
            {
                return 0;
            }
            try
            {
                var user = userService.Add(new UserDO()
                {
                    User_id = value.id,
                    EmployeeId = value.employeeId,
                    FirstName = value.firstName,
                    LastName = value.lastName
                });

                return user;
            }
            catch
            {
                return 0;
            }
        }

        // PUT: api/User/5
        public int Put(User value)
        {
            if (value == null)
            {
                return 0;
            }
            try
            {
                var user = userService.Edit(new UserDO()
                {
                    User_id = value.id,
                    EmployeeId = value.employeeId,
                    FirstName = value.firstName,
                    LastName = value.lastName
                });
                return user;
            }
            catch 
            {
                return 0;
            }
        }

        // DELETE: api/User/5
        public int Delete(int id)
        {
            try
            {
                var user = userService.Delete(id);
                return user;
            }
            catch 
            {
                return 0;
                
            }
        }
    }
}
