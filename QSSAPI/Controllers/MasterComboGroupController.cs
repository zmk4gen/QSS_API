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
    public class MasterComboGroupController : ApiController
    {
        [HttpGet]
        [Route("~/api/MasterComboGroup/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllMasterComboGroup();
            }
            else if (name != "" && name != null)
            {
                res = GetMasterComboGroupByName(name);
            }
            else
            {
                res = GetMasterComboGroupByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllMasterComboGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_MasterComboGroup obj = new BLL_MasterComboGroup();
            DataTable objList = obj.BindMasterComboGroup();
            objList.TableName = "mstr_combogroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/MasterComboGroup/GetMasterComboGroupByCode")]
        public HttpResponseMessage GetMasterComboGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_MasterComboGroup obj = new BLL_MasterComboGroup();
            DataTable objList = obj.BindMasterComboGroupByCode(code);
            objList.TableName = "mstr_combogroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/MasterComboGroup/GetMasterComboGroupByName")]
        public HttpResponseMessage GetMasterComboGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_MasterComboGroup obj = new BLL_MasterComboGroup();
            DataTable objList = obj.BindMasterComboGroupByName(name);
            objList.TableName = "mstr_combogroup";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/MasterComboGroup
        [HttpPost]
        [Route("~/api/MasterComboGroup/InsertMasterComboGroup")]
        public HttpResponseMessage Post()
        {
            BLL_MasterComboGroup obj = new BLL_MasterComboGroup();
            List<BOL_Master_Combogroup> objList = new List<BOL_Master_Combogroup>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_Master_Combogroup>>(requestFromPost);
            string result = "";
            
            var branch_id = HelperClass.Get_BranchID();
             
            foreach (BOL_Master_Combogroup temp in objList)
            {
                temp.cbo_branchid = branch_id;
                result += obj.InserMasterComboGroup(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            BLL_MasterComboGroup obj = new BLL_MasterComboGroup();
            BOL_Master_Combogroup objMaster_Combogroup = new BOL_Master_Combogroup();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPut = reader.ReadToEnd();
            objMaster_Combogroup = JsonConvert.DeserializeObject<BOL_Master_Combogroup>(requestFromPut);
            string result = "";
            result = obj.UpdateMasterComboGroup(objMaster_Combogroup) + ";";

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}