using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.IO;

using QSSAPI.BLL;
using DAL;
using QSSAPI.BOL;

using System.Net.Http.Headers;
using System.Web;

namespace QSSAPI.Controllers
{
    public class MajorGroupController : ApiController
    {
        //// GET: api/MajorGroup
        [HttpGet]
        public HttpResponseMessage Get(string code = "", string name = "")
        {
            HttpResponseMessage res = new HttpResponseMessage();

            if ((code == "" || code == null) && (name == "" || name == null))
            {
                res = GetMajorGroup();
            }
            else if (name != "" && name != null)
            {
                res = GetMajorGroupByName(name);
            }
            else
            {
                res = GetMajorGroupByCode(code);
            }
            return res;
        }

        // GET: api/MajorGroup/5

        [Route("~/api/Menu/GetMajorGroup")]
        [HttpGet]
        public HttpResponseMessage GetMajorGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockDepartment obj = new BLL_StockDepartment();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMajorGroup();
            objList.TableName = "MajorGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        public HttpResponseMessage GetMajorGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockDepartment obj = new BLL_StockDepartment();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMajorGroupByCode(code);
            objList.TableName = "MajorGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        public HttpResponseMessage GetMajorGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockDepartment obj = new BLL_StockDepartment();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMajorGroupByName(name);
            objList.TableName = "MajorGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        // POST: api/MajorGroup
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_StockDepartment obj = new BLL_StockDepartment();
            List<BOL_StockDepartment> objList = new List<BOL_StockDepartment>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockDepartment>>(requestFromPost);//may raise exception because of the json string => format error
            string result = "";
            foreach (BOL_StockDepartment temp in objList)
            {
                result += obj.InsertMajorGroup(temp) + ";";
            }
                return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //private HttpResponseMessage InsertMenuMajorGroup()
        //{

        //    BLL_StockDepartment obj = new BLL_StockDepartment();
        //    List<BOL_StockDepartment> objList = new List<BOL_StockDepartment>();
        //    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
        //    reader.BaseStream.Position = 0;
        //    string requestFromPost = reader.ReadToEnd();
        //    objList = JsonConvert.DeserializeObject<List<BOL_StockDepartment>>(requestFromPost);//may raise exception because of the json string => format error
        //    string result = "";
        //    foreach (BOL_StockDepartment temp in objList)
        //    {
        //        result += obj.InsertMajorGroup(temp) + ";";
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, result);
        //}



        // PUT: api/MajorGroup/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/MajorGroup/5
        public void Delete(int id)
        {
        }
    }
}
