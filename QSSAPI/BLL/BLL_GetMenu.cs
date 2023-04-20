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
    public class BLL_GetMenu
    {
        public DataTable Get_Stock(string st_StockNo)
        {
            //SqlConjunction.connection = new System.Data.SqlClient.SqlConnection(HelperClass.DB_Conn);
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_GetMenu obj_dal = new DAL_GetMenu();
            return obj_dal.Get_Stock(st_StockNo);
        }

        public string Get_Stock_Description2_For_MenuFlow(string st_StockNo)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_GetMenu obj_dal = new DAL_GetMenu();
            DataTable dt = obj_dal.Get_Stock(st_StockNo);
            string description2 = "";

            if(dt.Rows.Count > 0)
            {
                description2 = dt.Rows[0]["st_Description2"].ToString();
            }

            return description2;
        }
    }
}