using QSSAPI.BOL;
using QSSAPI.DAL;
using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.BLL
{
    public class BLL_Sales
    {
        public string Insert_Sales(BOL_Sales obj_sales)
        {
            int result = 0;
            string message = "";
            try
            {
                SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

                DAL_Sales dal = new DAL_Sales();

                SqlConjunction.StartTransaction();
                result = dal.Insert_Sales(obj_sales);

                SqlConjunction.CommitTransaction();

            }
            catch (SqlException ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                message = ex.Message;
                HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", Update_Sales_Status, sql error logging - exception:" + ex.InnerException.Message + " :End//");

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                message = ex.Message;
                HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", Update_Sales_Status, error logging - exception:" + ex.InnerException.Message + " :End//");
            }
            //sa_ID = result;
            return message;
        }

        public DataTable Get_Sales(string sa_uid)
        {
            SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

            DAL_Sales dal = new DAL_Sales();
            return dal.Get_Sales(sa_uid);
        }

        public int Update_Sales_Status(string sa_uid, string status, string cancelreason)
        {
            int result = 0;
            try
            {
                SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

                DAL_Sales dal = new DAL_Sales();

                SqlConjunction.StartTransaction();
                result = dal.Update_Sales_Status(sa_uid, status, cancelreason);

                SqlConjunction.CommitTransaction();

            }
            catch (SqlException ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", Update_Sales_Status, sql error logging - exception:" + ex.InnerException.Message + " :End//");

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", Update_Sales_Status, error logging - exception:" + ex.InnerException.Message + " :End//");

            }
            //sa_ID = result;
            return result;
        }
    }
}