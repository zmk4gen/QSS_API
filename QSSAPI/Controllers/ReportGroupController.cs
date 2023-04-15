using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.IO;
using Newtonsoft.Json;

using QSSAPI.BLL;
using DAL;
using QSSAPI.BOL;
using System.Net.Http.Headers;
using System.Web;

namespace QSSAPI.Controllers
{
    public class ReportGroupController : ApiController
    {
        // GET: api/ReportGroup
        public HttpResponseMessage Get(string code = "", string Desc = "")
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if (code == "" && Desc == "")
            {
                res = GetAllReportGroup();
            }
            else if (Desc != "")
            {
                res = ReportGroupByDesc(Desc);
            }
            else
            {
                res = ReportGroupByCode(code);
            }
            return res;
        }

        // GET: api/FamilyGroup
        [HttpGet]
        private HttpResponseMessage GetAllReportGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindReportGroup();
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        private HttpResponseMessage ReportGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindReportGroupByCode(code);
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        [HttpGet]
        private HttpResponseMessage ReportGroupByDesc(string Desc)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockType obj = new BLL_StockType();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindReportGroupByDesc(Desc);
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST: api/ReportGroup
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_StockType obj = new BLL_StockType();
            List<BOL_StockType> objList = new List<BOL_StockType>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockType>>(requestFromPost);//may raise exception because of the json string => format error
            string result = "";
            foreach (BOL_StockType temp in objList)
            {
                result += obj.InsertReportGroup(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        //private HttpResponseMessage InsertReportGroup()
        //{

        //    BLL_StockType obj = new BLL_StockType();
        //    List<BOL_StockType> objList = new List<BOL_StockType>();
        //    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
        //    reader.BaseStream.Position = 0;
        //    string requestFromPost = reader.ReadToEnd();
        //    objList = JsonConvert.DeserializeObject<List<BOL_StockType>>(requestFromPost);//may raise exception because of the json string => format error
        //    string result = "";
        //    foreach (BOL_StockType temp in objList)
        //    {
        //        result += obj.InsertReportGroup(temp) + ";";
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, result);
        //}
        // PUT: api/ReportGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReportGroup/5
        public void Delete(int id)
        {
        }
    }
}
