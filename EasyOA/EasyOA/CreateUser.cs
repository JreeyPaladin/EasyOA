using OAEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyOA
{
    public partial class CreateUser : Form
    {
        Main main;
        DataTable role;
        public CreateUser(Main _main, DataTable _role)
        {
            main = _main;
            role = _role;
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            cbRole.Items.Clear();
            cbRole.DataSource = role;
            cbRole.DisplayMember = "RoleName";
            cbRole.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserName = tbUserName.Text.Trim(),
                Password = "123456",
                RoleId = (int)cbRole.SelectedValue
            };
            main.SaveUser(user);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            main.BindUserData();
            base.OnFormClosed(e);
        }
    }
}
