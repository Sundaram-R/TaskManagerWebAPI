using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerWebAPI.Models;

namespace TaskManagerWebAPI.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        // GET: api/Task
        public List<TaskModel> Get()
        {
            var tasks = new List<TaskModel>();
            var result = taskService.GetAll();
            foreach (var model in result)
            {
                tasks.Add(new TaskModel()
                {
                    EndDate = model.EndDate,
                    IsParentTask = model.IsParentTask,
                    ParentTask = model.ParentTask,
                    Priority = model.Priority,
                    ProjectID = model.ProjectID,
                    StartDate = model.StartDate,
                    Status = model.Status,
                    TaskName = model.Task,
                    TaskId = model.TaskId,
                    TaskOwner = model.TaskOwner
                });
            }
            return tasks;
        }

        // GET: api/Task/5
        public TaskModel Get(int id)
        {
            var result = taskService.GetById(id);
            var task = new TaskModel()
            {
                EndDate = result.EndDate,
                IsParentTask = result.IsParentTask,
                ParentTask = result.ParentTask,
                Priority = result.Priority,
                ProjectID = result.ProjectID,
                StartDate = result.StartDate,
                Status = result.Status,
                TaskName = result.Task,
                TaskId = result.TaskId,
                TaskOwner = result.TaskOwner
            };
            return task;
        }

        // POST: api/Task
        public int Post(TaskModel value)
        {
            if (value == null)
            {
                return 0;
            }
            try
            {
                var task = taskService.Add(new TaskDO()
                {
                    EndDate = value.EndDate,
                    IsParentTask = value.IsParentTask,
                    ParentTask = value.ParentTask,
                    Priority = value.Priority,
                    ProjectID = value.ProjectID,
                    StartDate = value.StartDate,
                    Status = value.Status,
                    Task = value.TaskName,
                    TaskId = value.TaskId,
                    TaskOwner = value.TaskOwner
                });

                return task;
            }
            catch 
            {
                return 0;
            }
        }

        // PUT: api/Task/5
        public int Put(TaskModel value)
        {
            if (value == null)
            {   return 0;
            }
            try
                {
                    var task = taskService.Edit(new TaskDO()
                    {
                        EndDate = value.EndDate,
                        IsParentTask = value.IsParentTask,
                        ParentTask = value.ParentTask,
                        Priority = value.Priority,
                        ProjectID = value.ProjectID,
                        StartDate = value.StartDate,
                        Status = value.Status,
                        Task = value.TaskName,
                        TaskId = value.TaskId,
                        TaskOwner = value.TaskOwner
                    });
                    return task;
                }
                catch
                {
                    return 0;
                }
            
            
            
        }

        // DELETE: api/Task/5
        public int Delete(int id)
        {
            try
            {
                var task = taskService.Delete(id);
                return task;
            }
            catch             {
                return 0;
            }
        }
    }
}
