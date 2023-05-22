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
    public class CurrencyController : ApiController
    {
        [HttpGet]
        [Route("~/api/Currency/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllCurrency();
            }
            else if (name != "" && name != null)
            {
                res = GetCurrencyByName(name);
            }
            else
            {
                res = GetCurrencyByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllCurrency()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Currency obj = new BLL_Currency();
            DataTable objList = obj.BindCurrency();
            objList.TableName = "Currency";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/Currency/GetCurrencyByCode")]
        public HttpResponseMessage GetCurrencyByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Currency obj = new BLL_Currency();
            DataTable objList = obj.BindCurrencyByCode(code);
            objList.TableName = "Currency";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/Currency/GetCurrencyByName")]
        public HttpResponseMessage GetCurrencyByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Currency obj = new BLL_Currency();
            DataTable objList = obj.BindCurrencyByName(name);
            objList.TableName = "Currency";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/Currency
        [HttpPost]
        [Route("~/api/Currency/InsertCurrency")]
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_Currency obj = new BLL_Currency();
            List<BOL_Currency> objList = new List<BOL_Currency>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_Currency>>(requestFromPost);
            string result = "";
            foreach (BOL_Currency temp in objList)
            {
                result += obj.InserCurrency(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT api/Currency
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            BLL_Currency obj = new BLL_Currency();
            BOL_Currency objCurrency = new BOL_Currency();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPut = reader.ReadToEnd();
            objCurrency = JsonConvert.DeserializeObject<BOL_Currency>(requestFromPut);
            string result = "";
            result = obj.UpdateCurrency(objCurrency) + ";";

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}