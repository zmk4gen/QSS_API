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
    public class StockPriceController : ApiController
    {
        [HttpGet]
        [Route("~/api/StockPrice/Get")]
        public HttpResponseMessage Get(string pt_pgcode = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((pt_pgcode == "" || pt_pgcode == null))// && (name == "" || name == null))
            {
                res = GetAllStockPrice();
            }
            //else if (name != "" && name != null)
            //{
            //    res = GetCondimentByName(name);
            //}
            else
            {
                res = GetStockPriceByCode(pt_pgcode);
            }

            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllStockPrice()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockPrice obj = new BLL_StockPrice();
            DataTable objList = obj.BindStockPrice();
            objList.TableName = "Stock_PriceTable";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StockPrice/GetStockPriceByCode")]
        private HttpResponseMessage GetStockPriceByCode(string StockPriceCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockPrice obj = new BLL_StockPrice();
            DataTable objList = obj.BindStockPriceByCode(StockPriceCode);
            objList.TableName = "Stock_PriceTable";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        // POST api/StockPrice
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_StockPrice obj = new BLL_StockPrice();
            List<BOL_StockPriceTable> objList = new List<BOL_StockPriceTable>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockPriceTable>>(requestFromPost);
            string result = "";
            foreach (BOL_StockPriceTable temp in objList)
            {
                result += obj.InserStockPrice(temp) + ";";
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