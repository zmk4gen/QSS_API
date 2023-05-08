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

    public class StockTypeController : ApiController
    {
        // GET api/StockType/Get
        [HttpGet]
        [Route("~/api/StockType/Get")]
        public HttpResponseMessage Get(string stockTypeCode = null, string name=null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((stockTypeCode == "" || stockTypeCode == null) && (name == "" || name == null))
            {
                res = GetAllStockType();
            }
            else if (name != "" && name != null)
            {
                res = GetStockTypeByName(name);
            }
            else
            {
                res = GetStockTypeByStockCode(stockTypeCode);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllStockType()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            DataTable objList = obj.BindStockType();
            objList.TableName = "Stock_Type";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            return res;
        }

        [HttpGet]
        [Route("~/api/StockType/GetStockTypeByStockCode")]
        private HttpResponseMessage GetStockTypeByStockCode(string stockTypeCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            DataTable objList = obj.BindStockTypeByCode(stockTypeCode);
            objList.TableName = "Stock_Type";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StockType/GetStockTypeByName")]
        public HttpResponseMessage GetStockTypeByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            DataTable objList = obj.BindStockTypeByName(name);
            objList.TableName = "Stock_Type";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpPost]
        [Route("~/api/StockType/InsertStocktype")]
        // POST api/StockType
        public HttpResponseMessage Post()
        {
            BLL_StockType obj = new BLL_StockType();
            List<BOL_StockType> objList = new List<BOL_StockType>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockType>>(requestFromPost);
            string result = "";
            foreach(BOL_StockType temp in objList)
            {
                result += obj.InsertStockType(temp) + ";";
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