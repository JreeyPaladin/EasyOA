using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ServiceUtils.Sockets
{
    public static class SerializePlus
    {
        /// <summary>
        /// 将对象序列化为byte[]
        /// 使用IFormatter的Serialize序列化
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>序列化获取的二进制流</returns>
        public static byte[] SerializeToBytes(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            byte[] buff;
            try
            {
                using (var ms = new MemoryStream())
                {
                    BinaryFormatter iFormatter = new BinaryFormatter();
                    iFormatter.Serialize(ms, obj);
                    buff = ms.GetBuffer();
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return buff;
        }
        /// <summary>
        ///将byte[]反序列化为对象
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        public static object DeserializeToObject(this byte[] buff)
        {
            if (buff == null)
                throw new ArgumentNullException("buff");
            object obj;
            try
            {
                using (var ms = new MemoryStream(buff))
                {
                    BinaryFormatter iFormatter = new BinaryFormatter();
                    obj = iFormatter.Deserialize(ms);
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return obj;
        }
    }
}
