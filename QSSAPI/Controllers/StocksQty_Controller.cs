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
    public class StocksQty_Controller : ApiController
    {
        [HttpGet]
        [Route("~/api/StocksQty/Get")]
        public HttpResponseMessage Get(string sq_stockid = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((sq_stockid == "" || sq_stockid == null)) // && (name == "" || name == null))
            {
                res = GetAllStocksQty();
            }
            //else if (name != "" && name != null)
            //{
            //    res = GetStocksQtyByName(name);
            //}
            else
            {
                res = GetStocksQtyByCode(sq_stockid);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllStocksQty()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StocksQty obj = new BLL_StocksQty();
            DataTable objList = obj.BindStocksQty();
            objList.TableName = "StocksQty";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StocksQty/GetStocksQtyByCode")]
        private HttpResponseMessage GetStocksQtyByCode(string StocksQtyCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StocksQty obj = new BLL_StocksQty();
            DataTable objList = obj.BindStocksQtyByCode(StocksQtyCode);
            objList.TableName = "StocksQty";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }
        
        // POST api/StocksQty
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_StocksQty obj = new BLL_StocksQty();
            List<BOL_StocksQty> objList = new List<BOL_StocksQty>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StocksQty>>(requestFromPost);
            string result = "";
            foreach (BOL_StocksQty temp in objList)
            {
                result += obj.InserStocksQty(temp) + ";";
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