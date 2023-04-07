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
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMenuItem();
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
            BLL_Menu obj = new BLL_Menu();
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
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindFamilyGroupByName(name);
            objList.TableName = "FamilyGroup";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        // POST: api/FamilyGroup
        public void Post([FromBody]string value)
        {
        }

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
