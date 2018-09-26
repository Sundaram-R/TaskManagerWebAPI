using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProjectService : IProjectService
    {
        private DataAccessLayer.ProjectTaskManagerEntities dbContext;
        public ProjectService(DataAccessLayer.ProjectTaskManagerEntities dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(ProjectDO model)
        {
            try
            {
                var data = dbContext.tblProjects.Add(new tblProject()
                {
                    EndDate = model.EndDate,
                    ManagerId = model.ManagerId,
                    Priority = model.Priority,
                    Project = model.Project,
                    Project_Id = model.Project_Id,
                    StartDate = model.StartDate
                });
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

        public int Delete(int id)
        {
            var data = dbContext.tblProjects.Remove(dbContext.tblProjects.FirstOrDefault(x => x.Project_Id== id));
            return dbContext.SaveChanges();
        }

        public int Edit(ProjectDO model)
        {
            var editData = dbContext.tblProjects.First(x => x.Project_Id == model.Project_Id);
            editData.EndDate = model.EndDate;
            editData.ManagerId = model.ManagerId;
            editData.Priority = model.Priority;
            editData.Project = model.Project;
            editData.Project_Id = model.Project_Id;
            editData.StartDate = model.StartDate;        
            return dbContext.SaveChanges();
        }

        public List<ProjectDO> GetAll()
        {
            var projects = new List<ProjectDO>();
            var data = dbContext.tblProjects;
            foreach (var model in data)
            {
                var projectData =new ProjectDO()
                {
                    EndDate = model.EndDate,
                    ManagerId = model.ManagerId,
                    Priority = model.Priority,
                    Project = model.Project,
                    Project_Id = model.Project_Id,
                    StartDate = model.StartDate
                    
                };
                projectData.NoOfTasks = dbContext.tblTasks.Count(s => s.ProjectID == projectData.Project_Id);
                projectData.TasksCompleted = dbContext.tblTasks.Count(s => s.ProjectID == projectData.Project_Id
                && s.Status=="Completed" );
                projects.Add(projectData);
            }
            return projects;
        }

        public ProjectDO GetById(int id)
        {
            var model = dbContext.tblProjects.FirstOrDefault(x => x.Project_Id == id);
            var project = new ProjectDO()
            {
                EndDate = model.EndDate,
                ManagerId = model.ManagerId,
                Priority = model.Priority,
                Project = model.Project,
                Project_Id = model.Project_Id,
                StartDate = model.StartDate
            };
            return project;
        }
    }
}
