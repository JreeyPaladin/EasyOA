using System;
using System.Net.Sockets;
using System.Text;

namespace ServiceUtils
{
    public class RemoteClient
    {
        private TcpClient client;
        private NetworkStream streamToClient;
        private const int BufferSize = 8192;
        private byte[] buffer;
        private RequestHandler handler;

        public RemoteClient(TcpClient client)
        {
            this.client = client;

            // 打印连接到的客户端信息
            LoggerFileHelper.WriteToLogFile(string.Format("Client Connected！{0} <-- {1}",
                client.Client.LocalEndPoint, client.Client.RemoteEndPoint));

            // 获得流
            streamToClient = client.GetStream();
            buffer = new byte[BufferSize];

            // 设置RequestHandler
            handler = new RequestHandler();

            // 在构造函数中就开始准备读取
            AsyncCallback callBack = new AsyncCallback(ReadComplete);
            streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
        }

        // 再读取完成时进行回调
        private void ReadComplete(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                lock (streamToClient)
                {
                    bytesRead = streamToClient.EndRead(ar);
                    LoggerFileHelper.WriteToLogFile(string.Format("Reading data, {0} bytes ...", bytesRead));
                }
                if (bytesRead == 0) throw new Exception("读取到0字节");

                string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Array.Clear(buffer, 0, buffer.Length);        // 清空缓存，避免脏读

                LoggerFileHelper.WriteToLogFile(msg);
                string[] msgArray = handler.GetActualString(msg);   // 获取实际的字符串
                string[] arr = msgArray[0].Split('|');
                switch (arr[0].ToLower())
                {
                    case "login":
                        string tempMsg = "";
                        if (arr.Length >= 3 && DAL.Login(arr[1], arr[2]))
                        {
                            tempMsg = Format("login|true");
                        }
                        else
                        {
                            tempMsg = Format("login|false");
                        }
                        SendMessage(tempMsg);
                        break;
                }

                //// 遍历获得到的字符串
                //foreach (string m in msgArray)
                //{
                //    Console.WriteLine("Received: {0}", m);
                //    string back = m.ToUpper();

                //    // 将得到的字符串改为大写并重新发送
                //    byte[] temp = Encoding.Unicode.GetBytes(back);
                //    streamToClient.Write(temp, 0, temp.Length);
                //    streamToClient.Flush();
                //    Console.WriteLine("Sent: {0}", back);
                //}

                // 再次调用BeginRead()，完成时调用自身，形成无限循环
                lock (streamToClient)
                {
                    AsyncCallback callBack = new AsyncCallback(ReadComplete);
                    streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
                }
            }
            catch (Exception ex)
            {
                if (streamToClient != null)
                    streamToClient.Dispose();
                client.Close();
                LoggerFileHelper.WriteToLogFile(ex);      // 捕获异常时退出程序              
            }
        }

        public void SendMessage(string msg)
        {

            byte[] temp = Encoding.Unicode.GetBytes(msg);   // 获得缓存
            streamToClient.Write(temp, 0, temp.Length); // 发往服务器

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

            lock (streamToClient)
            {
                AsyncCallback callBack = new AsyncCallback(ReadComplete);
                streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
            }
        }
        public string Format(string msg)
        {
            return string.Format("[length={0}]{1}", msg.Length, msg);
        }
    }
}
