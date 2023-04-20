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
    public class BLL_Order_Raw_Data
    {
        public string Insert_Order_Raw_Data(BOL_Order_Raw_Data obj_bol, out int raw_data_id)
        {

            int result = 0;
            string message = "";
            try
            {
                SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);

                DAL_Order_Raw_Data dal = new DAL_Order_Raw_Data();

                SqlConjunction.StartTransaction();
                result = dal.Insert_Raw_Data(obj_bol);

                SqlConjunction.CommitTransaction();

            }
            catch (SqlException ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                message = ex.Message;
                HelperClass.WriteLog("sql error logging - " + obj_bol.ord_DeliveryTypeCode + ",exception:" + ex.Message);

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                message = ex.Message;
                HelperClass.WriteLog("error logging - " + obj_bol.ord_DeliveryTypeCode + ",exception:" + ex.Message);
            }
            raw_data_id = result;
            return message;
        }
    }
}