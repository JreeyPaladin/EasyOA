using System;
using System.Net.Sockets;
using System.Threading;

namespace ServiceUtils.Sockets
{
    /// <summary>
    /// 异步连接状态对象
    /// </summary>
    internal class AsyncConnectStateObject
    {
        public ManualResetEvent eventDone;
        public TcpClient client;
        public Exception exception;
    }
    /// <summary>
    /// 异步写状态对象
    /// </summary>
    internal class AsyncWriteStateObject
    {
        public ManualResetEvent eventDone;
        public NetworkStream stream;
        public Exception exception;
    }

    /// <summary>  
    /// 异步读状态对象  
    /// </summary>  
    internal class AsyncReadStateObject
    {
        public ManualResetEvent eventDone;
        public NetworkStream stream;
        public Exception exception;
        public Int32 numberOfBytesRead;
    }
}
