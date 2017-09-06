using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ServiceUtils
{
    public class DAL
    {
        private DALHelper dal = new DALHelper(ConfigurationManager.ConnectionStrings["OADBConnectionString"].ConnectionString);
        public bool Login(string account, string password)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@Account", account);
            parms[1] = new SqlParameter("@Password", password);
            return (dal.GetRecordCount("[Users]", "Account=@Account and Password=@Password", parms) > 0);
        }
    }
}
