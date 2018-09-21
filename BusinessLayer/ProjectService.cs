using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProjectService : IProjectService
    {
        private DataAccessLayer.ProjectTaskManagerEntities dbContext = new ProjectTaskManagerEntities();
        public int Add(ProjectDO model)
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

        public int Delete(int id)
        {
            var data = dbContext.tblProjects.Remove(dbContext.tblProjects.FirstOrDefault(x => x.Project_Id== id));
            return dbContext.SaveChanges();
        }

        public int Edit(ProjectDO model)
        {
            var editData= new tblProject()
            {
                EndDate = model.EndDate,
                ManagerId = model.ManagerId,
                Priority = model.Priority,
                Project = model.Project,
                Project_Id = model.Project_Id,
                StartDate = model.StartDate
            };
            dbContext.Entry(editData).State = System.Data.Entity.EntityState.Modified;
            return dbContext.SaveChanges();
        }

        public List<ProjectDO> GetAll()
        {
            var projects = new List<ProjectDO>();
            var data = dbContext.tblProjects;
            foreach (var model in data)
            {
                projects.Add(new ProjectDO()
                {
                    EndDate = model.EndDate,
                    ManagerId = model.ManagerId,
                    Priority = model.Priority,
                    Project = model.Project,
                    Project_Id = model.Project_Id,
                    StartDate = model.StartDate
                });
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
