using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Data;
using QSSAPI.BLL;

namespace QSSAPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        [HttpGet]
        [Route("~/api/Login/Login")]
        public HttpResponseMessage Login(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_UserInfo obj = new BLL_UserInfo();
            DataTable objList = obj.BindUserInfo();
            objList.TableName = "UserInfo";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
            //  return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
