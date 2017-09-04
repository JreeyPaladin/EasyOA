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
    public partial class Login : Form
    {
        DALHelper dal = new DALHelper(ConfigurationManager.ConnectionStrings["OADBConnectionString"].ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = tbAccount.Text.Trim();
            string password = tbPassword.Text.Trim();

            ServerClient client = new ServerClient();
            string sendMsg = client.Format(string.Format("login|{0}|{1}", account, password));
            if (client.SendMessage(sendMsg) == "true")
            {
                this.Hide();
                UserManage um = new UserManage();
                um.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("登录名或密码错误！");
            }



            //SqlParameter[] parms = new SqlParameter[2];
            //parms[0] = new SqlParameter("@Account", account);
            //parms[1] = new SqlParameter("@Password", password);
            //if (dal.GetRecordCount("[User]", "Account=@Account and Password=@Password", parms) > 0)
            //{
            //    this.Hide();
            //    UserManage um = new UserManage();
            //    um.ShowDialog();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("登录名或密码错误！");
            //}
        }
    }
}
