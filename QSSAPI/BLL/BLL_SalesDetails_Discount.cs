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
    public class BLL_SalesDetails_Discount
    {
        public string Insert_Sales_Detail(BOL_SalesDetails_Discount obj_sdd)
        {
            int result = 0;
            string message = "";
            try
            {
                SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

                DAL_SalesDetails_Discount dal = new DAL_SalesDetails_Discount();

                SqlConjunction.StartTransaction();
                message = dal.Insert_SalesDetails_Discount(obj_sdd).ToString();

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
            return message;
        }
    }
}