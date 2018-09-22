﻿using BusinessLayer;
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
            
            var result = userService.GetById(id);
            var user = new User() {
                id = result.User_id,
                employeeId = result.EmployeeId,
                firstName = result.FirstName,
                lastName = result.LastName
            };
            return user;
        }

        // POST: api/User
        public int Post(User value)
        {
            
            var user = userService.Add(new UserDO() {
                 User_id= value.id, EmployeeId = value.employeeId, FirstName =value.firstName, LastName=value.lastName
            });
           
            return user;
        }

        // PUT: api/User/5
        public int Put(User value)
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

        // DELETE: api/User/5
        public int Delete(int id)
        {
            var user = userService.Delete(id);
            return user;
        }
    }
}