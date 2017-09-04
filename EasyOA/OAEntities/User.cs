using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAEntities
{
    public class User 
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int UserType { get; set; }
    }
}
