using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerAPI.Models
{
    public class TaskModel
    {
        public int id { get; set; }
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int ParentTaskID { get; set; }
        public string ParentTaskName { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}