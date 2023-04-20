using QSSAPI.BOL;
using QSSAPI.DAL;
using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.BLL
{
    public class BLL_Sales_Details
    {
        public string Insert_Sales_Detail(BOL_Sales_Details obj_sales_details, out int sd_ID)
        {
            int result = 0;
            string message = "";
            try
            {
                SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

                DAL_Sales_Details dal = new DAL_Sales_Details();

                SqlConjunction.StartTransaction();
                result = dal.Insert_Sales_Details(obj_sales_details);

                SqlConjunction.CommitTransaction();

            }
            catch (SqlException ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                message = ex.Message;
                HelperClass.WriteLog("sql error logging - exception:" + ex.Message);

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                message = ex.Message;
                HelperClass.WriteLog("error logging - exception:" + ex.Message);
            }
            sd_ID = result;
            return message;
        }
    }
}