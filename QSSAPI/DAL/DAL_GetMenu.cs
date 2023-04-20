using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.DAL
{
    public class DAL_GetMenu
    {
        /// <summary>
        /// Retrive require info for stock
        /// </summary>
        /// <param name="st_id"></param>
        /// <returns></returns>
        public DataTable Get_Stock(string st_StockNo)
        {
            string str_cmd = "Select st_id, st_StockNo, st_Description, st_OpenPrice, st_Obsolete ";
            str_cmd += ", st_Description2, st_Description3, st_taxid, st_combo ";
            str_cmd += ", st_combopattern, st_requireremarks, st_typedef, st_discitemize ";
            str_cmd += ", st_condipattern, st_combopatterncbosid ";
            str_cmd += ", st_privilege, st_menuprivilege from Stocks ";
            //str_cmd += "inner join Stock_PriceTable p on st_id = pt_stockid ";
            str_cmd += "Where st_StockNo = '" + st_StockNo + "'";

            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Dispose();

            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

    }
}