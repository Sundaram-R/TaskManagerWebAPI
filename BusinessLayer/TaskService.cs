using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TaskService : ITaskService
    {
        private DataAccessLayer.ProjectTaskManagerEntities dbContext ;
        public TaskService(DataAccessLayer.ProjectTaskManagerEntities dbContext)
        {
            this.dbContext = dbContext;
        }
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
            var editData = dbContext.tblTasks.First(x => x.TaskId == model.TaskId);
            editData.EndDate = model.EndDate;
            editData.IsParentTask = model.IsParentTask;
            editData.ParentTask = model.ParentTask;
            editData.Priority = model.Priority;
            editData.ProjectID = model.ProjectID;
            editData.StartDate = model.StartDate;
            editData.Status = model.Status;
            editData.Task = model.Task;
            editData.TaskId = model.TaskId;
            editData.TaskOwner = model.TaskOwner;
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
