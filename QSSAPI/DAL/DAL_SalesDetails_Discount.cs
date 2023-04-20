using QSSAPI.BOL;
using QSSAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QSSAPI.DAL
{
    public class DAL_SalesDetails_Discount
    {
        public int Insert_SalesDetails_Discount(BOL_SalesDetails_Discount bol_sdd)
        {
            SqlCommand sqlCmd = new SqlCommand("sp_Insert_SalesDetails_Discount_API_Ordering");
            sqlCmd.CommandType = CommandType.StoredProcedure; 
            
            sqlCmd.Parameters.AddWithValue("@sdd_uid", bol_sdd.sdd_uid);
            sqlCmd.Parameters.AddWithValue("@sdd_DisplayAftersdid", bol_sdd.sdd_DisplayAftersdid);
            sqlCmd.Parameters.AddWithValue("@sdd_sdid", bol_sdd.sdd_sdid);
            sqlCmd.Parameters.AddWithValue("@sdd_discidsequence", bol_sdd.sdd_discidsequence);
            sqlCmd.Parameters.AddWithValue("@sdd_discid", bol_sdd.sdd_discid);
           
            sqlCmd.Parameters.AddWithValue("@sdd_discno", bol_sdd.sdd_discno);
            sqlCmd.Parameters.AddWithValue("@sdd_discname1", bol_sdd.sdd_discname1);
            sqlCmd.Parameters.AddWithValue("@sdd_disctype", bol_sdd.sdd_disctype);
            sqlCmd.Parameters.AddWithValue("@sdd_discpercent", bol_sdd.sdd_discpercent);
            sqlCmd.Parameters.AddWithValue("@sdd_discamount", bol_sdd.sdd_discamount);
            
            sqlCmd.Parameters.AddWithValue("@sdd_sn", bol_sdd.sdd_sn);
            sqlCmd.Parameters.AddWithValue("@sdd_stockid", bol_sdd.sdd_stockid);
            sqlCmd.Parameters.AddWithValue("@sdd_uom", bol_sdd.sdd_uom);
            sqlCmd.Parameters.AddWithValue("@sdd_contain", bol_sdd.sdd_contain);
            sqlCmd.Parameters.AddWithValue("@sdd_att1", bol_sdd.sdd_att1);
            
            sqlCmd.Parameters.AddWithValue("@sdd_att2", bol_sdd.sdd_att2);
            sqlCmd.Parameters.AddWithValue("@sdd_sprice", bol_sdd.sdd_sprice);
            sqlCmd.Parameters.AddWithValue("@sdd_qty", bol_sdd.sdd_qty);
            sqlCmd.Parameters.AddWithValue("@sdd_businessdate", bol_sdd.sdd_businessdate);
            sqlCmd.Parameters.AddWithValue("@sdd_createdate", bol_sdd.sdd_createdate);
            
            sqlCmd.Parameters.AddWithValue("@sdd_createby", bol_sdd.sdd_createby);
            sqlCmd.Parameters.AddWithValue("@sdd_createbyname", bol_sdd.sdd_createbyname);
            sqlCmd.Parameters.AddWithValue("@sdd_discname2", bol_sdd.sdd_discname2);
            sqlCmd.Parameters.AddWithValue("@sdd_discname3", bol_sdd.sdd_discname3);
            sqlCmd.Parameters.AddWithValue("@sdd_AmtForCalcSVC", DBNull.Value);
            
            sqlCmd.Parameters.AddWithValue("@sdd_AmtForCalcTax", DBNull.Value);
            sqlCmd.Parameters.AddWithValue("@sdd_remarks", bol_sdd.sdd_remarks);
            sqlCmd.Parameters.AddWithValue("@sdd_resume", bol_sdd.sdd_resume);
            sqlCmd.Parameters.AddWithValue("@sdd_SubtotalDiscByValue", bol_sdd.sdd_SubtotalDiscByValue);
            sqlCmd.Parameters.AddWithValue("@sdd_SubtotalDiscValue", bol_sdd.sdd_SubtotalDiscValue);
            
            sqlCmd.Parameters.AddWithValue("@sdd_branchid", bol_sdd.sdd_branchid);
            sqlCmd.Parameters.AddWithValue("@sdd_iid", bol_sdd.sdd_iid);
            sqlCmd.Parameters.AddWithValue("@sdd_shiftid", bol_sdd.sdd_shiftid);
            sqlCmd.Parameters.AddWithValue("@sdd_shiftno", bol_sdd.sdd_shiftno);
            sqlCmd.Parameters.AddWithValue("@sdd_shiftrefno", bol_sdd.sdd_shiftrefno);
            
            sqlCmd.Parameters.AddWithValue("@sdd_Nett", bol_sdd.sdd_Nett);
            sqlCmd.Parameters.AddWithValue("@sdd_TotalAfterDiscount", bol_sdd.sdd_TotalAfterDiscount);
            sqlCmd.Parameters.AddWithValue("@sdd_syncdata", bol_sdd.sdd_syncdata);
            sqlCmd.Parameters.AddWithValue("@sdd_syncvoiddata", bol_sdd.sdd_syncvoiddata);

            foreach (SqlParameter Parameter in sqlCmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }
    }
}