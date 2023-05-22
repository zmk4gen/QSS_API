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
    public class DashboardController : ApiController
    {
        // GET: api/SalesEnquiryDashboard
        //[Route("~/api/SalesEnquiryDashboard/Get")]
        //[HttpGet]
        //public HttpResponseMessage Get(string startdate, string enddate, string status)
        //{
        //    HttpResponseMessage res = new HttpResponseMessage();
        //    if ((startdate == "" || startdate == null) && (enddate == "" || enddate == null) && (status == "" || status == null))
        //    {
        //        res = SaleEnquiryAll();
        //    }
        //    else if ((startdate != "" && startdate != null) && (enddate != "" && enddate != null))
        //    {
        //        res = SaleEnquiryByDate(startdate, enddate);
        //    }

        //    else
        //    {
        //        res = SaleEnquiryByDateAndStatus(startdate, enddate, status);
        //    }
        //    return res;
        //}

        // GET: api/SalesEnquiryDashboard/5
        [Route("~/api/Dashboard/SaleEnquiryAll")]
        [HttpGet]
        public HttpResponseMessage SaleEnquiryAll(int branchid,string status)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.SaleEnquiryAll(branchid,status);
            objList.TableName = "SalesEnquiry";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        [Route("~/api/Dashboard/SaleEnquiryByDate")]
        [HttpGet]
        public HttpResponseMessage SaleEnquiryByDate(string startdate, string enddate)
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
        [Route("~/api/Dashboard/SaleEnquiryByDateAndStatus")]
        [HttpGet]
        public HttpResponseMessage SaleEnquiryByDateAndStatus(string startdate, string enddate, string status)
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

        [Route("~/api/Dashboard/SaleEnquiryByDateAndStatus")]
        [HttpGet]
        public HttpResponseMessage SaleSummaryReport_DeliveryAmt(string startdate, string enddate, int branchid = 0, int pcfrom = 0, int pcto = 0, int saletypefrom = 0, int saletypeto = 0)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.SaleSummaryReport_DeliveryAmt(startdate, enddate, branchid, pcfrom, pcto, saletypefrom, saletypeto);
            objList.TableName = "SalesEnquiry";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [Route("~/api/Dashboard/System_Sale_Report")]
        [HttpGet]
        public HttpResponseMessage System_Sale_Report(string startdate, string enddate, int branchid = 0,int saletypefrom = 0, int saletypeto = 0, bool isMajoir = false, bool isFamilyGroup = true,bool reportGroup=false)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.System_Sale_Report(startdate, enddate, branchid, saletypefrom, saletypeto, isMajoir, isFamilyGroup, reportGroup);
            objList.TableName = "SalesEnquiry";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        /// <summary>
        /// Payment Report
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="rvc"></param>
        /// <returns></returns>
        [Route("~/api/Dashboard/OCENTPaymentReport")]
        [HttpGet]
        public HttpResponseMessage OCENTPaymentReport(string startdate, string enddate, int rvc = 0)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.OCENTPaymentReport(startdate, enddate, rvc);
            objList.TableName = "OCENTPaymentReport";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        public HttpResponseMessage PaymentAll_API(string startdate, string enddate)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.PaymentAll_API(startdate, enddate);
            objList.TableName = "PaymentAll";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        public HttpResponseMessage PaymentByServingPeriod(string startdate, string enddate, string servingperiodfrom, string servingperiodto, int branchid)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Dashboard obj = new BLL_Dashboard();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.PaymentByServingPeriod(startdate, enddate, servingperiodfrom, servingperiodto, branchid);
            objList.TableName = "PaymentByServingPeriod";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

    }
}
