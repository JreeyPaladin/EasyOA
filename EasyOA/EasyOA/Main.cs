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
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            状态ToolStripComboBox.Items.Add("任务状态");
            foreach (var item in Enum.GetValues(typeof(TaskStatus)))
            {
                状态ToolStripComboBox.Items.Add(item);
            }
            //状态ToolStripComboBox.SelectedIndex = 0;
            if (!tcpClient.ThreadTaskAllocation(HandleGetUserList))
            {
                MessageBox.Show("通信信道忙！");
            }
            BindTaskData();
        }
        #region 绑定Task
        public void BindTaskData()
        {
            if (!tcpClient.ThreadTaskAllocation(HandleClientComm))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        private void SetTaskData(DataTable dt)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<DataTable>((msg) =>
                {
                    taskDgv.DataSource = dt;
                    toolStripStatusLabel1.Text = "总计：" + dt.Rows.Count + "条记录";
                }), dt);
            }
            else
            {
                taskDgv.DataSource = dt;
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
                    SetTaskData(dt);
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
                    SetUserData();
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

        private void SetUserData()
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
        CreateTask ct;
        private void 新建任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ct = new CreateTask(this, UserData);
            ct.ShowDialog();
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
                        ct.Invoke(new Action(ct.Close));
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
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tcpClient.Close();
            base.OnFormClosed(e);
        }
    }
}
