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
    public class mstr_sluController : ApiController
    {
        [HttpGet]
        [Route("~/api/MasterSlu/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllmstr_slu();
            }
            else if (name != "" && name != null)
            {
                res = GetMasterSluByName(name);
            }
            else
            {
                res = GetMasterSluByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllmstr_slu()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_mstr_slu obj = new BLL_mstr_slu();
            DataTable objList = obj.Bind_mstr_slu();
            objList.TableName = "mstr_slu";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/MasterSlu/GetMasterSluByCode")]
        private HttpResponseMessage GetMasterSluByCode(string sluCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_mstr_slu obj = new BLL_mstr_slu();
            DataTable objList = obj.Bind_mstr_sluByCode(sluCode);
            objList.TableName = "mstr_slu";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/MasterSlu/GetMasterSluByName")]
        private HttpResponseMessage GetMasterSluByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_mstr_slu obj = new BLL_mstr_slu ();
            DataTable objList = obj.Bind_mstr_sluByName(name);
            objList.TableName = "mstr_slu";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/Condiment
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_mstr_slu obj = new BLL_mstr_slu();
            List<BOL_mstr_slu> objList = new List<BOL_mstr_slu>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_mstr_slu>>(requestFromPost);
            string result = "";
            foreach (BOL_mstr_slu temp in objList)
            {
                result += obj.Insert_mstr_slu(temp) + ";";
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