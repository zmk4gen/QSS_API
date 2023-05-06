using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;

namespace QSSAPI.BLL
{
    public class BLL_UserDepartment
    {
        public DataTable BindUserDepartment()
        {
            DAL_UserDepartment dalUserDepartment = new DAL_UserDepartment();
            return dalUserDepartment.BindUserDepartment();
        }

        public DataTable BindUserDepartmentByCode(string code)
        {
            DAL_UserDepartment dalUserDepartment = new DAL_UserDepartment();
            return dalUserDepartment.BindUserDepartmentByNumber(code);
        }

        public DataTable BindUserDepartmentByName(string name)
        {
            DAL_UserDepartment dalUserDepartment = new DAL_UserDepartment();
            return dalUserDepartment.BindUserDepartmentByName(name);
        }

        public int InserUserDepartment(BOL_UserDepartment bolUserDepartment)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_UserDepartment dalUserDepartment = new DAL_UserDepartment();
                effectID = dalUserDepartment.Insert_UserDepartment(bolUserDepartment);

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