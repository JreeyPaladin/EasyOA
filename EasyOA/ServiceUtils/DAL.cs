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
        public User Login(string userName, string password)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@UserName", userName);
            parms[1] = new SqlParameter("@Password", password);
            DataSet ds = dal.GetList("[Users]", "UserName=@UserName and Password=@Password", parms);
            User user = new User();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    user.Id = (int)dr["Id"];
                    user.UserName = dr["UserName"] as string;
                    user.RoleId = (int)dr["RoleId"];
                    user.Password = dr["Password"] as string;
                }
            }
            return user;
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            DataSet ds = dal.GetList("(select u.*,r.RoleName,r.Powers from [Users] u inner join [Roles] r on u.RoleId=r.Id) T");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public bool DelUser(string ids)
        {
            return dal.DbHelperSQL.ExecuteSql("delete from [Users] where id in (" + ids + ")") > 0;
        }
        /// <summary>
        /// 检查用户是否有已经安排的任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckUserTask(int id)
        {
            return dal.GetRecordCount("(select a.*,b.Id as UserId from [Tasks] a inner join [Users] b on a.UserName=b.UserName) T", "UserId=" + id) > 0;
        }
        /// <summary>
        /// 添加或修改用户
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool AddOrUpdateUser(User user)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            StringBuilder strSql = new StringBuilder();
            if (user.Id > 0)
            {
                strSql.Append("update [Users] set");
                strSql.Append(" UserName=@UserName,Password=@Password,RoleId=@RoleId");
                strSql.Append(" where Id=@Id");
            }
            else
            {
                int Id = dal.GetMax("Id", "[Users]");
                user.Id = Id + 1;
                strSql.Append("insert into [Users](");
                strSql.Append("Id,UserName,Password,RoleId)");
                strSql.Append(" values (@Id,@UserName,@Password,@RoleId)");
            }
            parms.Add(new SqlParameter("@Id", user.Id));
            parms.Add(new SqlParameter("@UserName", user.UserName));
            parms.Add(new SqlParameter("@Password", user.Password));
            parms.Add(new SqlParameter("@RoleId", user.RoleId));

            return dal.DbHelperSQL.ExecuteSql(strSql.ToString(), parms) == 1;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleList()
        {
            DataSet ds = dal.GetList("[Roles]");
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
        public bool FinishTask(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Tasks] set TaskStatus=@TaskStatus where id=" + id);
            return dal.DbHelperSQL.ExecuteSql(strSql.ToString(), new SqlParameter("@TaskStatus", TaskStatus.已完成.ToString())) == 1;
        }
    }
}
