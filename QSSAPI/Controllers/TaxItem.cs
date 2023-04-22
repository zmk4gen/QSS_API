using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using QSSAPI.BLL;
using DAL;
using QSSAPI.BOL;

namespace QSSAPI.Controllers
{
    [RoutePrefix("api")]
    public class TaxItem : ApiController
    {
        [HttpGet]
        [Route("~/api/TaxItem/Get")]
        public HttpResponseMessage Get(string taxitem_stockid = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((taxitem_stockid == "" || taxitem_stockid == null) && (name == "" || name == null))
            {
                res = GetAllTaxItem();
            }
            //else if (name != "" && name != null)
            //{
            //    res = GetTaxItemByName(name);
            //}
            else
            {
                res = GetTaxItemByCode(taxitem_stockid);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllTaxItem()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_TaxItem obj = new BLL_TaxItem();
            DataTable objList = obj.BindTaxItem();
            objList.TableName = "TaxItem";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/TaxItem/GetTaxItemByCode")]
        private HttpResponseMessage GetTaxItemByCode(string TaxItemCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_TaxItem obj = new BLL_TaxItem();
            DataTable objList = obj.BindTaxItemByCode(TaxItemCode);
            objList.TableName = "TaxItem";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        // POST api/TaxItem
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_TaxItem obj = new BLL_TaxItem();
            List<BOL_TaxItem> objList = new List<BOL_TaxItem>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_TaxItem>>(requestFromPost);
            string result = "";
            foreach (BOL_TaxItem temp in objList)
            {
                result += obj.InserTaxItem(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}