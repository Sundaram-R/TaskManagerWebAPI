﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.Entity;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private DataAccessLayer.ProjectTaskManagerEntities dbContext ;
        public UserService(DataAccessLayer.ProjectTaskManagerEntities dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(UserDO model)
        {
            var data = dbContext.tblUsers.Add(new tblUser()
            {
                EmployeeId = model.EmployeeId,
                FirstName = model.FirstName,
                LastName = model.LastName
            });
            return dbContext.SaveChanges();             
        }

        public int Delete(int id)
        {
            var data = dbContext.tblUsers.Remove(dbContext.tblUsers.FirstOrDefault(x=>x.User_id==id));
            return dbContext.SaveChanges();
        }

        public int Edit(UserDO model)
        {
            var editData = dbContext.tblUsers.First(x => x.User_id == model.User_id);

            editData.User_id = model.User_id;
            editData.EmployeeId = model.EmployeeId;
            editData.FirstName = model.FirstName;
            editData.LastName = model.LastName;
            return dbContext.SaveChanges();
        }

        public List<UserDO> GetAll()
        {
            var users = new List<UserDO>();
            var data = dbContext.tblUsers;
            foreach (var item in data)
            {
                users.Add(new UserDO() {
                    User_id = item.User_id,  EmployeeId=item.EmployeeId,
                    FirstName=item.FirstName, LastName=item.LastName
                });
            }
            return users;
        }

        public UserDO GetById(int id)
        {
            var data = dbContext.tblUsers.FirstOrDefault(x => x.User_id == id);
            var user = new UserDO()
            {
                User_id = data.User_id,
                EmployeeId = data.EmployeeId,
                FirstName = data.FirstName,
                LastName = data.LastName
            };
            return user;
        }
    }
}
