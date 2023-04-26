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
    public class LocationController : ApiController
    {
        [HttpGet]
        [Route("~/api/Location/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllLocation();
            }
            else if (name != "" && name != null)
            {
                res = GetLocationByName(name);
            }
            else
            {
                res = GetLocationByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllLocation()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Location obj = new BLL_Location();
            DataTable objList = obj.BindLocation();
            objList.TableName = "Location";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/Location/GetLocationByCode")]
        private HttpResponseMessage GetLocationByCode(string LocationCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Location obj = new BLL_Location();
            DataTable objList = obj.BindLocationByCode(LocationCode);
            objList.TableName = "Location";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/Location/GetLocationByName")]
        private HttpResponseMessage GetLocationByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Location obj = new BLL_Location();
            DataTable objList = obj.BindLocationByName(name);
            objList.TableName = "Location";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/Location
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_Location obj = new BLL_Location();
            List<BOL_Location> objList = new List<BOL_Location>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_Location>>(requestFromPost);
            string result = "";
            foreach (BOL_Location temp in objList)
            {
                result += obj.InserLocation(temp) + ";";
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