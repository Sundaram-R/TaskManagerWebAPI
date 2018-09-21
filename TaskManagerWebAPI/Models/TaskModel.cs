﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Task { get; set; }
        public int ProjectID { get; set; }
        public bool IsParentTask { get; set; }
        public int? Priority { get; set; }
        public int? ParentTask { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TaskOwner { get; set; }
        public string Status { get; set; }
    }
}