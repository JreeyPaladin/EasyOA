using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServiceUtils
{
    public class DAL
    {
        public static bool Login(string account, string passowrd)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\User.dat";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineArr = line.Split('|');
                if (lineArr.Length >= 2 && account == lineArr[0] && passowrd == lineArr[1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
