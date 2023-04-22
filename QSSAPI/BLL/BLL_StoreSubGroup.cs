using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;


namespace QSSAPI.BLL
{
    public class BLL_StoreSubGroup
    {
        public DataTable BindStoreSubGroup()
        {
            DAL_StoreSubGroup dalStoreSubGroup = new DAL_StoreSubGroup();
            return dalStoreSubGroup.BindStoreSubGroup();
        }

        public DataTable BindStoreSubGroupByCode(string code)
        {
            DAL_StoreSubGroup dalStoreSubGroup = new DAL_StoreSubGroup();
            return dalStoreSubGroup.BindStoreSubGroupByNumber(code);
        }

        public DataTable BindStoreSubGroupByDesc(string desc)
        {
            DAL_StoreSubGroup dalStoreSubGroup = new DAL_StoreSubGroup();
            return dalStoreSubGroup.BindStoreSubGroupByDesc(desc);
        }
    }
}