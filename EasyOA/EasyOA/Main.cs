using OAEntities;
using ServiceUtils.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace EasyOA
{
    public partial class Main : Form
    {
        protected TcpClientPlus tcpClient = new TcpClientPlus(AppConfig.IP, AppConfig.Port);
        public Main(User loginUser)
        {
            LoginUser = loginUser;
            InitializeComponent();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tcpClient.Close();
            base.OnFormClosed(e);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (LoginUser.RoleId == 1)
            {

            }
            else if (LoginUser.RoleId == 2)
            {

            }
            else if (LoginUser.RoleId == 3)
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage_Task"]);
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage_User"]);
            }
            else
            {
                MessageBox.Show("无权限");
                this.Close();
            }
        }
        #region 任务管理
        #region 绑定Task
        public void BindTaskData()
        {
            if (!tcpClient.ThreadTaskAllocation(HandleClientComm))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        private void BindDGVData(DataGridView dgv, DataTable dt)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<DataTable>((msg) =>
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = dt;
                    toolStripStatusLabel1.Text = "总计：" + dt.Rows.Count + "条记录";
                }), dt);
            }
            else
            {
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = dt;
                toolStripStatusLabel1.Text = "总计：" + dt.Rows.Count + "条记录";
            }
        }
        private void HandleClientComm(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("gettasklist");
                    sendBase.Data = new Task()
                    {
                        UserName = GetUserName(),
                        TaskStatus = GetTaskStatus()
                    };
                    byte[] receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    DataTable dt = receive.DeserializeToObject() as DataTable;
                    BindDGVData(taskDgv, dt);
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBoxPlus.Show(this, "连接中断！", "信息");
                    }
                    else
                    {
                        //SetNote("操作失败异常原因：" + type.Name + "\r\n\r\n");
                    }
                }
            }
        }
        #endregion
        #region 绑定UserData
        DataTable UserData;
        private void HandleBind用户Tool(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("getuserlist");
                    byte[] receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    UserData = receive.DeserializeToObject() as DataTable;
                    Set用户ToolUserData();
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBoxPlus.Show(this, "连接中断！", "信息");
                    }
                    else
                    {
                        //SetNote("操作失败异常原因：" + type.Name + "\r\n\r\n");
                    }
                }
            }
        }

        private void Set用户ToolUserData()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    用户ToolStripComboBox.Items.Add("选择用户");
                    foreach (DataRow item in UserData.Rows)
                    {
                        用户ToolStripComboBox.Items.Add(item["UserName"]);
                    }
                    //用户ToolStripComboBox.SelectedIndex = 0;
                }));
            }
            else
            {
                用户ToolStripComboBox.Items.Add("选择用户");
                foreach (DataRow item in UserData.Rows)
                {
                    用户ToolStripComboBox.Items.Add(item["UserName"]);
                }
                //用户ToolStripComboBox.SelectedIndex = 0;
            }
        }
        private string GetUserName()
        {
            if (this.InvokeRequired)
            {
                return (string)this.Invoke(new Func<string>(() =>
                {
                    if (用户ToolStripComboBox.SelectedItem == null || 用户ToolStripComboBox.SelectedItem.ToString() == "选择用户")
                        return "";
                    return 用户ToolStripComboBox.SelectedItem.ToString();
                }));
            }
            else
            {
                if (用户ToolStripComboBox.SelectedItem == null || 用户ToolStripComboBox.SelectedItem.ToString() == "选择用户")
                    return "";
                return 用户ToolStripComboBox.SelectedItem.ToString();
            }
        }
        private string GetTaskStatus()
        {
            if (this.InvokeRequired)
            {
                return (string)this.Invoke(new Func<string>(() =>
                {
                    if (状态ToolStripComboBox.SelectedItem == null || 状态ToolStripComboBox.SelectedItem.ToString() == "任务状态")
                        return "";
                    return 状态ToolStripComboBox.SelectedItem.ToString();
                }));
            }
            else
            {
                if (状态ToolStripComboBox.SelectedItem == null || 状态ToolStripComboBox.SelectedItem.ToString() == "任务状态")
                    return "";
                return 状态ToolStripComboBox.SelectedItem.ToString();
            }
        }
        #endregion
        CreateTask createTask;
        private void 新建任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTask = new CreateTask(this, UserData);
            createTask.ShowDialog();
        }
        Task task;
        public void SaveTask(Task _task)
        {
            task = _task;
            if (!tcpClient.ThreadTaskAllocation(HandleSaveTask))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        private void HandleSaveTask(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("addtask");
                    sendBase.Data = task;
                    string receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    if (receive == "true")
                    {
                        createTask.Invoke(new Action(createTask.Close));
                    }
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBox.Show("连接中断！");
                    }
                    else
                    {
                        //MessageBox.Show("操作失败异常原因：" + type.Name);
                    }
                }
            }
        }

        private void 状态ToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTaskData();
        }

        private void 用户ToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTaskData();
        }
        #endregion
        #region 用户管理
        CreateUser createUser;
        DataTable RoleData;
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createUser = new CreateUser(this, RoleData);
            createUser.ShowDialog();
        }
        private void HandleGetRoleList(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("getrolelist");
                    byte[] receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    RoleData = receive.DeserializeToObject() as DataTable;
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBoxPlus.Show(this, "连接中断！", "信息");
                    }
                    else
                    {
                        //SetNote("操作失败异常原因：" + type.Name + "\r\n\r\n");
                    }
                }
            }
        }
        public void BindUserData()
        {
            if (!tcpClient.ThreadTaskAllocation(HandleGetUserList))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        User user;
        public void SaveUser(User _user)
        {
            user = _user;
            if (!tcpClient.ThreadTaskAllocation(HandleSaveUser))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        private void HandleSaveUser(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("adduser");
                    sendBase.Data = user;
                    string receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    if (receive == "true")
                    {
                        ShowPlus("添加成功！");
                        createUser.Invoke(new Action(createUser.Close));
                    }
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBox.Show("连接中断！");
                    }
                    else
                    {
                        //MessageBox.Show("操作失败异常原因：" + type.Name);
                    }
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!tcpClient.ThreadTaskAllocation(HandleDelUser))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        private void HandleDelUser(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("deluser");
                    sendBase.Data = GetDelUser();
                    string receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    if (receive == "true")
                    {
                        ShowPlus("删除成功！");
                        sendBase = new BaseEntity("getuserlist");
                        byte[] receive2;
                        client.Query(sendBase.SerializeToBytes(), out receive2);
                        UserData = receive2.DeserializeToObject() as DataTable;
                        BindDGVData(userDgv, UserData);
                    }
                }
                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBox.Show("连接中断！");
                    }
                    else
                    {
                        //MessageBox.Show("操作失败异常原因：" + type.Name);
                    }
                }
            }
        }
        string GetDelUser()
        {
            if (this.InvokeRequired)
            {
                return (string)this.Invoke(new Func<string>(() =>
                {
                    string ids = "";
                    foreach (DataGridViewRow item in userDgv.SelectedRows)
                    {
                        ids += "," + item.Cells[0].Value;
                    }
                    return ids.TrimStart(',');
                }));
            }
            else
            {
                string ids = "";
                foreach (DataGridViewRow item in userDgv.SelectedRows)
                {
                    ids += "," + item.Cells[0].Value;
                }
                return ids.TrimStart(',');
            }
        }
        #region 绑定用户列表
        private void HandleGetUserList(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("getuserlist");
                    byte[] receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    UserData = receive.DeserializeToObject() as DataTable;
                    BindDGVData(userDgv, UserData);
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBoxPlus.Show(this, "连接中断！", "信息");
                    }
                    else
                    {
                        //SetNote("操作失败异常原因：" + type.Name + "\r\n\r\n");
                    }
                }
            }
        }
        #endregion
        #endregion
        #region 我的任务
        public void BindMyTask()
        {
            if (!tcpClient.ThreadTaskAllocation(HandleMyTask))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        User LoginUser = new User();
        private void HandleMyTask(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("gettasklist");
                    sendBase.Data = new Task()
                    {
                        UserName = LoginUser.UserName
                    };
                    byte[] receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    DataTable dt = receive.DeserializeToObject() as DataTable;
                    BindDGVData(myTaskDgv, dt);
                }

                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBoxPlus.Show(this, "连接中断！", "信息");
                    }
                    else
                    {
                        //SetNote("操作失败异常原因：" + type.Name + "\r\n\r\n");
                    }
                }
            }
        }
        #endregion
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "任务管理")
            {
                if (状态ToolStripComboBox.Items.Count == 0)
                {
                    状态ToolStripComboBox.Items.Add("任务状态");
                    foreach (var item in Enum.GetValues(typeof(TaskStatus)))
                    {
                        状态ToolStripComboBox.Items.Add(item);
                    }
                }
                用户ToolStripComboBox.Items.Clear();
                if (!tcpClient.ThreadTaskAllocation(HandleBind用户Tool))
                {
                    MessageBox.Show("通信信道忙！");
                }
                BindTaskData();
            }
            else if (tabControl1.SelectedTab.Text == "我的任务")
            {
                BindMyTask();
            }
            else if (tabControl1.SelectedTab.Text == "用户管理")
            {
                BindUserData();
                if (!tcpClient.ThreadTaskAllocation(HandleGetRoleList))
                {
                    MessageBox.Show("通信信道忙！");
                }
            }
        }
        int FinishTaksId = 0;
        private void myTaskDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = myTaskDgv.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    if (MessageBox.Show("确认完成任务吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        FinishTaksId = (int)myTaskDgv.Rows[e.RowIndex].Cells["dgvMyTask_Id"].Value;
                        if (!tcpClient.ThreadTaskAllocation(HandleFinishTask))
                        {
                            MessageBox.Show("通信信道忙！");
                        }
                    }
                }
            }
        }
        private void HandleFinishTask(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("finishtask");
                    sendBase.Data = FinishTaksId;
                    string receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    if (receive == "true")
                    {
                        sendBase = new BaseEntity("gettasklist");
                        sendBase.Data = new Task()
                        {
                            UserName = LoginUser.UserName
                        };
                        byte[] receive2;
                        client.Query(sendBase.SerializeToBytes(), out receive2);
                        DataTable dt = receive2.DeserializeToObject() as DataTable;
                        BindDGVData(myTaskDgv, dt);
                    }
                }
                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBox.Show("连接中断！");
                    }
                    else
                    {
                        //MessageBox.Show("操作失败异常原因：" + type.Name);
                    }
                }
            }
        }
        private void HandleSavePwd(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    BaseEntity sendBase = new BaseEntity("adduser");
                    User user = LoginUser;
                    user.Password = newPassword;
                    sendBase.Data = user;
                    string receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    if (receive == "true")
                    {
                        ShowPlus("保存成功！");
                        LoginUser.Password = user.Password;
                    }
                }
                catch (Exception ex)
                {
                    Type type = ex.GetType();
                    if (type == typeof(SocketException) || type == typeof(System.IO.IOException))
                    {   // 连接中断  
                        client.Close();
                        //MessageBox.Show("连接中断！");
                    }
                    else
                    {
                        //MessageBox.Show("操作失败异常原因：" + type.Name);
                    }
                }
            }
        }
        string newPassword;
        private void btnSavePsd_Click(object sender, EventArgs e)
        {
            if (tbOldPsd.Text.Trim() == LoginUser.Password)
            {
                newPassword = tbNewPsd.Text.Trim();
                if (string.IsNullOrEmpty(newPassword))
                    MessageBox.Show("新密码不能为空！");
                else
                {
                    if (!tcpClient.ThreadTaskAllocation(HandleSavePwd))
                    {
                        MessageBox.Show("通信信道忙！");
                    }
                }
            }
            else
            {
                MessageBox.Show("原密码输入错误！");
            }
        }
        void ShowPlus(string msg)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(msg);
            }));
        }
    }
}
