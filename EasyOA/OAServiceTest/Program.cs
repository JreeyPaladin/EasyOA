using OAEntities;
using ServiceUtils;
using ServiceUtils.Sockets;
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
        static DAL dal = new DAL();
        static void Main(string[] args)
        {
            TcpListenerPlus Server = new TcpListenerPlus(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8500);
            Server.OnThreadTaskRequest += new TcpListenerPlus.ThreadTaskRequest(GetAnswer);
        }

        private static void GetAnswer(object sender, EventArgs e)
        {
            TcpClient tcpClient = (TcpClient)sender;
            using (NetworkStreamPlus Stream = new NetworkStreamPlus(tcpClient.GetStream()))
            {   // 调整接收缓冲区大小  
                Stream.ReceiveBufferSize = tcpClient.ReceiveBufferSize;
                //Stream.SecretKey = GetSecretKey();  // 加密密钥              
                while (true)
                {
                    try
                    {
                        // 获取查询内容  
                        String Question;
                        BaseEntity answerBase;
                        byte[] answer;
                        //Stream.Read(out Question);
                        Stream.Read(out answer);
                        answerBase = (BaseEntity)SerializePlus.FormatterByteObject(answer);

                        User user = answerBase.Data as User;
                        if (dal.Login(user.Account, user.Password))
                        {
                            Stream.Write("true");
                        }
                        else
                        {
                            Stream.Write("false");
                        }
                        // 返回查询结果  
                        //String Answer = Question.ToUpper();
                        //Stream.Write(Answer);

                        //Console.Write(Question + "\r\n");
                        //Console.Write(Answer + "\r\n\r\n");
                        Console.Write(user.Account + "\r\n\r\n");
                        Console.Write(user.Password + "\r\n\r\n");
                    }

                    catch (Exception ex)
                    {
                        Type type = ex.GetType();
                        if (type == typeof(TimeoutException))
                        {   // 超时异常，不中断连接  
                            Console.Write("数据超时失败！\r\n\r\n");
                        }
                        else
                        {   // 仍旧抛出异常，中断连接  
                            Console.Write("中断连接异常原因：" + type.Name + "\r\n\r\n");
                            throw ex;
                        }
                    }
                }
            }
        }
    }
}
