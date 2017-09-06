using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServiceUtils.Sockets
{
    /// <summary>
    /// 实现TcpClient的异步连接
    /// </summary>
    public partial class TcpClientPlus: TcpClient
    {
        #region 构造函数和析构函数
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        public TcpClientPlus() : base() { }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="family">IP地址的地址族</param>  
        public TcpClientPlus(AddressFamily family) : base(family) { }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="localEP">将网络端点表示为 IP 地址和端口号</param>  
        public TcpClientPlus(IPEndPoint localEP) : base(localEP) { }

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="address">主机名或者IP地址</param>  
        /// <param name="port">端口号</param>  
        public TcpClientPlus(String address, Int32 port)
            : base()
        {
            // 判断address是主机名还是IP地址  
            try
            {   // IPv4 使用以点分隔的四部分表示法，IPv6 使用冒号十六进制表示法  
                IPAddress ip = IPAddress.Parse(address);

                // 远程主机由IP地址和端口号指定  
                Connect(ip, port);
            }

            catch (FormatException)
            {
                // 远程主机由主机名和端口号指定  
                Connect(address, port);
            }
        }
        CryptoPlus cryptoPlus = new CryptoPlus();
        /// <summary>  
        /// 释放资源  
        /// </summary>  
        /// <param name="disposing">  
        ///     true：释放托管资源和非托管资源  
        ///     false：仅释放非托管资源  
        /// </param>  
        protected override void Dispose(bool disposing)
        {
            // 终止独立的通信线程  
            ThreadTaskAbort();

            // 关闭加密传输模块  
            cryptoPlus.SecurityClose();

            // 调用基类函数释放资源  
            base.Dispose(disposing);
        }

        /// <summary>  
        /// 析构函数  
        /// </summary>  
        ~TcpClientPlus()
        {   // 仅释放非托管资源  
            Dispose(false);
        }
        #endregion
        /// <summary>
        /// 设置连接超时值
        /// </summary>
        public Int32 ConnectTimeout = Timeout.Infinite;
        #region 异步连接
        /// <summary>
        /// 异步连接
        /// </summary>
        /// <param name="hostname">主机名</param>
        /// <param name="port">端口号</param>
        public void AsyncConnect(String hostname, Int32 port)
        {
            // 用户定义对象
            AsyncConnectStateObject State = new AsyncConnectStateObject
            {   // 将事件状态设置为非终止状态，导致线程阻止
                eventDone = new ManualResetEvent(false),
                client = this,
                exception = null
            };

            // 开始一个对远程主机连接的异步请求
            BeginConnect(hostname, port, new AsyncCallback(AsyncConnectCallback), State);

            // 等待操作完成信号
            if (State.eventDone.WaitOne(ConnectTimeout, false))
            {   // 接收到信号
                if (State.exception != null) throw State.exception;
            }
            else
            {   // 超时异常
                Close();
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// 异步连接
        /// </summary>
        /// <param name="address">IP地址</param>
        /// <param name="port">端口号</param>
        public void AsyncConnect(IPAddress address, Int32 port)
        {
            // 用户定义对象
            AsyncConnectStateObject State = new AsyncConnectStateObject
            {   // 将事件状态设置为非终止状态，导致线程阻止
                eventDone = new ManualResetEvent(false),
                client = this,
                exception = null
            };

            // 开始一个对远程主机连接的异步请求
            BeginConnect(address, port, new AsyncCallback(AsyncConnectCallback), State);

            // 等待操作完成信号
            if (State.eventDone.WaitOne(ConnectTimeout, false))
            {   // 接收到信号
                if (State.exception != null) throw State.exception;
            }
            else
            {   // 超时异常
                Close();
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// 异步连接回调函数
        /// </summary>
        /// <param name="ar">异步操作结果</param>
        private static void AsyncConnectCallback(IAsyncResult ar)
        {
            AsyncConnectStateObject State = ar.AsyncState as AsyncConnectStateObject;
            try
            {   // 异步接受传入的连接尝试
                State.client.EndConnect(ar);
            }

            catch (Exception e)
            {   // 异步连接异常
                State.exception = e;
            }

            finally
            {   // 将事件状态设置为终止状态，线程继续                
                State.eventDone.Set();
            }
        }
        #endregion
        #region 异步发送
        /// <summary>  
        /// 异步发送等待时间，默认1秒  
        /// </summary>  
        private const Int32 WriteTimeout = 1000;
        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <param name="offset">起始偏移量</param>
        /// <param name="size">字节数</param>
        public void Write(Byte[] buffer, Int32 offset, Int32 size)
        {
            // 获取网络数据流
            NetworkStream netStream = GetStream();

            // 用户定义对象
            AsyncWriteStateObject State = new AsyncWriteStateObject
            {   // 将事件状态设置为非终止状态，导致线程阻止
                eventDone = new ManualResetEvent(false),
                stream = netStream,
                exception = null
            };

            Byte[] BytesArray;
            if (String.IsNullOrEmpty(cryptoPlus.SecretKey))
            {   // 在数据前插入长度信息
                Int32 Length = size + 4;    // 加入4字节长度信息后的总长度
                BytesArray = new Byte[Length];
                Array.Copy(BitConverter.GetBytes(Length), BytesArray, 4);
                Array.Copy(buffer, offset, BytesArray, 4, size);
            }
            else
            {   // 数据加密
                Byte[] Cipher = cryptoPlus.Encrypt(buffer, offset, size);

                // 在数据前插入长度信息
                Int32 Length = Cipher.Length + 4;
                BytesArray = new Byte[Length];
                Array.Copy(BitConverter.GetBytes(Length), BytesArray, 4);
                Array.Copy(Cipher, 0, BytesArray, 4, Cipher.Length);
            }

            // 写入加长度信息头的数据
            netStream.BeginWrite(BytesArray, 0, BytesArray.Length, new AsyncCallback(AsyncWriteCallback), State);

            // 等待操作完成信号
            if (State.eventDone.WaitOne(WriteTimeout, false))
            {   // 接收到信号
                if (State.exception != null) throw State.exception;
            }
            else
            {   // 超时异常
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="data">字节数组</param>
        public void Write(Byte[] data)
        {
            Write(data, 0, data.Length);
        }

        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="command">字符串</param>
        /// <param name="codePage">代码页</param>
        /// <remarks>
        /// 代码页：
        ///     936：简体中文GB2312
        ///     54936：简体中文GB18030
        ///     950：繁体中文BIG5
        ///     1252：西欧字符CP1252
        ///     65001：UTF-8编码
        /// </remarks>
        public void Write(String command, Int32 codePage = 65001)
        {
            Write(Encoding.GetEncoding(codePage).GetBytes(command));
        }

        /// <summary>
        /// 异步写入回调函数
        /// </summary>
        /// <param name="ar">异步操作结果</param>
        private static void AsyncWriteCallback(IAsyncResult ar)
        {
            AsyncWriteStateObject State = ar.AsyncState as AsyncWriteStateObject;
            try
            {   // 异步写入结束
                State.stream.EndWrite(ar);
            }

            catch (Exception e)
            {   // 异步连接异常
                State.exception = e;
            }

            finally
            {   // 将事件状态设置为终止状态，线程继续
                State.eventDone.Set();
            }
        }
        #endregion
        #region 异步读取
        /// <summary>  
        /// 异步读取等待时间，默认1秒  
        /// </summary>  
        private const Int32 ReadTimeout = 1000;
        /// <summary>
        /// 异步接收
        /// </summary>
        /// <param name="data">接收到的字节数组</param>
        public void Read(out Byte[] data)
        {
            // 获取网络数据流
            NetworkStream netStream = GetStream();

            // 用户定义对象
            AsyncReadStateObject State = new AsyncReadStateObject
            {   // 将事件状态设置为非终止状态，导致线程阻止
                eventDone = new ManualResetEvent(false),
                stream = netStream,
                exception = null,
                numberOfBytesRead = -1
            };

            Byte[] Buffer = new Byte[ReceiveBufferSize];
            using (MemoryStream memStream = new MemoryStream(ReceiveBufferSize))
            {
                Int32 TotalBytes = 0;       // 总共需要接收的字节数
                Int32 ReceivedBytes = 0;    // 当前已接收的字节数
                while (true)
                {
                    // 将事件状态设置为非终止状态，导致线程阻止
                    State.eventDone.Reset();

                    // 异步读取网络数据流
                    netStream.BeginRead(Buffer, 0, Buffer.Length, new AsyncCallback(AsyncReadCallback), State);

                    // 等待操作完成信号
                    if (State.eventDone.WaitOne(ReadTimeout, false))
                    {   // 接收到信号
                        if (State.exception != null) throw State.exception;

                        if (State.numberOfBytesRead == 0)
                        {   // 连接已经断开
                            throw new SocketException();
                        }
                        else if (State.numberOfBytesRead > 0)
                        {
                            if (TotalBytes == 0)
                            {   // 提取流头部字节长度信息
                                TotalBytes = BitConverter.ToInt32(Buffer, 0);

                                // 保存剩余信息
                                memStream.Write(Buffer, 4, State.numberOfBytesRead - 4);
                            }
                            else
                            {
                                memStream.Write(Buffer, 0, State.numberOfBytesRead);
                            }

                            ReceivedBytes += State.numberOfBytesRead;
                            if (ReceivedBytes >= TotalBytes) break;
                        }
                    }
                    else
                    {   // 超时异常
                        throw new TimeoutException();
                    }
                }

                // 将流内容写入字节数组
                if (String.IsNullOrEmpty(cryptoPlus.SecretKey))
                {
                    data = (memStream.Length > 0) ? memStream.ToArray() : null;
                }
                else
                {   // 解密数据
                    data = (memStream.Length > 0) ? cryptoPlus.Decrypt(memStream.ToArray(), 0, TotalBytes - 4) : null;
                }
            }
        }
        /// <summary>
        /// 异步接收
        /// </summary>
        /// <param name="answer">接收到的字符串</param>
        /// <param name="codePage">代码页</param>
        /// <remarks>
        /// 代码页：
        ///     936：简体中文GB2312
        ///     54936：简体中文GB18030
        ///     950：繁体中文BIG5
        ///     1252：西欧字符CP1252
        ///     65001：UTF-8编码
        /// </remarks>
        public void Read(out String answer, Int32 codePage = 65001)
        {
            Byte[] data;
            Read(out data);
            answer = (data != null) ? Encoding.GetEncoding(codePage).GetString(data) : null;
        }

        /// <summary>
        /// 异步读取回调函数
        /// </summary>
        /// <param name="ar">异步操作结果</param>
        private static void AsyncReadCallback(IAsyncResult ar)
        {
            AsyncReadStateObject State = ar.AsyncState as AsyncReadStateObject;
            try
            {   // 异步写入结束
                State.numberOfBytesRead = State.stream.EndRead(ar);
            }

            catch (Exception e)
            {   // 异步连接异常
                State.exception = e;
            }

            finally
            {   // 将事件状态设置为终止状态，线程继续
                State.eventDone.Set();
            }
        }
        #endregion
        #region 异步查询
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="command">发送数据</param>
        /// <param name="offset">起始偏移量</param>
        /// <param name="size">字节数</param>
        /// <param name="answer">接收数据</param>
        public void Query(Byte[] command, Int32 offset, Int32 size, out Byte[] answer)
        {
            if (command != null)
            {   // 发送数据
                Write(command, offset, size);
            }

            // 接收数据
            Read(out answer);
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="command">发送数据</param>
        /// <param name="offset">起始偏移量</param>
        /// <param name="size">字节数</param>
        /// <param name="answer">接收数据</param>
        /// <param name="codePage">代码页</param>
        /// <remarks>
        /// 代码页：
        ///     简体中文GB2312      936
        ///     简体中文GB18030     54936
        ///     繁体中文BIG5        950
        ///     西欧字符CP1252      1252
        ///     UTF-8               65001
        /// </remarks>
        public void Query(Byte[] command, Int32 offset, Int32 size, out String answer, Int32 codePage = 65001)
        {
            if (command != null)
            {   // 发送数据
                Write(command, offset, size);
            }

            // 接收数据
            Read(out answer, codePage);
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="command">发送数据</param>
        /// <param name="answer">接收数据</param>
        public void Query(Byte[] command, out Byte[] answer)
        {
            if (command != null)
            {   // 发送数据
                Write(command);
            }

            // 接收数据
            Read(out answer);
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="command">发送数据</param>
        /// <param name="answer">接收数据</param>
        /// <param name="codePage">代码页</param>
        /// <remarks>
        /// 代码页：
        ///     简体中文GB2312      936
        ///     简体中文GB18030     54936
        ///     繁体中文BIG5        950
        ///     西欧字符CP1252      1252
        ///     UTF-8               65001
        /// </remarks>
        public void Query(Byte[] command, out String answer, Int32 codePage = 65001)
        {
            if (command != null)
            {   // 发送数据
                Write(command);
            }

            // 接收数据
            Read(out answer, codePage);
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="command">发送数据</param>
        /// <param name="answer">接收数据</param>
        /// <param name="codePage">代码页</param>
        /// <remarks>
        /// 代码页：
        ///     简体中文GB2312      936
        ///     简体中文GB18030     54936
        ///     繁体中文BIG5        950
        ///     西欧字符CP1252      1252
        ///     UTF-8               65001
        /// </remarks>
        public void Query(String command, out Byte[] answer, Int32 codePage = 65001)
        {
            if (!String.IsNullOrEmpty(command))
            {   // 发送数据
                Write(command, codePage);
            }

            // 接收数据
            Read(out answer);
        }

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="command">发送数据</param>
        /// <param name="answer">接收数据</param>
        /// <param name="codePage">代码页</param>
        /// <remarks>
        /// 代码页：
        ///     简体中文GB2312      936
        ///     简体中文GB18030     54936
        ///     繁体中文BIG5        950
        ///     西欧字符CP1252      1252
        ///     UTF-8               65001
        /// </remarks>
        public void Query(String command, out String answer, Int32 codePage = 65001)
        {
            if (!String.IsNullOrEmpty(command))
            {   // 发送数据
                Write(command, codePage);
            }

            // 接收数据
            Read(out answer, codePage);
        }
        #endregion
        #region 独立通信线程
        /// <summary>  
        /// 信道空闲等待时间，默认1秒  
        /// </summary>  
        private const Int32 IdleTimeout = 1000;

        // 委托声明  
        public delegate void ThreadTaskRequest(object sender, EventArgs e);

        // 定义一个委托类型的事件  
        public event ThreadTaskRequest OnThreadTaskRequest;

        /// <summary>  
        /// 独立的通信线程处理器  
        /// </summary>  
        protected Thread _TaskThread;

        /// <summary>  
        /// 信道空闲事件  
        /// </summary>  
        protected ManualResetEvent _ChannelIdleEvent;

        /// <summary>  
        /// 任务到达事件  
        /// </summary>  
        protected ManualResetEvent _TaskArrivedEvent;

        /// <summary>  
        /// 独立通信线程结束信号  
        /// </summary>  
        private volatile Boolean _shouldStop;

        /// <summary>  
        /// 启动独立的通信线程  
        /// </summary>  
        /// <param name="action">线程任务处理函数</param>  
        public void ThreadTaskStart()
        {
            if (_TaskThread == null)
            {
                _ChannelIdleEvent = new ManualResetEvent(true);     // 初始化信道空闲  
                _TaskArrivedEvent = new ManualResetEvent(false);    // 初始化任务空闲  
                _shouldStop = false;

                // 创建并启动独立的通信线程  
                _TaskThread = new Thread(new ThreadStart(ThreadTaskAction));
                _TaskThread.Start();
            }
        }

        /// <summary>  
        /// 终止独立的通信线程  
        /// </summary>  
        public void ThreadTaskAbort()
        {   // 终止独立通信线程  
            if (_TaskThread != null)
            {
                _shouldStop = true;         // 设置线程结束信号  
                _TaskArrivedEvent.Set();    // 设置任务到达事件  
            }

            // 关闭信道空闲事件  
            if (_ChannelIdleEvent != null)
            {
                _ChannelIdleEvent.Close();
                _ChannelIdleEvent = null;
            }

            // 关闭任务到达事件  
            if (_TaskArrivedEvent != null)
            {
                _TaskArrivedEvent.Close();
                _TaskArrivedEvent = null;
            }
        }

        /// <summary>  
        /// 独立通信线程任务派发  
        /// </summary>  
        /// <returns>  
        ///     true：任务派发成功  
        ///     false：任务派发失败  
        /// </returns>  
        /// <remarks>  
        ///     执行OnThreadTaskRequest关联的事件  
        /// </remarks>  
        public Boolean ThreadTaskAllocation()
        {   // 启动独立的通信线程  
            if (_TaskThread == null)
            {
                ThreadTaskStart();
            }

            // 等待信道空闲  
            if (_ChannelIdleEvent.WaitOne(IdleTimeout, false))
            {
                _ChannelIdleEvent.Reset();   // 设置信道忙  
                _TaskArrivedEvent.Set();     // 设置任务到达  
                return true;    // 任务派发成功  
            }
            else
            {
                return false;   // 任务派发失败  
            }
        }

        /// <summary>  
        /// 独立通信线程任务派发  
        /// </summary>  
        /// <param name="task">要派发的任务请求</param>  
        /// <returns>  
        ///     true：任务派发成功  
        ///     false：任务派发失败  
        /// </returns>  
        /// <remarks>  
        ///     更新OnThreadTaskRequest为当前任务并执行  
        /// </remarks>  
        public Boolean ThreadTaskAllocation(ThreadTaskRequest task)
        {   // 启动独立的通信线程  
            if (_TaskThread == null)
            {
                ThreadTaskStart();
            }

            // 等待信道空闲  
            if (_ChannelIdleEvent.WaitOne(IdleTimeout, false))
            {   // 设置信道忙  
                _ChannelIdleEvent.Reset();

                // 清空事件调用列表  
                if (OnThreadTaskRequest != null)
                {
                    foreach (Delegate d in OnThreadTaskRequest.GetInvocationList())
                    {
                        OnThreadTaskRequest -= (ThreadTaskRequest)d;
                    }
                }

                // 更新事件调用列表  
                OnThreadTaskRequest += task;

                // 设置任务到达  
                _TaskArrivedEvent.Set();
                return true;    // 任务派发成功  
            }
            else
            {
                return false;   // 任务派发失败  
            }
        }

        /// <summary>  
        /// 独立通信线程处理器  
        /// </summary>  
        private void ThreadTaskAction()
        {
            try
            {
                while (true)
                {   // 等待任务到达  
                    if (_TaskArrivedEvent.WaitOne())
                    {   // 检测线程结束信号  
                        if (_shouldStop) break;

                        try
                        {   // 执行任务  
                            if (OnThreadTaskRequest != null)
                            {
                                OnThreadTaskRequest(this, EventArgs.Empty);
                            }
                        }

                        catch
                        {
                            // 阻止异常抛出                  
                        }

                        // 等待新的任务  
                        if (_TaskArrivedEvent != null) _TaskArrivedEvent.Reset();

                        // 设置信道空闲   
                        if (_ChannelIdleEvent != null) _ChannelIdleEvent.Set();

                        // 再次检测线程结束信号  
                        if (_shouldStop) break;
                    }
                } // End While  
            }

            catch
            {
                // 阻止异常抛出  
            }

            // 保证线程资源释放  
            finally
            {   // 线程关闭  
                _TaskThread = null;

                // 关闭信道空闲事件  
                if (_ChannelIdleEvent != null)
                {
                    _ChannelIdleEvent.Close();
                    _ChannelIdleEvent = null;
                }

                // 关闭任务到达事件  
                if (_TaskArrivedEvent != null)
                {
                    _TaskArrivedEvent.Close();
                    _TaskArrivedEvent = null;
                }
            }
        }
        #endregion
    }
}
