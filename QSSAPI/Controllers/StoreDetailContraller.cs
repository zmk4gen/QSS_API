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
    public class StoreDetailContraller
    {
        [RoutePrefix("api")]
        public class StoreDetailController : ApiController
        {
            [HttpGet]
            [Route("~/api/StoreDetail/Get")]
            public HttpResponseMessage Get(string br_Code = null, string name = null)
            {
                HttpResponseMessage res = new HttpResponseMessage();
                if ((br_Code == "" || br_Code == null) && (name == "" || name == null))
                {
                    res = GetAllStoreDetail();
                }
                else if (name != "" && name != null)
                {
                    res = GetStoreDetailByName(name);
                }
                else
                {
                    res = GetStoreDetailByCode(br_Code);
                }
                return res;
            }

            [HttpGet]
            public HttpResponseMessage GetAllStoreDetail()
            {
                HttpResponseMessage res = new HttpResponseMessage();
                BLL_StoreDetail obj = new BLL_StoreDetail();
                DataTable objList = obj.BindStoreDeteail();
                objList.TableName = "StoreDetail";

                res = Request.CreateResponse(HttpStatusCode.OK, objList);
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return res;
            }

            [HttpGet]
            [Route("~/api/StoreDetail/GetStoreDetailByCode")]
            public HttpResponseMessage GetStoreDetailByCode(string code)
            {
                HttpResponseMessage res = new HttpResponseMessage();
                BLL_StoreDetail obj = new BLL_StoreDetail();
                DataTable objList = obj.BindStoreDetailByCode(code);
                objList.TableName = "StoreDetail";

                res = Request.CreateResponse(HttpStatusCode.OK, objList);
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return res;
            }

            [HttpGet]
            [Route("~/api/StoreDetail/GetStoreDetailByName")]
            public HttpResponseMessage GetStoreDetailByName(string name)
            {
                HttpResponseMessage res = new HttpResponseMessage();
                BLL_StoreDetail obj = new BLL_StoreDetail();
                DataTable objList = obj.BindStoreDetailByName(name);
                objList.TableName = "StoreDetail";

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
}