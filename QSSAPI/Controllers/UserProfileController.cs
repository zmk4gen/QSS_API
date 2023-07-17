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
    public class UserProfileController : ApiController
    {
        [HttpGet]
        [Route("~/api/UserProfile/Get")]
        public HttpResponseMessage Get(string code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((code == "" || code == null) && (name == "" || name == null))
            {
                res = GetAllUserProfile();
            }
            else if (name != "" && name != null)
            {
                res = GetUserProfileByName(name);
            }
            else if (code != "" && code != null)
            {
                res = GetUserProfileByCode(code);
            }
            else
            {
                res = GetUserProfileByCodeANDName(code,name);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllUserProfile()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserProfile obj = new BLL_UserProfile();
            DataTable objList = obj.BindUserProfile();
            objList.TableName = "UserProfile";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/UserProfile/GetUserProfileByCode")]
        public HttpResponseMessage GetUserProfileByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserProfile obj = new BLL_UserProfile();
            DataTable objList = obj.BindUserProfileByCode(code);
            objList.TableName = "UserProfile";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/UserProfile/GetUserProfileByName")]
        public HttpResponseMessage GetUserProfileByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserProfile obj = new BLL_UserProfile();
            DataTable objList = obj.BindUserProfileByName(name);
            objList.TableName = "UserProfile";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        [Route("~/api/UserProfile/GetUserProfileByCodeANDName")]
        public HttpResponseMessage GetUserProfileByCodeANDName(string code, string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserProfile obj = new BLL_UserProfile();
            DataTable objList = obj.BindUserProfileByCodeANDName(code, name);
            objList.TableName = "UserProfile";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/UserProfile
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_UserProfile obj = new BLL_UserProfile();
            List<BOL_UserProfile> objList = new List<BOL_UserProfile>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_UserProfile>>(requestFromPost);
            string result = "";
            foreach (BOL_UserProfile temp in objList)
            {
                result += obj.InserUserProfile(temp) + ";";
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