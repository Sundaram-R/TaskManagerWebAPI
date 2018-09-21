using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProjectService
    {
        List<ProjectDO> GetAll();
        ProjectDO GetById(int id);
        int Add(ProjectDO model);
        int Edit(ProjectDO model);
        int Delete(int id);
    }
}
