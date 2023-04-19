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
    public class StockGroupController : ApiController
    {
        [HttpGet]
        [Route("~/api/StockGroup/Get")]
        public HttpResponseMessage Get(string stockGroupcode = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((stockGroupcode == "" || stockGroupcode == null) && (name == "" || name == null))
            {
                res = GetAllStockGroup();
            }
            else if (name != "" && name != null)
            {
                res = GetStockGroupByName(name);
            }
            else
            {
                res = GetStockGroupByCode(stockGroupcode);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllStockGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroup();
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StockGroup/GetStockGroupByCode")]
        private HttpResponseMessage GetStockGroupByCode(string stockGroupCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroupByCode(stockGroupCode);
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StockGroup/GetStockGroupByName")]
        private HttpResponseMessage GetStockGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroupByName(name);
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/StockGroup
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_StockGroup obj = new BLL_StockGroup();
            List<BOL_StockGroup> objList = new List<BOL_StockGroup>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockGroup>>(requestFromPost);
            string result = "";
            foreach (BOL_StockGroup temp in objList)
            {
                result += obj.InsertStockGroup(temp) + ";";
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