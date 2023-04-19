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
    public class TenderMediaController : ApiController
    {
        [HttpGet]
        [Route("~/api/TenderMedia/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllTenderMedia();
            }
            else if (name != "" && name != null)
            {
                res = GetTenderMediaByName(name);
            }
            else
            {
                res = GetTenderMediaByName(cond_code);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllTenderMedia()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_TenderMedia obj = new BLL_TenderMedia();
            DataTable objList = obj.BindTenderMedia();
            objList.TableName = "TenderMedia";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/TenderMedia/GetTenderMediaByCode")]
        private HttpResponseMessage GetTenderMediaByCode(string tenderMediaCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_TenderMedia obj = new BLL_TenderMedia();
            DataTable objList = obj.BindTenderMediaByCode(tenderMediaCode);
            objList.TableName = "TenderMedia";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/TenderMedia/GetTenderMediaByName")]
        private HttpResponseMessage GetTenderMediaByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_TenderMedia obj = new BLL_TenderMedia();
            DataTable objList = obj.BindTenderMediaByName(name);
            objList.TableName = "TenderMedia";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/TenderMedia
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_TenderMedia obj = new BLL_TenderMedia();
            List<BOL_TenderMedia> objList = new List<BOL_TenderMedia>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_TenderMedia>>(requestFromPost);
            string result = "";
            foreach (BOL_TenderMedia temp in objList)
            {
                result += obj.InserTenderMedia(temp) + ";";
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