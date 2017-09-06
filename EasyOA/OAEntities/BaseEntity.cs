using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAEntities
{
    [Serializable]
    public class BaseEntity
    {
        public string Action { get; set; }
        public object Data { get; set; }
        public BaseEntity() { }
        public BaseEntity(string action,object data) {
            Action = action;
            Data = data;
        }
    }
}
