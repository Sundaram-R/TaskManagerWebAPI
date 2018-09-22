﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TaskService : ITaskService
    {
        private DataAccessLayer.ProjectTaskManagerEntities dbContext = new ProjectTaskManagerEntities();
        public int Add(TaskDO model)
        {
            var data = dbContext.tblTasks.Add(new tblTask()
            {
                EndDate = model.EndDate,
                IsParentTask = model.IsParentTask,
                ParentTask = model.ParentTask,
                Priority = model.Priority,
                ProjectID = model.ProjectID,
                StartDate = model.StartDate,
                Status = model.Status,
                Task = model.Task,
                TaskId = model.TaskId,
                TaskOwner = model.TaskOwner
            });
            return dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var data = dbContext.tblTasks.Remove(dbContext.tblTasks.FirstOrDefault(x => x.TaskId == id));
            return dbContext.SaveChanges();
        }

        public int Edit(TaskDO model)
        {
            var editData = new tblTask()
            {
                EndDate = model.EndDate,
                IsParentTask = model.IsParentTask,
                ParentTask = model.ParentTask,
                Priority = model.Priority,
                ProjectID = model.ProjectID,
                StartDate = model.StartDate,
                Status = model.Status,
                Task = model.Task,
                TaskId = model.TaskId,
                TaskOwner = model.TaskOwner
            };
            dbContext.Entry(editData).State = System.Data.Entity.EntityState.Modified;
            return dbContext.SaveChanges();
        }

        public List<TaskDO> GetAll()
        {
            var tasks = new List<TaskDO>();
            var data = dbContext.tblTasks;
            foreach (var model in data)
            {
                tasks.Add(new TaskDO()
                {
                    EndDate = model.EndDate,
                    IsParentTask = model.IsParentTask,
                    ParentTask = model.ParentTask,
                    Priority = model.Priority,
                    ProjectID = model.ProjectID,
                    StartDate = model.StartDate,
                    Status = model.Status,
                    Task = model.Task,
                    TaskId = model.TaskId,
                    TaskOwner = model.TaskOwner
                });
            }
            return tasks;
        }

        public TaskDO GetById(int id)
        {
            var model = dbContext.tblTasks.FirstOrDefault(x => x.TaskId == id);
            var task = new TaskDO()
            {
                EndDate = model.EndDate,
                IsParentTask = model.IsParentTask,
                ParentTask = model.ParentTask,
                Priority = model.Priority,
                ProjectID = model.ProjectID,
                StartDate = model.StartDate,
                Status = model.Status,
                Task = model.Task,
                TaskId = model.TaskId,
                TaskOwner = model.TaskOwner
            };
            return task;
        }
    }
}