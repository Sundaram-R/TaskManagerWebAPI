﻿using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;
using TaskManagerWebAPI.Models;

namespace TaskManagerWebAPI.Controllers
{
    public class ProjectController : ApiController
    {
        private IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        // GET: api/Project
        public List<ProjectModel> Get()
        {
            var projects = new List<ProjectModel>();
            var result = projectService.GetAll();
            foreach (var model in result)
            {
                projects.Add(new ProjectModel()
                {
                    EndDate = model.EndDate,
                    ManagerId = model.ManagerId,
                    Priority = model.Priority,
                    Project = model.Project,
                    Project_Id = model.Project_Id,
                    StartDate = model.StartDate, NoOfTasks =model.NoOfTasks,
                    TasksCompleted = model.TasksCompleted   
                });
            }
            return projects;
        }

        // GET: api/Project/5
        public ProjectModel Get(int id)
        {
            try
            {
                var result = projectService.GetById(id);
                var project = new ProjectModel()
                {
                    EndDate = result.EndDate,
                    ManagerId = result.ManagerId,
                    Priority = result.Priority,
                    Project = result.Project,
                    Project_Id = result.Project_Id,
                    StartDate = result.StartDate,
                    NoOfTasks = result.NoOfTasks
                };
                return project;
            }
            catch
            {
                return null;
            }

        }

        // POST: api/Project
        public int Post(ProjectModel value)
        {
            if (value == null)
            {
                return 0;
            }
            try
            {
                var project = projectService.Add(new ProjectDO()
                {
                    EndDate = value.EndDate,
                    ManagerId = value.ManagerId,
                    Priority = value.Priority,
                    Project = value.Project,
                    Project_Id = value.Project_Id,
                    StartDate = value.StartDate
                });

                return project;
            }
            catch 
            {
                return 0;
            }
        }

        // PUT: api/Project/5
        public int Put(ProjectModel value)
        {
            if (value == null)
            {
                return 0;
            }
            try
            {
                var project = projectService.Edit(new ProjectDO()
                {
                    EndDate = value.EndDate,
                    ManagerId = value.ManagerId,
                    Priority = value.Priority,
                    Project = value.Project,
                    Project_Id = value.Project_Id,
                    StartDate = value.StartDate
                });
                return project;
            }
            catch 
            {
                return 0;
            }
        }

        // DELETE: api/Project/5
        public int Delete(int id)
        {
            try
            {
                var project = projectService.Delete(id);
                return project;
            }
            catch 
            {
                return 0;
            }
        }
    }
}
