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
        public HttpResponseMessage Get(string code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((code == "" || code == null) && (name == "" || name == null))
            {
                res = GetAllTaxItem();
            }
            else
            {
                res = GetTaxItemByCode(code);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllTaxItem()
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
        public HttpResponseMessage GetTaxItemByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_TaxItem obj = new BLL_TaxItem();
            DataTable objList = obj.BindTaxItemByCode(code);
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