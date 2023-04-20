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
    public class BLL_Generic
    {
        public DataTable Get_Seqnumberuid(int branchid)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_Seqnumberuid(branchid);
        }
        public DataTable Get_mstr_RVC()
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_mstr_RVC();
        }
        public DataTable Get_RVC_CheckNumber(int rvcid)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_RVC_CheckNumber(rvcid);
        }
        public DataTable Get_master_branch()
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_master_branch();
        }

        public string Get_ComboPatternQty(string stocknumber, string combo_or_condi)
        {
            string str_combpatternqty = "";
            string str_column_name = "";
            decimal qty = 0;
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            DataTable dt = new DataTable();

            if (combo_or_condi == "combo")
            {
                dt = dal.Get_ComboPatternQty_ForCombo(stocknumber);
                str_column_name = "cbo_qty";
            }
            else if (combo_or_condi == "condr") //require condiment
            {
                dt = dal.Get_ComboPatternQty_ForComdiment(stocknumber);
                str_column_name = "condr_qty";
            }
            else if (combo_or_condi == "conda") //allow condiment
            {
                dt = dal.Get_ComboPatternQty_ForComdiment_Allow(stocknumber);
                str_column_name = "conda_qty";
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                qty = HelperClass.ConvertDecimal(dt.Rows[i][str_column_name].ToString());
                str_combpatternqty += Decimal.ToInt32(qty) + "||";
            }
            return str_combpatternqty;
        }

        public int Update_Sales_Details_ComboPatternQty(int sd_id, string uid, string sd_combopatternqty)
        {
            int result = 0;
            try
            {
                SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
                DAL_Generic dal = new DAL_Generic();
                SqlConjunction.StartTransaction();
                result = dal.Update_Sales_Details_ComboPatternQty(sd_id, uid, sd_combopatternqty);
                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": BLL:Update_Sales_Details_ComboPatternQty:error:" + ex.Message);

            }
            return result;
        }

        public DataTable Get_SalesType_and_TransType_Info(string salestype)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_SalesType_and_TransType_Info(salestype);
        }

        public DataTable Get_ServiceCharge()
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_ServiceCharge();
        }

        public BOL_Tax Get_Tax_By_Stock(int stock_id, int tax_id)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Get_Tax_By_Stock(stock_id, tax_id);
        }

        public BOL_Discount Get_Discount_By_Name(string discname)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            DataTable dt = dal.Get_Discount_By_Name(discname);
            BOL_Discount bol = new BOL_Discount();
            if (dt.Rows.Count > 0)
            {
                bol.disc_id = HelperClass.ConvertInteger(dt.Rows[0]["disc_id"].ToString());
                bol.disc_number = dt.Rows[0]["disc_number"].ToString();
                bol.disc_name1 = dt.Rows[0]["disc_name1"].ToString();
                bol.disc_name2 = dt.Rows[0]["disc_name2"].ToString();
                bol.disc_name3 = dt.Rows[0]["disc_name3"].ToString();
                bol.disc_amount = HelperClass.ConvertDecimal(dt.Rows[0]["disc_amount"].ToString());
                bol.disc_itemdisc = dt.Rows[0]["disc_itemdisc"].ToString();
                bol.disc_typedef = dt.Rows[0]["disc_typedef"].ToString();
                bol.disc_privilege = dt.Rows[0]["disc_privilege"].ToString();
            }

            return bol;

        }

        public int Update_SalesDetails_Discount_For_DisplayAfter_sdID(int displayaftersd_id, string uid)
        {
            int result = 0;
            try
            {
                SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
                DAL_Generic dal = new DAL_Generic();
                SqlConjunction.StartTransaction();
                result = dal.Update_SalesDetails_Discount_For_DisplayAfter_sdID(displayaftersd_id, uid);
                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": BLL:Update_SalesDetails_Discount_For_DisplayAfter_sdID:error:" + ex.Message);

            }
            return result;
        }

        public bool Check_Discount_Itemize_with_Stocks(string st_stockno, string disc_name)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.Check_Discount_Itemize_with_Stocks(st_stockno, disc_name);
        }

        public DataTable SQL_Retrieve_By_String(string str_cmd)
        {
            SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
            DAL_Generic dal = new DAL_Generic();
            return dal.SQL_Retrieve_By_String(str_cmd);
        }
        public int SQL_DML_By_String(string str_cmd)
        {
            int result = 0;
            try
            {
                SqlConjunction.connection = new SqlConnection(HelperClass.DB_Conn);
                DAL_Generic dal = new DAL_Generic();
                SqlConjunction.StartTransaction();
                result = dal.SQL_DML_By_String(str_cmd);
                SqlConjunction.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
                HelperClass.WriteLog(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": BLL:SQL_DML_By_String:error:" + ex.Message);

            }
            return result;
        }
    }
}