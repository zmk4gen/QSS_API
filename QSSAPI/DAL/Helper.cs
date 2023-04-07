using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace DAL
{
    public class Helper
    {
        public static DateTime ConvertDateTime(string _strDateTime)
        {
            DateTime dt = DateTime.Now;
            if (!string.IsNullOrEmpty(_strDateTime))
            {
                DateTime.TryParse(_strDateTime, out dt);
            }
            return dt;
        }
        public static int ConvertInteger(string _strVal)
        {
            int val = 0;
            if (!string.IsNullOrEmpty(_strVal) || _strVal == null)
            {
                int.TryParse(_strVal, out val);
            }
            return val;
        }
        public static decimal ConvertDecimal(string _strVal)
        {
            decimal val = 0;
            if (!string.IsNullOrEmpty(_strVal))
            {
                decimal.TryParse(_strVal, out val);
            }
            return val;
        }
        public static bool ConvertBoolean(string _strVal)
        {
            bool val = false;
            if (!string.IsNullOrEmpty(_strVal))
            {
                bool.TryParse(_strVal, out val);
            }
            return val;
        }
        public static void WriteLog(string logtxt)
        {
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            var _path = new Uri(_uripath).LocalPath;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(logtxt);
            System.IO.File.AppendAllText(_path + @"\Log.txt", sb.ToString());
        }
    }
}