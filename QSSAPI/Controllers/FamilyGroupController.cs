using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using QSSAPI.BLL;
using DAL;
using QSSAPI.BOL;
using System.Net.Http.Headers;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace QSSAPI.Controllers
{
    public class FamilyGroupController : ApiController
    {
        // GET: api/FamilyGroup
        public HttpResponseMessage Get(string code = "", string name = "")
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if( (code == "" || code==null) && (name == "" || name ==null) )
            {
                res = FamilyGroup();
            }
            else if (name != "")
            {
                res = FamilyGroupByName(name);
            }
            else
            {
                res = FamilyGroupByCode(code);
            }
            return res;
        }

        // GET: api/FamilyGroup
        [HttpGet]
        private HttpResponseMessage FamilyGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindFamilyGroup();
            objList.TableName = "FamilyGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        private HttpResponseMessage FamilyGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindFamilyGroupByCode(code);
            objList.TableName = "FamilyGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        [HttpGet]
        private HttpResponseMessage FamilyGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindFamilyGroupByName(name);
            objList.TableName = "FamilyGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        // POST: api/FamilyGroup
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_StockGroup obj = new BLL_StockGroup();
            List<BOL_StockGroup> objList = new List<BOL_StockGroup>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockGroup>>(requestFromPost);//may raise exception because of the json string => format error
            string result = "";
            foreach (BOL_StockGroup temp in objList)
            {
                result += obj.InsertFamilyGroup(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //private HttpResponseMessage InsertFamilyGroup()
        //{

        //    BLL_StockGroup obj = new BLL_StockGroup();
        //    List<BOL_StockGroup> objList = new List<BOL_StockGroup>();
        //    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
        //    reader.BaseStream.Position = 0;
        //    string requestFromPost = reader.ReadToEnd();
        //    objList = JsonConvert.DeserializeObject<List<BOL_StockGroup>>(requestFromPost);//may raise exception because of the json string => format error
        //    string result = "";
        //    foreach (BOL_StockGroup temp in objList)
        //    {
        //        result += obj.InsertFamilyGroup(temp) + ";";
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, result);
        //}

        // PUT: api/FamilyGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FamilyGroup/5
        public void Delete(int id)
        {
        }
    }
}
