using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Data;

using QSSAPI.BLL;
using QSSAPI.DAL;
namespace QSSAPI.Controllers
{
    [RoutePrefix("api")]
    public class SalesEnquiryDashboardController : ApiController
    {
        // GET: api/SalesEnquiryDashboard
        [Route("~/api/SalesEnquiryDashboard/Get")]
        [HttpGet]
        public HttpResponseMessage Get(string startdate, string enddate, string status)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((startdate == "" || startdate == null) && (enddate == "" || enddate == null) && (status == "" || status == null))
            {
                res = SaleEnquiryAll();
            }
            else if ((startdate != "" && startdate != null) && (enddate != "" && enddate != null))
            {
                res = SaleEnquiryByDate(startdate, enddate);
            }

            else
            {
                res = SaleEnquiryByDateAndStatus(startdate, enddate, status);
            }
            return res;
        }

        // GET: api/SalesEnquiryDashboard/5
        private HttpResponseMessage SaleEnquiryAll()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.SaleEnquiryAll();
            objList.TableName = "SalesEnquiry";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        private HttpResponseMessage SaleEnquiryByDate(string startdate, string enddate)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.SaleEnquiryByDate(startdate, enddate);
            objList.TableName = "SalesEnquiry";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        private HttpResponseMessage SaleEnquiryByDateAndStatus(string startdate, string enddate, string status)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.SaleEnquiryByDateAndStatus(startdate, enddate, status);
            objList.TableName = "SalesEnquiry";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST: api/SalesEnquiryDashboard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SalesEnquiryDashboard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalesEnquiryDashboard/5
        public void Delete(int id)
        {
        }
    }
}
