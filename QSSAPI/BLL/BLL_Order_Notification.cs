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
    public class BLL_Order_Notification
    {
        public int Insert_Order_Notification(BOL_Order_Notification obj_bol)
        {

            int result = 0;
            try
            {
                SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

                DAL_Order_Notification dal = new DAL_Order_Notification();

                SqlConjunction.StartTransaction();
                result = dal.Insert_Order_Notification(obj_bol);

                SqlConjunction.CommitTransaction();
            }

            catch (SqlException ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog("sql error logging - " + obj_bol.ordernoti_OrderRawDataID + ",exception:" + ex.Message);

            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(ex.Message);
            }

            return result;
        }
    }
}