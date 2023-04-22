using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_StoreDetail
    {
        public DataTable BindStoreDeteail()
        {
            DAL_StoreDetail dalStoreDetail = new DAL_StoreDetail();
            return dalStoreDetail.BindStoreDetail();
        }

        public DataTable BindStoreDetailByCode(string code)
        {
            DAL_StoreDetail dalStoreDetail = new DAL_StoreDetail();
            return dalStoreDetail.BindStoreDetailByNumber(code);
        }

        public DataTable BindStoreDetailByName(string name)
        {
            DAL_StoreDetail dalStoreDetail = new DAL_StoreDetail();
            return dalStoreDetail.BindStoreDetailByName(name);
        }

    }
}