using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAEntities
{
    [Serializable]
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskContent { get; set; }
        public string TaskStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string UserName { get; set; }
    }
}
