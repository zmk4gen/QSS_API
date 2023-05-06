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
    public class UserInfoController : ApiController
    {
        [HttpGet]
        [Route("~/api/UserInfo/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllUserInfo();
            }
            else if (name != "" && name != null)
            {
                res = GetUserInfoByName(name);
            }
            else
            {
                res = GetUserInfoByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllUserInfo()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserInfo obj = new BLL_UserInfo();
            DataTable objList = obj.BindUserInfo();
            objList.TableName = "UserInfo";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/UserInfo/GetUserInfoByCode")]
        public HttpResponseMessage GetUserInfoByCode(string UserInfoCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserInfo obj = new BLL_UserInfo();
            DataTable objList = obj.BindUserInfoByCode(UserInfoCode);
            objList.TableName = "UserInfo";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/UserInfo/GetUserInfoByName")]
        public HttpResponseMessage GetUserInfoByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserInfo obj = new BLL_UserInfo();
            DataTable objList = obj.BindUserInfoByName(name);
            objList.TableName = "UserInfo";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/UserInfo
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_UserInfo obj = new BLL_UserInfo();
            List<BOL_UserInfo> objList = new List<BOL_UserInfo>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_UserInfo>>(requestFromPost);
            string result = "";
            foreach (BOL_UserInfo temp in objList)
            {
                result += obj.InserUserInfo(temp) + ";";
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