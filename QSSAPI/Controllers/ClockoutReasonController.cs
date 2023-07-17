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
    public class ClockoutReasonController : ApiController
    {
        [HttpGet]
        [Route("~/api/ClockoutReason/Get")]
        public HttpResponseMessage Get(string code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((code == "" || code == null) && (name == "" || name == null))
            {
                res = GetAllClockoutReason();
            }
            else if (name != "" && name != null)
            {
                res = GetClockoutReasonByName(name);
            }
            else if (code != "" && code != null)
            {
                res = GetClockoutReasonByCode(code);
            }
            else
            {
                res = GetClockoutReasonByCodeANDName(code, name);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllClockoutReason()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_ClockoutReason obj = new BLL_ClockoutReason();
            DataTable objList = obj.BindClockoutReason();
            objList.TableName = "ClockoutReason";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/ClockoutReason/GetClockoutReasonByCode")]
        public HttpResponseMessage GetClockoutReasonByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_ClockoutReason obj = new BLL_ClockoutReason();
            DataTable objList = obj.BindClockoutReasonByCode(code);
            objList.TableName = "ClockoutReason";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/ClockoutReason/GetClockoutReasonByName")]
        public HttpResponseMessage GetClockoutReasonByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_ClockoutReason obj = new BLL_ClockoutReason();
            DataTable objList = obj.BindClockoutReasonByName(name);
            objList.TableName = "ClockoutReason";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        [Route("~/api/ClockoutReason/GetClockoutReasonByCodeANDName")]
        public HttpResponseMessage GetClockoutReasonByCodeANDName(string code, string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_ClockoutReason obj = new BLL_ClockoutReason();
            DataTable objList = obj.BindClockoutReasonByCodeANDName(code, name);
            objList.TableName = "ClockoutReason";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/ClockoutReason
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_ClockoutReason obj = new BLL_ClockoutReason();
            List<BOL_ClockoutReason> objList = new List<BOL_ClockoutReason>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_ClockoutReason>>(requestFromPost);
            string result = "";
            foreach (BOL_ClockoutReason temp in objList)
            {
                result += obj.InserClockoutReason(temp) + ";";
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