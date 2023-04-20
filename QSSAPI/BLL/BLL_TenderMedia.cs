using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using QSSAPI.DAL;
using QSSAPI.BOL;


namespace QSSAPI.BLL
{
    public class BLL_TenderMedia
    {
        public DataTable BindTenderMedia()
        {
            DAL_TenderMedia dalTenderMedia = new DAL_TenderMedia();
            return dalTenderMedia.BindTenderMedia();
        }

        public DataTable BindTenderMediaByCode(string code)
        {
            DAL_TenderMedia dalTenderMedia = new DAL_TenderMedia();
            return dalTenderMedia.BindTenderMediaByNumber(code);
        }

        public DataTable BindTenderMediaByName(string name)
        {
            DAL_TenderMedia dalTenderMedia = new DAL_TenderMedia();
            return dalTenderMedia.BindTenderMediaByName(name);
        }

        public int InserTenderMedia(BOL_TenderMedia bolTenderMedia)
        {
            int effectID = 0;
            try
            {
                SqlConjunction.StartTransaction();

                DAL_TenderMedia dalTenderMedia = new DAL_TenderMedia();
                effectID = dalTenderMedia.Insert_TenderMeida(bolTenderMedia);

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