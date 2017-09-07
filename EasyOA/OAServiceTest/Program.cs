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
                        BaseEntity answerBase;
                        byte[] answer;
                        Stream.Read(out answer);
                        answerBase = (BaseEntity)answer.DeserializeToObject();
                        if (answerBase != null)
                        {
                            switch (answerBase.Action.ToLower())
                            {
                                case "login":
                                    User user = answerBase.Data as User;
                                    Stream.Write(dal.Login(user.UserName, user.Password).ToString().ToLower());
                                    break;
                                case "getrole": break;
                                case "getuserlist":
                                    Stream.Write(dal.GetUserList().SerializeToBytes());
                                    break;
                                case "gettasklist":
                                    Stream.Write(dal.GetTaskList(answerBase.Data as Task).SerializeToBytes());
                                    break;
                                case "addtask":
                                    Task task = answerBase.Data as Task;
                                    Stream.Write(dal.AddTask(task).ToString().ToLower());
                                    break;
                            }


                        }

                        //Console.Write(Question + "\r\n");
                        //Console.Write(Answer + "\r\n\r\n");
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
