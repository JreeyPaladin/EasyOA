using ServiceUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OAServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = null;
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
    }
}
