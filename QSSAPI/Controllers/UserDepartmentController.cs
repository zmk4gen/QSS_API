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
    public class UserDepartmentController : ApiController
    {
        [HttpGet]
        [Route("~/api/UserDepartment/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllUserDepartment();
            }
            else if (name != "" && name != null)
            {
                res = GetUserDepartmentByName(name);
            }
            else
            {
                res = GetUserDepartmentByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllUserDepartment()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserDepartment obj = new BLL_UserDepartment();
            DataTable objList = obj.BindUserDepartment();
            objList.TableName = "UserDepartment";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/UserDepartment/GetUserDepartmentByCode")]
        public HttpResponseMessage GetUserDepartmentByCode(string UserDepartmentCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserDepartment obj = new BLL_UserDepartment();
            DataTable objList = obj.BindUserDepartmentByCode(UserDepartmentCode);
            objList.TableName = "UserDepartment";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/UserDepartment/GetUserDepartmentByName")]
        public HttpResponseMessage GetUserDepartmentByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserDepartment obj = new BLL_UserDepartment();
            DataTable objList = obj.BindUserDepartmentByName(name);
            objList.TableName = "UserDepartment";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/UserDepartment
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_UserDepartment obj = new BLL_UserDepartment();
            List<BOL_UserDepartment> objList = new List<BOL_UserDepartment>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_UserDepartment>>(requestFromPost);
            string result = "";
            foreach (BOL_UserDepartment temp in objList)
            {
                result += obj.InserUserDepartment(temp) + ";";
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