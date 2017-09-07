using OAEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ServiceUtils
{
    public class DAL
    {
        private DALHelper dal = new DALHelper(ConfigurationManager.ConnectionStrings["OADBConnectionString"].ConnectionString);
        /// <summary>
        /// 判断登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@UserName", userName);
            parms[1] = new SqlParameter("@Password", password);
            return (dal.GetRecordCount("[Users]", "UserName=@UserName and Password=@Password", parms) > 0);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            DataSet ds = dal.GetList("[Users]");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTaskList(Task whereTask)
        {
            string where = "1=1";
            List<SqlParameter> parms = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(whereTask.UserName))
            {
                where += " and UserName=@UserName";
                parms.Add(new SqlParameter("@UserName", whereTask.UserName));
            }
            if (!string.IsNullOrEmpty(whereTask.TaskStatus))
            {
                where += " and TaskStatus=@TaskStatus";
                parms.Add(new SqlParameter("@TaskStatus", whereTask.TaskStatus));
            }
            DataSet ds = dal.GetList("[Tasks]", where, parms, "", 0, "CreateTime desc");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool AddTask(Task task)
        {
            int Id = dal.GetMax("Id", "[Tasks]");
            SqlParameter[] parms = new SqlParameter[6];
            parms[0] = new SqlParameter("@Id", Id + 1);
            parms[1] = new SqlParameter("@TaskName", task.TaskName);
            parms[2] = new SqlParameter("@TaskContent", task.TaskContent);
            parms[3] = new SqlParameter("@TaskStatus", task.TaskStatus);
            parms[4] = new SqlParameter("@CreateTime", task.CreateTime);
            parms[5] = new SqlParameter("@UserName", task.UserName);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Tasks](");
            strSql.Append("Id,TaskName,TaskContent,TaskStatus,CreateTime,UserName)");
            strSql.Append(" values (@Id,@TaskName,@TaskContent,@TaskStatus,@CreateTime,@UserName)");
            return dal.DbHelperSQL.ExecuteSql(strSql.ToString(), parms) == 1;
        }
    }
}
