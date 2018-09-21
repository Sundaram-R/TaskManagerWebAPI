using System.Collections.Generic;

namespace BusinessLayer
{
    public interface ITaskService
    {
        int Add(TaskDO model);
        int Delete(int id);
        int Edit(TaskDO model);
        List<TaskDO> GetAll();
        TaskDO GetById(int id);
    }
}