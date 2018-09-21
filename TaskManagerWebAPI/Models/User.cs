using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.Models
{
    public class User
    {   public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int employeeId { get; set; }
    }
}