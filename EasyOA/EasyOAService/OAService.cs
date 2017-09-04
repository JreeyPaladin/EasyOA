using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Timers;

namespace EasyOAService
{
    public partial class OAService : ServiceBase
    {
        public OAService()
        {
            InitializeComponent();
        }
        Timer timer = null;
        TcpListener listener = null;
        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
            timer.Start();


        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            listener = new TcpListener(ip, 8500);
            listener.Start();
            while (true)
            {
                // 获取一个连接，同步方法，在此处中断
                TcpClient client = listener.AcceptTcpClient();
                RemoteClient wapper = new RemoteClient(client);
            }
        }
        protected override void OnStop()
        {
            if (timer != null)
                timer.Stop();
            if (listener != null)
                listener.Stop();
        }
    }
}
