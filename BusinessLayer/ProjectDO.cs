using System;

namespace BusinessLayer
{
    public class ProjectDO
    {
        public int Project_Id { get; set; }
        public string Project { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public int ManagerId { get; set; }
        public int NoOfTasks { get; set; }
        public int TasksCompleted { get; set; }
    }
}
