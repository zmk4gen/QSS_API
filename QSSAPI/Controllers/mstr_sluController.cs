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
using QSSAPI.Helpers;

namespace QSSAPI.Controllers
{
    [RoutePrefix("api")]
    public class mstr_sluController : ApiController
    {
        [HttpGet]
        [Route("~/api/MasterSlu/Get")]
        public HttpResponseMessage Get(string slu_number = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((slu_number == "" || slu_number == null) && (name == "" || name == null))
            {
                res = GetAllmstr_slu();
            }
            else if (name != "" && name != null)
            {
                res = GetMasterSluByName(name);
            }
            else if (slu_number != "" && slu_number != null)
            {
                res = GetMasterSluByCode(slu_number);
            }
            else
            {
                res = GetMasterSluByCodeANDName(slu_number,name);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllmstr_slu()
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
        public HttpResponseMessage GetMasterSluByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_mstr_slu obj = new BLL_mstr_slu();
            DataTable objList = obj.Bind_mstr_sluByCode(code);
            objList.TableName = "mstr_slu";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/MasterSlu/GetMasterSluByName")]
        public HttpResponseMessage GetMasterSluByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_mstr_slu obj = new BLL_mstr_slu ();
            DataTable objList = obj.Bind_mstr_sluByName(name);
            objList.TableName = "mstr_slu";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        [Route("~/api/MasterSlu/GetMasterSluByCodeANDName")]
        public HttpResponseMessage GetMasterSluByCodeANDName(string code,string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_mstr_slu obj = new BLL_mstr_slu();
            DataTable objList = obj.Bind_mstr_sluByCodeANDName(code,name);
            objList.TableName = "mstr_slu";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpPost]
        [Route("~/api/MasterSlu/InsertMasterSlu")]
        public HttpResponseMessage Post()
        {
            BLL_mstr_slu obj = new BLL_mstr_slu();
            List<BOL_mstr_slu> objList = new List<BOL_mstr_slu>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_mstr_slu>>(requestFromPost);
            string result = "";
            var branch_id = HelperClass.Get_BranchID();
            foreach (BOL_mstr_slu temp in objList)
            {
                temp.slu_branchid = branch_id;
                result += obj.Insert_mstr_slu(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            BLL_mstr_slu obj = new BLL_mstr_slu();
            BOL_mstr_slu objmstr_slu = new BOL_mstr_slu();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPut = reader.ReadToEnd();
            objmstr_slu = JsonConvert.DeserializeObject<BOL_mstr_slu>(requestFromPut);
            string result = "";
            result = obj.Update_mstr_slu(objmstr_slu) + ";";

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }

    }
}