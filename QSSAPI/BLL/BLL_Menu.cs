using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;
namespace QSSAPI.BLL
{
    public class BLL_Menu
    {
       
       
        /// <summary>
        /// Menu Item
        /// </summary>
        /// <returns></returns>
        public DataTable BindMenuItem()
        {
            DAL_Menu dal_menuitem = new DAL_Menu();
            return dal_menuitem.BindMenuitem();
        }
        public DataTable SelectbyMenuItem(string stockno)
        {
                DAL_Menu dal_menuitem = new DAL_Menu();
            return dal_menuitem.SelectbyMenuItem(stockno);
        }
        public DataTable SearchByMenuItem(string desc)
        {
            DAL_Menu dal_menuItem = new DAL_Menu();
            return dal_menuItem.SearchbyMenuItem(desc);
        }

        public DataTable SearchByMenuItemByStockNoANDDesc(string stock_no,string desc)
        {
            DAL_Menu dal_menuItem = new DAL_Menu();
            return dal_menuItem.SearchbyMenuItemByStockNoANDDesc(stock_no, desc);
        }
        public DataTable SelectAllBranch()
        {
            DAL_Menu dal_menuItem = new DAL_Menu();
            return dal_menuItem.Branch_SelectAll();
        }
        public int InsertMenuItem(BOL_stock bolmenuitem)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_Menu dalmenuitem = new DAL_Menu();
                effectID = dalmenuitem.Insert_MenuItem(bolmenuitem);

                SqlConjunction.CommitTransaction();

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
            }
            return effectID;
        }

        public int InsertStockPrice(BOL_stock bolmenuitem)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_Menu dalmenuitem = new DAL_Menu();
                effectID = dalmenuitem.Insert_StockPrice(bolmenuitem);

                SqlConjunction.CommitTransaction();

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
            }
            return effectID;
        }
        public int InsertStockQty(BOL_stock bolmenuitem)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_Menu dalmenuitem = new DAL_Menu();
                effectID = dalmenuitem.Insert_StockQty(bolmenuitem);

                SqlConjunction.CommitTransaction();

            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
            }
            return effectID;
        }

    }
}