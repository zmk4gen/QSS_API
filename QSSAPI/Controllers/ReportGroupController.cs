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
    public class ReportGroupController : ApiController
    {
        // GET: api/ReportGroup
        public HttpResponseMessage Get(string code = "", string Desc = "")
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if (code == "" && Desc == "")
            {
                res = GetAllReportGroup();
            }
            else if (Desc != "")
            {
                res = ReportGroupByDesc(Desc);
            }
            else
            {
                res = ReportGroupByCode(code);
            }
            return res;
        }

        // GET: api/FamilyGroup
        [HttpGet]
        private HttpResponseMessage GetAllReportGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindReportGroup();
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        private HttpResponseMessage ReportGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindFamilyGroupByCode(code);
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        [HttpGet]
        private HttpResponseMessage ReportGroupByDesc(string Desc)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindFamilyGroupByName(Desc);
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST: api/ReportGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReportGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReportGroup/5
        public void Delete(int id)
        {
        }
    }
}
