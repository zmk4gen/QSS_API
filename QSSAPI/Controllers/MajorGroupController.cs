using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

using QSSAPI.BLL;
using DAL;
using System.Net.Http.Headers;

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
        private HttpResponseMessage GetMajorGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMajorGroup();
            objList.TableName = "MajorGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        private HttpResponseMessage GetMajorGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMajorGroupByCode(code);
            objList.TableName = "MajorGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        private HttpResponseMessage GetMajorGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMajorGroupByName(name);
            objList.TableName = "MajorGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        // POST: api/MajorGroup
        public void Post([FromBody]string value)
        {
        }

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
