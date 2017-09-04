using System;
using System.IO;

namespace ServiceUtils
{
    /// <summary>
    /// 文件日志记录帮助类
    /// </summary>
    public class LoggerFileHelper
    {
        /// <summary>
        /// 是否输出调试信息到文件
        /// </summary>
        private static bool IsDebug = false;
        /// <summary>
        /// 调试写入日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="description"></param>
        public static void WriteDebug(Exception ex, string description)
        {
            if (IsDebug)
            {
                string strEx = "";
                if (ex == null)
                {
                    strEx = string.Format("{0}    {1}    ",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), description);
                }
                else
                {
                    strEx = string.Format("{0}    {1}    Exception      {2}     {3}    {4}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), description, ex.Message, ex.TargetSite, ex.Source);
                }

                StreamWriter sr = null;

                string folder = AppDomain.CurrentDomain.BaseDirectory + "Debug\\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string filename = String.Format(@"{0}{1:yyyy_MM_dd}_.txt", folder, DateTime.Now);

                try
                {
                    if (File.Exists(filename))   //如果文件存在,则创建File.AppendText对象 
                    {
                        sr = File.AppendText(filename);

                    }
                    else     //如果文件不存在,则创建File.CreateText对象 
                    {
                        sr = File.CreateText(filename);
                    }

                    sr.WriteLine(strEx);
                    sr.Flush();
                }
                catch (Exception)
                {

                }
                finally
                {
                    sr.Close();
                }
            }
        }
        /// <summary>
        /// 把内容写入到日志文件中
        /// </summary>
        /// <param name="strLogContent">日志内容</param>
        public static void WriteToLogFile(string strLogContent)
        {
            StreamWriter sr = null;

            string folder = AppDomain.CurrentDomain.BaseDirectory + "Log\\";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filename = String.Format(@"{0}{1:yyyy_MM_dd}_.txt", folder, DateTime.Now);

            try
            {
                if (File.Exists(filename))   //如果文件存在,则创建File.AppendText对象 
                {
                    sr = File.AppendText(filename);

                }
                else     //如果文件不存在,则创建File.CreateText对象 
                {
                    sr = File.CreateText(filename);
                }

                sr.WriteLine(strLogContent);
                sr.Flush();
            }
            catch (Exception)
            {

            }
            finally
            {
                sr.Close();
            }

        }

        /// <summary>
        /// 把内容写入到日志文件中
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteToLogFile(Exception ex)
        {
            string strEx = string.Format("{0}    Exception      {1}     {2}    {3}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message, ex.TargetSite, ex.StackTrace);

            StreamWriter sr = null;

            string folder = AppDomain.CurrentDomain.BaseDirectory + "Error\\";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filename = String.Format(@"{0}{1:yyyy_MM_dd}_.txt", folder, DateTime.Now);

            try
            {
                if (File.Exists(filename))   //如果文件存在,则创建File.AppendText对象 
                {
                    sr = File.AppendText(filename);

                }
                else     //如果文件不存在,则创建File.CreateText对象 
                {
                    sr = File.CreateText(filename);
                }

                sr.WriteLine(strEx);
                sr.Flush();
            }
            catch (Exception)
            {

            }
            finally
            {
                sr.Close();
            }
        }

        /// <summary>
        /// 把内容写入到日志文件中
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="description">描述</param>
        public static void WriteToLogFile(Exception ex, string description)
        {
            string strEx = string.Format("{0}    {1}    Exception      {2}     {3}    {4}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), description, ex.Message, ex.TargetSite, ex.StackTrace);

            StreamWriter sr = null;

            string folder = AppDomain.CurrentDomain.BaseDirectory + "Error\\";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filename = String.Format(@"{0}{1:yyyy_MM_dd}_.txt", folder, DateTime.Now);

            try
            {
                if (File.Exists(filename))   //如果文件存在,则创建File.AppendText对象 
                {
                    sr = File.AppendText(filename);

                }
                else     //如果文件不存在,则创建File.CreateText对象 
                {
                    sr = File.CreateText(filename);
                }

                sr.WriteLine(strEx);
                sr.Flush();
            }
            catch (Exception)
            {

            }
            finally
            {
                sr.Close();
            }
        }
    }
}
