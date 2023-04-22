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
    public class StoreSubGroup_Controller : ApiController
    {
        [HttpGet]
        [Route("~/api/StoreSubGroup/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllStoreSubGroup();
            }
            else if (name != "" && name != null)
            {
                res = GetStoreSubGroupByName(name);
            }
            else
            {
                res = GetStoreSubGroupByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllStoreSubGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StoreSubGroup obj = new BLL_StoreSubGroup();
            DataTable objList = obj.BindStoreSubGroup();
            objList.TableName = "StoreSubGroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StoreSubGroup/GetStoreSubGroupByCode")]
        private HttpResponseMessage GetStoreSubGroupByCode(string StoreSubGroupCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StoreSubGroup obj = new BLL_StoreSubGroup();
            DataTable objList = obj.BindStoreSubGroupByCode(StoreSubGroupCode);
            objList.TableName = "StoreSubGroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StoreSubGroup/GetStoreSubGroupByName")]
        private HttpResponseMessage GetStoreSubGroupByName(string desc)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StoreSubGroup obj = new BLL_StoreSubGroup();
            DataTable objList = obj.BindStoreSubGroupByDesc(desc);
            objList.TableName = "StoreSubGroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
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