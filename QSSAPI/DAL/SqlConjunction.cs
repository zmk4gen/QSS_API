using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using QSSAPI.BOL;
using DAL;

namespace QSSAPI.DAL
{
    public class SqlConjunction
    {
        public static string DataConn = ConfigurationSettings.AppSettings.Get("SQLConn");
        //public static string DataConn = ConfigurationManager.ConnectionStrings["SQLConn"].ConnectionString;
        static SqlTransaction transaction;
     public   static SqlConnection connection = new SqlConnection(DataConn);

        public static void StartTransaction()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            transaction = connection.BeginTransaction();
        }

        public static void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static void RollbackTransaction(string _Exception)
        {
            if (transaction != null)
            {
                Helper.WriteLog(DateTime.Now.ToString() + " : " + _Exception);
                transaction.Rollback();
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static DataSet GetSQLDataSet(SqlCommand sqlCmd)
        {
            DataSet dt = new DataSet();

            sqlCmd.Connection = connection;

            //sqlCmd.Transaction = transaction;

            //sqlCmd.CommandTimeout = 0;
            SqlDataAdapter sqlAdt = new SqlDataAdapter(sqlCmd);

            try
            {
                //sqlCmd.ExecuteNonQuery();
                sqlAdt.Fill(dt);
            }
            catch (SqlException sqx)
            {
                Console.WriteLine(sqx.ToString());
                //MessageBox.Show(sqx.Message);
                //  throw sqx;
            }
            finally
            {
                //connection.Close();
            }

            return dt;
        }

        public static DataTable GetSQLDataTable(SqlCommand sqlCmd)
        {
            DataTable dt = new DataTable();
            //sqlCmd.Transaction = transaction;
            sqlCmd.Connection = connection;
            //sqlCmd.CommandTimeout = 0;
            SqlDataAdapter sqlAdt = new SqlDataAdapter(sqlCmd);

            try
            {
                //sqlCmd.ExecuteNonQuery();
                sqlAdt.Fill(dt);
            }
            catch (SqlException sqx)
            {
                //MessageBox.Show(sqx.Message);
                throw sqx;
            }
            finally
            {
                //connection.Close();
            }

            return dt;
        }

        public static int GetSQLTransVoid(SqlCommand sqlCmd)
        {
            int int_Result = 0;
            int id = 0;
            try
            {
                sqlCmd.Connection = connection;
                sqlCmd.Transaction = transaction;

                int_Result = Convert.ToInt32(sqlCmd.ExecuteNonQuery());

                if(sqlCmd.Parameters["@id"].Value.ToString() !="" && sqlCmd.Parameters["@id"].Value.ToString() != null)
                {
                    id = Convert.ToInt32(sqlCmd.Parameters["@id"].Value.ToString());
                }

                //connection.Open();
                //object returnObj = sqlCmd.ExecuteScalar();

                //int_Result = Convert.ToInt32(sqlCmd.ExecuteScalar());

                //if (returnObj != null)
                //{
                //    int.TryParse(returnObj.ToString(), out int_Result);
                //}

                //connection.Close();
            }
            catch (SqlException sqx)
            {
                throw sqx;

            }
            finally
            {
                //connection.Close();
            }

            return id;
        }

        public static int GetSQLTransScalar(SqlCommand sqlCmd)
        {
            object obj;
            try
            {
                sqlCmd.Connection = connection;
                sqlCmd.Transaction = transaction;
                obj = sqlCmd.ExecuteScalar();

            }
            catch (SqlException sqx)
            {
                throw sqx;
                //MessageBox.Show(sqx.Message + sqx.Source);
            }

            return int.Parse(obj.ToString());
        }
    }
}
