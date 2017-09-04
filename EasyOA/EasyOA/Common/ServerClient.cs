using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace EasyOA.Common
{
    public class ServerClient
    {
        private const int BufferSize = 8192;
        private byte[] buffer;
        private TcpClient client;
        private NetworkStream streamToServer;
        private string msg = "Welcome to TraceFact.Net!";
        private RequestHandler handler;

        public ServerClient()
        {
            handler = new RequestHandler();
            try
            {
                client = new TcpClient();
                client.Connect("localhost", 8500);      // 与服务器连接
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            buffer = new byte[BufferSize];

            // 打印连接到的服务端信息
            Console.WriteLine("Server Connected！{0} --> {1}",
                client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            streamToServer = client.GetStream();
        }

        // 连续发送三条消息到服务端
        public void SendMessageAsync(string msg)
        {
            msg = Format(msg);
            byte[] temp = Encoding.Unicode.GetBytes(msg);   // 获得缓存
            streamToServer.Write(temp, 0, temp.Length); // 发往服务器

            //for (int i = 0; i <= 2; i++)
            //{
            //    byte[] temp = Encoding.Unicode.GetBytes(msg);   // 获得缓存
            //    try
            //    {
            //        streamToServer.Write(temp, 0, temp.Length); // 发往服务器
            //        Console.WriteLine("Sent: {0}", msg);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        break;
            //    }
            //}

            lock (streamToServer)
            {
                AsyncCallback callBack = new AsyncCallback(ReadComplete);
                streamToServer.BeginRead(buffer, 0, BufferSize, callBack, null);
            }
        }
        /// <summary>
        /// 发消息
        /// </summary>
        /// <param name="msg">action|内容</param>
        /// <returns></returns>
        public string SendMessage(string msg)
        {
            string result = "";
            try
            {
                byte[] temp = Encoding.Unicode.GetBytes(msg);   // 获得缓存
                streamToServer.Write(temp, 0, temp.Length); // 发往服务器

                int bytesRead;
                lock (streamToServer)
                {
                    bytesRead = streamToServer.Read(buffer, 0, BufferSize);
                }
                if (bytesRead == 0) throw new Exception("读取到0字节");
                string received = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                string[] msgArray = handler.GetActualString(received);   // 获取实际的字符串
                string[] arr = msgArray[0].Split('|');
                switch (arr[0].ToLower())
                {
                    case "login":
                        result = arr[1].ToLower();
                        break;
                }
                Console.WriteLine("Received: {0}", received);
                Array.Clear(buffer, 0, buffer.Length);      // 清空缓存，避免脏读
            }
            catch (Exception ex)
            {
                if (streamToServer != null)
                    streamToServer.Dispose();
                client.Close();

                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public void SendMessage()
        {
            SendMessageAsync(this.msg);
        }

        // 读取完成时的回调方法
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead;

            try
            {
                lock (streamToServer)
                {
                    bytesRead = streamToServer.EndRead(ar);
                }
                if (bytesRead == 0) throw new Exception("读取到0字节");

                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                string[] msgArray = handler.GetActualString(msg);   // 获取实际的字符串
                //switch (msgArray[0].ToLower())
                //{
                //    case "login":
                //        if(msgArray[1];
                //        break;
                //}
                Console.WriteLine("Received: {0}", msg);
                Array.Clear(buffer, 0, buffer.Length);      // 清空缓存，避免脏读

                lock (streamToServer)
                {
                    AsyncCallback callBack = new AsyncCallback(ReadComplete);
                    streamToServer.BeginRead(buffer, 0, BufferSize, callBack, null);
                }
            }
            catch (Exception ex)
            {
                if (streamToServer != null)
                    streamToServer.Dispose();
                client.Close();

                Console.WriteLine(ex.Message);
            }
        }
        public string Format(string msg)
        {
            return string.Format("[length={0}]{1}", msg.Length, msg);
        }
    }
}
