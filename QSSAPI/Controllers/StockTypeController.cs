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
        public HttpResponseMessage Get(string code = null, string name=null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((code == "" || code == null) && (name == "" || name == null))
            {
                res = GetAllStockType();
            }
            else if (name != "" && name != null)
            {
                res = GetStockTypeByName(name);
            }
            else
            {
                res = GetStockTypeByStockCode(code);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllStockType()
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
        public HttpResponseMessage GetStockTypeByStockCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            DataTable objList = obj.BindStockTypeByCode(code);
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

        // POST api/StockType
        public HttpResponseMessage Post([FromBody]string value)
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

        // PUT api/StockType
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            BLL_StockType obj = new BLL_StockType();
            BOL_StockType objStockType = new BOL_StockType();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPut = reader.ReadToEnd();
            objStockType = JsonConvert.DeserializeObject<BOL_StockType>(requestFromPut);
            string result = "";
            result = obj.UpdateStockType(objStockType) + ";";

            return Request.CreateResponse(HttpStatusCode.OK, result);
            
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}