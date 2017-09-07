using OAEntities;
using ServiceUtils.Sockets;
using System;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;

namespace EasyOA
{
    public partial class CreateTask : Form
    {
        Main main;
        DataTable UserData;
        public CreateTask(Main m, DataTable userData)
        {
            main = m;
            UserData = userData;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Task task = new Task()
            {
                TaskName = tbTaskName.Text,
                TaskContent = tbTaskContent.Text,
                TaskStatus = TaskStatus.未分配.ToString(),
                CreateTime = DateTime.Now,
                UserName = cmbUser.SelectedValue as string
            };
            main.SaveTask(task);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            main.BindTaskData();
            base.OnFormClosed(e);
        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            cmbUser.DataSource = UserData;
            cmbUser.DisplayMember = "UserName";
            cmbUser.ValueMember = "UserName";
        }
    }
}
