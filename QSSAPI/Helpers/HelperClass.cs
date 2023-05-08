using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DAL;
namespace QSSAPI.Helpers
{
    class HelperClass
    {
        public static string UserName;
        public static string DB_Conn;
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
        public static int Get_Update_Schedule_Minute()
        {
            int minut = 0;
            //var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            //var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            //var _path = new Uri(_uripath).LocalPath;
            //string text = System.IO.File.ReadAllText(_path + @"\ScheduleMinute.txt");
            //int.TryParse(text, out minut);
            return minut;
        }
        public static string FuncGetDateTime(string format)
        {
            System.DateTime regTimeStamp = System.DateTime.Now;
            return regTimeStamp.ToString(format);
        }

        public static string Get_SMTP_Host()
        {
            string smtp_host = "";
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            var _path = new Uri(_uripath).LocalPath;
            smtp_host = System.IO.File.ReadAllText(_path + @"\SMTP_Host.txt");
            return smtp_host;
        }

        public static int Get_Port()
        {
            int port = 0;
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            var _path = new Uri(_uripath).LocalPath;
            string str_port = System.IO.File.ReadAllText(_path + @"\Port.txt");
            int.TryParse(str_port, out port);
            return port;
        }

        public static int Get_BranchID()
        {
            int minut = 0;
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            var _path = new Uri(_uripath).LocalPath;
            string text = System.IO.File.ReadAllText(_path + @"\Branch.txt");
            int.TryParse(text, out minut);
            return minut;
        }

        public static string StringTest()
        {
            string smtp_host = "";
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            var _path = new Uri(_uripath).LocalPath;
            smtp_host = System.IO.File.ReadAllText(_path + @"\JSON.txt");
            return smtp_host;
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

        public static void Write_Payload_Log(string payload, string folder, string filename)
        {
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            var _uripath = System.IO.Path.GetDirectoryName(_assembly);
            var _path = new Uri(_uripath).LocalPath + @"\" + folder;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(payload);
            System.IO.Directory.CreateDirectory(_path);
            System.IO.File.AppendAllText(_path + @"\" + filename + ".txt", sb.ToString());
        }

        #region +++ Code Of Encrypt Method +++

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MIS";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        #endregion

        #region +++ Code Of Decrypt Method +++

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MIS";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        #endregion

    

    }
}