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
    public class BLL_Delivery_Info
    {
        public int Insert_Delivery_Info(BOL_Delivery_Info bol_del)
        {
            int result = 0;
            try
            {
                SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
                DAL_Delivery_Info dal = new DAL_Delivery_Info();
                SqlConjunction.StartTransaction();
                result = dal.Insert_Delivery_Info(bol_del);
                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": BLL:Insert_Delivery_Info:error:" + ex.Message);

            }
            return result;
        }
    }
}