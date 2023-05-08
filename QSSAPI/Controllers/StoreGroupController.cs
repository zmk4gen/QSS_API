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
    public class StoreGroupController : ApiController
    {
        [HttpGet]
        [Route("~/api/StoreGroup/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllStoreGroup();
            }
            else if (name != "" && name != null)
            {
                res = GetStoreGroupByName(name);
            }
            else
            {
                res = GetStoreGroupByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllStoreGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StoreGroup obj = new BLL_StoreGroup();
            DataTable objList = obj.BindStoreGroup();
            objList.TableName = "StoreGroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StoreGroup/GetStoreGroupByCode")]
        private HttpResponseMessage GetStoreGroupByCode(string StoreGroupCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StoreGroup obj = new BLL_StoreGroup();
            DataTable objList = obj.BindStoreGroupByCode(StoreGroupCode);
            objList.TableName = "StoreGroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StoreGroup/GetStoreGroupByName")]
        private HttpResponseMessage GetStoreGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StoreGroup obj = new BLL_StoreGroup();
            DataTable objList = obj.BindStoreGroupByName(name);
            objList.TableName = "StoreGroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

       
        [Route("~/api/StoreGroup/InsertStoreGroup")]
        [HttpPost]
        // POST api/StoreGroup
        public HttpResponseMessage Post()
        {
            BLL_StoreGroup obj = new BLL_StoreGroup();
            List<BOL_StoreGroup> objList = new List<BOL_StoreGroup>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StoreGroup>>(requestFromPost);
            string result = "";
            foreach (BOL_StoreGroup temp in objList)
            {
                result += obj.InserStoreGroup(temp) + ";";
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