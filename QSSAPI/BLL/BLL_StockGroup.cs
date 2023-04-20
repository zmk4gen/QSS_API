using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

<<<<<<< HEAD
using System.Data.SqlClient;
using System.Data;
using QSSAPI.BOL;
using QSSAPI.DAL;
=======
using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe

namespace QSSAPI.BLL
{
    public class BLL_StockGroup
    {
<<<<<<< HEAD
        /// <summary>
        /// Family Group
        /// </summary>
        /// <returns></returns>
        public DataTable BindFamilyGroup()
        {
            DAL_StockGroup dalmenuitem = new DAL_StockGroup();
            return dalmenuitem.BindFamilyGroup();
        }
        public DataTable BindFamilyGroupByCode(string code)
        {
            DAL_StockGroup dalmenuitem = new DAL_StockGroup();
            return dalmenuitem.BindFamilyGroupByCode(code);
        }
        public DataTable BindFamilyGroupByName(string name)
        {
            DAL_StockGroup dalmenuitem = new DAL_StockGroup();
            return dalmenuitem.BindFamilyGroupByName(name);
        }

        public int InsertFamilyGroup(BOL_StockGroup bolstockgroup)
=======
        public DataTable BindStockGroup()
        {
            DAL_StockGroup dalStockGroup = new DAL_StockGroup();
            return dalStockGroup.BindStockGroup();
        }

        public DataTable BindStockGroupByCode(string code)
        {
            DAL_StockGroup dalStockGroup = new DAL_StockGroup();
            return dalStockGroup.BindStockGroupByCode(code);
        }

        public DataTable BindStockGroupByName(string name)
        {
            DAL_StockGroup dalStockGroup = new DAL_StockGroup();
            return dalStockGroup.BindStockGroupByName(name);
        }

        public int InsertStockGroup(BOL_StockGroup bolstockgroup)
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

<<<<<<< HEAD
                DAL_StockGroup dalmenuitem = new DAL_StockGroup();
                effectID = dalmenuitem.Insert_FamilyGroup(bolstockgroup);

                SqlConjunction.CommitTransaction();

=======
                DAL_StockGroup dalstockgroup = new DAL_StockGroup();
                effectID = dalstockgroup.Insert_StockGroup(bolstockgroup);

                SqlConjunction.CommitTransaction();
>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
            }
            catch (Exception ex)
            {
                SqlConjunction.RollbackTransaction(ex.Message);
<<<<<<< HEAD
            }
            return effectID;
        }
=======
                
            }
            return effectID;
        }

>>>>>>> 0dd232699496117e7f68fb51c4a4d687c5de24fe
    }
}