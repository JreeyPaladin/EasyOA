using EasyOA.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyOA
{
    public partial class UserManage : Form
    {
        DALHelper dal = new DALHelper(ConfigurationManager.ConnectionStrings["OADBConnectionString"].ConnectionString);
        public UserManage()
        {
            InitializeComponent();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            dgv_UserType.DataSource = UserTypeData.Data;
            dgv_UserType.DisplayMember = "Name";
            dgv_UserType.ValueMember = "ID";
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
            DataSet ds = dal.GetList("[User]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int? id = dataGridView1.Rows[e.RowIndex].Cells[0].Value as int?;
            if (!id.HasValue)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            DataTable dt = dataGridView1.DataSource as DataTable;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int? id = item.Cells["dgv_Id"].Value as int?;
                string Account = item.Cells["dgv_Account"].Value as string;
                string Password = item.Cells["dgv_Password"].Value as string;
                string UserName = item.Cells["dgv_UserName"].Value as string;
                int? UserType = item.Cells["dgv_UserType"].Value as int?;
                if (id != null && !string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password))
                {
                    SqlParameter[] parms = new SqlParameter[5];
                    parms[0] = new SqlParameter("@Id", id);
                    parms[1] = new SqlParameter("@Account", Account);
                    parms[2] = new SqlParameter("@Password", Password);
                    parms[3] = new SqlParameter("@UserName", UserName);
                    parms[4] = new SqlParameter("@UserType", UserType);
                    if (dt.Select("Id=" + id.Value).Count() > 0)
                    {
                        dal.Update("[User]", "Account=@Account,Password=@Password,UserName=@UserName,UserType=@UserType", "Id=@Id", parms);
                    }
                    else
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into [User](");
                        strSql.Append("Id,Account,Password,UserName,UserType)");
                        strSql.Append(" values (@Id,@Account,@Password,@UserName,@UserType)");
                        strSql.Append(";select @@IDENTITY");
                        object obj = dal.DbHelperSQL.GetSingle(strSql.ToString(), parms);
                    }
                }
            }
        }
    }
}
