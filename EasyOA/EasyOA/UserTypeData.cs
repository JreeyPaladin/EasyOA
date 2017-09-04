using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EasyOA
{
    public class UserTypeData
    {
        public static DataTable Data = new DataTable();
        static UserTypeData()
        {
            Data.Columns.Add("ID", typeof(int));
            Data.Columns.Add("Name", typeof(string));
            Data.Rows.Add(-1, "");
            Data.Rows.Add(0, "队长");//队长必须是0，用于权限判断
            Data.Rows.Add(1, "组员");
        }
    }
}
