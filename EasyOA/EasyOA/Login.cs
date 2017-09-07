using OAEntities;
using ServiceUtils.Sockets;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Windows.Forms;

namespace EasyOA
{
    public partial class Login : Form
    {
        protected TcpClientPlus tcpClient = new TcpClientPlus(AppConfig.IP, AppConfig.Port);
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!tcpClient.ThreadTaskAllocation(HandleClientComm))
            {
                MessageBox.Show("通信信道忙！");
            }
        }
        private void HandleClientComm(object sender, EventArgs e)
        {
            TcpClientPlus client = sender as TcpClientPlus;
            if (client != null)
            {
                try
                {
                    User user = new User()
                    {
                        UserName = GetUserName(),
                        Password = GetPassword()
                    };
                    BaseEntity sendBase = new BaseEntity("login", user);
                    string receive;
                    client.Query(sendBase.SerializeToBytes(), out receive);
                    if (receive == "true")
                    {
                        this.Invoke(new Action(this.Hide));
                        this.Invoke(new Action(this.ShowWindow));
                        this.Invoke(new Action(this.Close));
                    }
                    else
                    {
                        MessageBox.Show("登录名或密码错误！");
                    }
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
        // 对 Windows 窗体控件进行线程安全调用  
        private string GetUserName()
        {
            if (tbUserName.InvokeRequired)
            {
                return (string)tbUserName.Invoke(new Func<string>(() => { return tbUserName.Text; }));
            }
            else
            {
                return tbUserName.Text;
            }
        }
        private string GetPassword()
        {
            if (tbPassword.InvokeRequired)
            {
                return (string)tbPassword.Invoke(new Func<string>(() => { return tbPassword.Text; }));
            }
            else
            {
                return tbPassword.Text;
            }
        }
        private void ShowWindow()
        {
            Main main = new Main();
            main.ShowDialog();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tcpClient.Close();
            base.OnFormClosed(e);
        }
    }
}
