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
    public class DAL_Generic
    {
        public DataTable Get_Seqnumberuid(int branchid)
        {
            string str_cmd = "select uidsn_id,uidsn_prefix,uidsn_docno,uidsn_suffix,uidsn_format,uidsn_branchid from seqnumberUID ";
            str_cmd += "\r\n" + "where uidsn_type = 'UID' and uidsn_branchid = " + branchid;
            str_cmd += "\r\n" + "and isnull(uidsn_breakdown,'0') <> '1'; ";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public DataTable Get_mstr_RVC()
        {
            string str_cmd = "select rvc_id, rvc_name1, rvc_typedef from mstr_RVC";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public DataTable Get_RVC_CheckNumber(int rvcid)
        {
            string str_cmd = "select rvc_id, rvc_checknext, rvc_checkmin, rvc_checkmax from mstr_rvc where rvc_id = " + rvcid;
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public DataTable Get_master_branch()
        {
            string str_cmd = "select br_ID, br_Code, br_Name, brg_ID, brg_Description, mb_dayend, br_typedef, br_subgroup, br_Pricegroup from Branch ";
            str_cmd += "\r\n" + "inner join master_branch on br_id = mb_branchid ";
            str_cmd += "\r\n" + "left join BranchGroup on br_branchgroup = brg_ID";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }


        public DataTable Get_ComboPatternQty_ForCombo(string stocknumber)
        {
            string str_cmd = "select st_id, st_StockNo, st_Description, cbo_id, cbo_Number, cbo_name, cbo_qty from Stocks s ";
            str_cmd += "\r\n" + "join ComboSettings cs on cs.cbos_stockid = s.st_id ";
            str_cmd += "\r\n" + "join mstr_combogroup mcg on cs.cbos_condid = mcg.cbo_id";
            str_cmd += "\r\n" + "where st_StockNo = '" + stocknumber + "';";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);

        }

        public DataTable Get_ComboPatternQty_ForComdiment(string stocknumber)
        {
            string str_cmd = "select s.st_id, s.st_StockNo, s.st_Description, c.cond_number, c.cond_name1, c.cond_qty as condr_qty from Stocks s ";
            str_cmd += "\r\n" + "join CondimentRequired cr on s.st_id = cr.condr_stockid ";
            str_cmd += "\r\n" + "join Condiment c on c.cond_id = cr.condr_condid ";
            str_cmd += "\r\n" + "where st_StockNo = '" + stocknumber + "';";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public DataTable Get_ComboPatternQty_ForComdiment_Allow(string stocknumber)
        {
            string str_cmd = "select s.st_id, s.st_StockNo, s.st_Description, c.cond_number, c.cond_name1, c.cond_qty * ca.conda_qty as conda_qty from Stocks s ";
            str_cmd += "\r\n" + "join CondimentAllow ca on s.st_id = ca.conda_stockid ";
            str_cmd += "\r\n" + "join Condiment c on c.cond_id = ca.conda_condid ";
            str_cmd += "\r\n" + "where st_StockNo = '" + stocknumber + "';";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public int Update_Sales_Details_ComboPatternQty(int sd_id, string uid, string sd_combopatternqty)
        {
            string str_cmd = "Update Sales_Details set sd_ComboPatternQty = '" + sd_combopatternqty + "'";
            str_cmd += "\r\n" + "where sd_id = '" + sd_id + "' and sd_uid = '" + uid + "';";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }


        public DataTable Get_SalesType_and_TransType_Info(string salestype)
        {
            string str_cmd = "select * from ";
            str_cmd += "\r\n" + "(select sat_suffix, sat_description, sat_code, sat_typedef, stt_taxid, sat_price, mci_code from mstr_salestype ";
            str_cmd += "\r\n" + "inner join MacroDetail on mci_runtimedata3 = sat_code ";
            str_cmd += "\r\n" + "inner join MacroHead on mc_code = mci_code ";
            str_cmd += "\r\n" + "left join SalesTypeTax on stt_salestypeid = sat_id ";
            str_cmd += "\r\n" + "where mci_runtimedata2 = 'SALE006' and mci_runtimedata3 = '" + salestype + "') as salestype ";
            str_cmd += "\r\n" + "inner join ";
            str_cmd += "\r\n" + "(select tat_code, tat_description, mci_code from mstr_transtype ";
            str_cmd += "\r\n" + "inner join MacroDetail on mci_runtimedata3 = tat_code ";
            str_cmd += "\r\n" + "inner join MacroHead on mc_code = mci_code ";
            str_cmd += "\r\n" + "where mci_runtimedata2 = 'SALE007') as transtype on salestype.mci_code = transtype.mci_code;";

            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public DataTable Get_ServiceCharge()
        {
            SqlCommand sqlCmd = new SqlCommand("select * from mstr_servicecharge");
            sqlCmd.CommandType = CommandType.Text;

            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public BOL_Tax Get_Tax_By_Stock(int stock_id, int tax_id)
        {
            BOL_Tax obj = new BOL_Tax();

            string str_cmd = "select tax_id, tax_number, tax_desc, tax_type ";
            str_cmd += ", tax_accountcode, tax_percentage, tax_startamount, Tax_code ";
            str_cmd += "from mstr_tax ";
            str_cmd += "inner join TaxItem on tax_id = taxitem_taxid ";
            str_cmd += "where taxitem_stockid = @stock_id and tax_id = @tax_id and tax_inactive = 0";

            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@stock_id", stock_id);
            sqlCmd.Parameters.AddWithValue("@tax_id", tax_id);

            var dt = SqlConjunction.GetSQLDataTable(sqlCmd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                obj.tax_id = HelperClass.ConvertInteger(dt.Rows[i]["tax_id"].ToString());
                obj.tax_number = dt.Rows[i]["tax_number"].ToString();
                obj.tax_desc = dt.Rows[i]["tax_desc"].ToString();
                obj.tax_type = dt.Rows[i]["tax_type"].ToString();
                obj.tax_accountcode = dt.Rows[i]["tax_accountcode"].ToString();
                obj.tax_percentage = HelperClass.ConvertDecimal(dt.Rows[i]["tax_percentage"].ToString());
                obj.tax_startamount = HelperClass.ConvertInteger(dt.Rows[i]["tax_startamount"].ToString());
                obj.Tax_code = dt.Rows[i]["Tax_code"].ToString();
            }
            return obj;
        }

        public DataTable Get_Discount_By_Name(string discname)
        {
            string str_cmd = "select disc_id, disc_number, disc_name1, disc_name2, disc_name3, disc_amount, disc_percentage ";
            str_cmd += "\r\n" + ", disc_itemdisc, disc_typedef, disc_privilege From Discount ";
            str_cmd += "\r\n" + "where disc_name1 = '" + discname + "'";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public int Update_SalesDetails_Discount_For_DisplayAfter_sdID(int displayaftersd_id, string uid)
        {
            string str_cmd = "Update SalesDetails_Discount ";
            str_cmd += "\r\n" + "set sdd_DisplayAftersdid = " + displayaftersd_id;
            str_cmd += "\r\n" + "where sdd_uid = '" + uid + "'";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }

        public bool Check_Discount_Itemize_with_Stocks(string st_stockno, string disc_name)
        {
            bool allow_discount = false;
            string str_cmd = "select st_Description, disc_name1 From Stocks ";
            str_cmd += "\r\n" + "inner join DiscountItemize on st_discitemize = discitem_itemizeid ";
            str_cmd += "\r\n" + "inner join Discount on disc_id = discitem_discid ";
            str_cmd += "\r\n" + "where st_StockNo = '" + st_stockno + "' and disc_name1 = '" + disc_name + "'";
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            DataTable dt = SqlConjunction.GetSQLDataTable(sqlCmd);
            if(dt.Rows.Count > 0)
            {
                allow_discount = true;
            }
            return allow_discount;
        }


        public DataTable SQL_Retrieve_By_String(string str_cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLDataTable(sqlCmd);
        }

        public int SQL_DML_By_String(string str_cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(str_cmd);
            return SqlConjunction.GetSQLTransVoid(sqlCmd);
        }

    }
}