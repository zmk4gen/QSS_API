using QSSAPI.BOL;
using QSSAPI.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QSSAPI.DAL
{
    public class DAL_Sales_Details
    {
        public int Insert_Sales_Details(BOL_Sales_Details bol_sd)
        {
            SqlCommand sqlCmd = new SqlCommand("sp_Insert_Sales_Details_API_Ordering");
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@sd_StockID", bol_sd.sd_StockID);
            sqlCmd.Parameters.AddWithValue("@sd_Qty", bol_sd.sd_Qty);
            sqlCmd.Parameters.AddWithValue("@sd_SPrice", bol_sd.sd_SPrice);
            sqlCmd.Parameters.AddWithValue("@sd_DiscPercent", bol_sd.sd_DiscPercent);
            sqlCmd.Parameters.AddWithValue("@sd_Disc", bol_sd.sd_Disc);

            sqlCmd.Parameters.AddWithValue("@sd_uid", bol_sd.sd_uid);
            sqlCmd.Parameters.AddWithValue("@sd_CostPrice", bol_sd.sd_CostPrice);
            sqlCmd.Parameters.AddWithValue("@sd_pType", bol_sd.sd_pType);
            sqlCmd.Parameters.AddWithValue("@sd_VoucherNo", bol_sd.sd_VoucherNo);
            sqlCmd.Parameters.AddWithValue("@sd_UOM", bol_sd.sd_UOM);

            sqlCmd.Parameters.AddWithValue("@sd_Contain", bol_sd.sd_Contain);
            sqlCmd.Parameters.AddWithValue("@sd_branchid", bol_sd.sd_branchid);
            sqlCmd.Parameters.AddWithValue("@sd_sn", bol_sd.sd_sn);
            sqlCmd.Parameters.AddWithValue("@sd_linepoints", bol_sd.sd_linepoints);
            sqlCmd.Parameters.AddWithValue("@sd_Description", bol_sd.sd_Description);

            sqlCmd.Parameters.AddWithValue("@sd_att1", bol_sd.sd_att1);
            sqlCmd.Parameters.AddWithValue("@sd_att2", bol_sd.sd_att2);
            sqlCmd.Parameters.AddWithValue("@sd_returnfrom", bol_sd.sd_returnfrom);
            sqlCmd.Parameters.AddWithValue("@sd_hd", bol_sd.sd_hd);
            sqlCmd.Parameters.AddWithValue("@sd_HDSerialNo", bol_sd.sd_HDSerialNo);

            sqlCmd.Parameters.AddWithValue("@sd_updateST", bol_sd.sd_updateST);
            sqlCmd.Parameters.AddWithValue("@sd_location", bol_sd.sd_location);
            sqlCmd.Parameters.AddWithValue("@sd_export", bol_sd.sd_export);
            sqlCmd.Parameters.AddWithValue("@sd_sono", bol_sd.sd_sono);
            sqlCmd.Parameters.AddWithValue("@sd_promotype", bol_sd.sd_promotype);

            sqlCmd.Parameters.AddWithValue("@sd_promoparentid", bol_sd.sd_promoparentid);
            sqlCmd.Parameters.AddWithValue("@sd_promosdid", bol_sd.sd_promosdid);
            sqlCmd.Parameters.AddWithValue("@sd_spriceBeforeMK", bol_sd.sd_spriceBeforeMK);
            sqlCmd.Parameters.AddWithValue("@sd_markdownpercent", bol_sd.sd_markdownpercent);
            sqlCmd.Parameters.AddWithValue("@sd_voucheruid", bol_sd.sd_voucheruid);

            sqlCmd.Parameters.AddWithValue("@sd_productvoucher", bol_sd.sd_productvoucher);
            sqlCmd.Parameters.AddWithValue("@sd_commissionCompPercent", bol_sd.sd_commissionCompPercent);
            sqlCmd.Parameters.AddWithValue("@sd_commissionCompValue", bol_sd.sd_commissionCompValue);
            sqlCmd.Parameters.AddWithValue("@sd_commissionTravelPercent", bol_sd.sd_commissionTravelPercent);
            sqlCmd.Parameters.AddWithValue("@sd_commissionTravelValue", bol_sd.sd_commissionTravelValue);

            sqlCmd.Parameters.AddWithValue("@sd_commissionPercent", bol_sd.sd_commissionPercent);
            sqlCmd.Parameters.AddWithValue("@sd_commissionValue", bol_sd.sd_commissionValue);
            sqlCmd.Parameters.AddWithValue("@sd_commission", bol_sd.sd_commission);
            sqlCmd.Parameters.AddWithValue("@sd_TaxPercent", bol_sd.sd_TaxPercent);
            sqlCmd.Parameters.AddWithValue("@sd_TaxAmount", bol_sd.sd_TaxAmount);

            sqlCmd.Parameters.AddWithValue("@sd_CommissionCalculationAmt", bol_sd.sd_CommissionCalculationAmt);
            sqlCmd.Parameters.AddWithValue("@sd_DiscountType", bol_sd.sd_DiscountType);
            sqlCmd.Parameters.AddWithValue("@sd_SPromo", bol_sd.sd_SPromo);
            sqlCmd.Parameters.AddWithValue("@sd_lineextra", bol_sd.sd_lineextra);
            sqlCmd.Parameters.AddWithValue("@sd_packageparentid", bol_sd.sd_packageparentid);

            sqlCmd.Parameters.AddWithValue("@sd_kitchenhold", bol_sd.sd_kitchenhold);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenfire", bol_sd.sd_kitchenfire);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenbump", bol_sd.sd_kitchenbump);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenfireon", bol_sd.sd_kitchenfireon);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenfireby", bol_sd.sd_kitchenfireby);

            sqlCmd.Parameters.AddWithValue("@sd_kitchenbumpon", bol_sd.sd_kitchenbumpon);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenbumpby", bol_sd.sd_kitchenbumpby);
            sqlCmd.Parameters.AddWithValue("@sd_salestype", bol_sd.sd_salestype);
            sqlCmd.Parameters.AddWithValue("@sd_combopattern", bol_sd.sd_combopattern);
            sqlCmd.Parameters.AddWithValue("@sd_combogroup", bol_sd.sd_combogroup);

            sqlCmd.Parameters.AddWithValue("@sd_cook", bol_sd.sd_cook);
            sqlCmd.Parameters.AddWithValue("@sd_collect", bol_sd.sd_collect);
            sqlCmd.Parameters.AddWithValue("@sd_actualproduct", bol_sd.sd_actualproduct);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenprint", bol_sd.sd_kitchenprint);
            sqlCmd.Parameters.AddWithValue("@sd_kitchenprinton", bol_sd.sd_kitchenprinton);

            sqlCmd.Parameters.AddWithValue("@sd_printengine", bol_sd.sd_printengine);
            sqlCmd.Parameters.AddWithValue("@sd_enterby", bol_sd.sd_enterby);
            sqlCmd.Parameters.AddWithValue("@sd_auto", bol_sd.sd_auto);
            sqlCmd.Parameters.AddWithValue("@sd_refund", bol_sd.sd_refund);
            sqlCmd.Parameters.AddWithValue("@sd_taxtype", bol_sd.sd_taxtype);

            sqlCmd.Parameters.AddWithValue("@sd_TaxAmountActual", bol_sd.sd_TaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_svcpercent", bol_sd.sd_svcpercent);
            sqlCmd.Parameters.AddWithValue("@sd_svcamount", bol_sd.sd_svcamount);
            sqlCmd.Parameters.AddWithValue("@sd_svcamountactual", bol_sd.sd_svcamountactual);
            sqlCmd.Parameters.AddWithValue("@sd_svctype", bol_sd.sd_svctype);

            sqlCmd.Parameters.AddWithValue("@sd_voidremarks", bol_sd.sd_voidremarks);
            sqlCmd.Parameters.AddWithValue("@sd_discountDesc", bol_sd.sd_discountDesc);
            sqlCmd.Parameters.AddWithValue("@sd_resume", bol_sd.sd_resume);
            sqlCmd.Parameters.AddWithValue("@sd_ItemTaxAmount", bol_sd.sd_ItemTaxAmount);
            sqlCmd.Parameters.AddWithValue("@sd_ItemTaxAmountActual", bol_sd.sd_ItemTaxAmountActual);

            sqlCmd.Parameters.AddWithValue("@sd_SVCTaxAmount", bol_sd.sd_SVCTaxAmount);
            sqlCmd.Parameters.AddWithValue("@sd_SVCTaxAmountActual", bol_sd.sd_SVCTaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_seatno", bol_sd.sd_seatno);
            sqlCmd.Parameters.AddWithValue("@sd_splitfrom", bol_sd.sd_splitfrom);
            sqlCmd.Parameters.AddWithValue("@sd_checkno", bol_sd.sd_checkno);

            sqlCmd.Parameters.AddWithValue("@sd_notallowdiscountagain", bol_sd.sd_notallowdiscountagain);
            sqlCmd.Parameters.AddWithValue("@sd_AddOnTaxAmountActual", bol_sd.sd_AddOnTaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_InclusiveTaxAmountActual", bol_sd.sd_InclusiveTaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_ItemAddOnTaxAmountActual", bol_sd.sd_ItemAddOnTaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_ItemInclusiveTaxAmountActual", bol_sd.sd_ItemInclusiveTaxAmountActual);

            sqlCmd.Parameters.AddWithValue("@sd_SVCAddOnTaxAmountActual", bol_sd.sd_SVCAddOnTaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_SVCInclusiveTaxAmountActual", bol_sd.sd_SVCInclusiveTaxAmountActual);
            sqlCmd.Parameters.AddWithValue("@sd_iscondi", bol_sd.sd_iscondi);
            sqlCmd.Parameters.AddWithValue("@sd_AmtForCalcSVC", bol_sd.sd_AmtForCalcSVC);
            sqlCmd.Parameters.AddWithValue("@sd_AmtForCalcTax", bol_sd.sd_AmtForCalcTax);

            sqlCmd.Parameters.AddWithValue("@sd_combopatterncbosid", bol_sd.sd_combopatterncbosid);
            sqlCmd.Parameters.AddWithValue("@sd_combocbosid", bol_sd.sd_combocbosid);
            sqlCmd.Parameters.AddWithValue("@sd_condiparentid", bol_sd.sd_condiparentid);
            sqlCmd.Parameters.AddWithValue("@sd_comboparentid", bol_sd.sd_comboparentid);
            sqlCmd.Parameters.AddWithValue("@sd_combopatterncount", bol_sd.sd_combopatterncount);

            sqlCmd.Parameters.AddWithValue("@sd_packageparentstockid", bol_sd.sd_packageparentstockid);
            sqlCmd.Parameters.AddWithValue("@sd_iid", bol_sd.sd_iid);
            sqlCmd.Parameters.AddWithValue("@sd_SalesTypeSuffix", bol_sd.sd_SalesTypeSuffix);
            sqlCmd.Parameters.AddWithValue("@sd_Casher", bol_sd.sd_Casher);
            sqlCmd.Parameters.AddWithValue("@sd_CasherName", bol_sd.sd_CasherName);

            sqlCmd.Parameters.AddWithValue("@sd_SalesPerson", bol_sd.sd_SalesPerson);
            sqlCmd.Parameters.AddWithValue("@sd_SalesPersonName", bol_sd.sd_SalesPersonName);
            sqlCmd.Parameters.AddWithValue("@sd_prttokitchen", bol_sd.sd_prttokitchen);
            sqlCmd.Parameters.AddWithValue("@sd_recipestatus", bol_sd.sd_recipestatus);
            sqlCmd.Parameters.AddWithValue("@sd_updaterecipe", bol_sd.sd_updaterecipe);

            sqlCmd.Parameters.AddWithValue("@sd_prttoprinter", bol_sd.sd_prttoprinter);
            sqlCmd.Parameters.AddWithValue("@sd_weight", bol_sd.sd_weight);
            sqlCmd.Parameters.AddWithValue("@sd_spriceBeforeWeight", bol_sd.sd_spriceBeforeWeight);
            sqlCmd.Parameters.AddWithValue("@sd_WeightItem", bol_sd.sd_WeightItem);
            sqlCmd.Parameters.AddWithValue("@sd_servicechargeid", bol_sd.sd_servicechargeid);

            sqlCmd.Parameters.AddWithValue("@sd_servicechargename", bol_sd.sd_servicechargename);
            sqlCmd.Parameters.AddWithValue("@sd_shiftid", bol_sd.sd_shiftid);
            sqlCmd.Parameters.AddWithValue("@sd_shiftno", bol_sd.sd_shiftno);
            sqlCmd.Parameters.AddWithValue("@sd_shiftrefno", bol_sd.sd_shiftrefno);
            sqlCmd.Parameters.AddWithValue("@sd_pcscount", bol_sd.sd_pcscount);

            sqlCmd.Parameters.AddWithValue("@sd_ComboPatternQty", bol_sd.sd_ComboPatternQty);
            sqlCmd.Parameters.AddWithValue("@sd_TotalInclusivePercentage", bol_sd.sd_TotalInclusivePercentage);

            if (bol_sd.sd_NettAfterDiscountForCalcTax == 0)
                sqlCmd.Parameters.AddWithValue("@sd_NettAfterDiscountForCalcTax", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@sd_NettAfterDiscountForCalcTax", bol_sd.sd_NettAfterDiscountForCalcTax);

            sqlCmd.Parameters.AddWithValue("@sd_Nett", bol_sd.sd_Nett);
            sqlCmd.Parameters.AddWithValue("@sd_fireonthefly", bol_sd.sd_fireonthefly);

            sqlCmd.Parameters.AddWithValue("@sd_fireontheflytime", bol_sd.sd_fireontheflytime);
            sqlCmd.Parameters.AddWithValue("@sd_kdsend", bol_sd.sd_kdsend);
            sqlCmd.Parameters.AddWithValue("@sd_businessdate", bol_sd.sd_businessdate);
            sqlCmd.Parameters.AddWithValue("@sd_UniqueSDID", bol_sd.sd_UniqueSDID);
            sqlCmd.Parameters.AddWithValue("@sd_kdsendonthefly", bol_sd.sd_kdsendonthefly);

            sqlCmd.Parameters.AddWithValue("@sd_mobiletemp", bol_sd.sd_mobiletemp);
            sqlCmd.Parameters.AddWithValue("@sd_syncdata", bol_sd.sd_syncdata);
            sqlCmd.Parameters.AddWithValue("@sd_syncvoiddata", bol_sd.sd_syncvoiddata);

            foreach (SqlParameter Parameter in sqlCmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

            return SqlConjunction.GetSQLTransScalar(sqlCmd);
        }
    }
}