﻿using System;
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
    public class CondimentController : ApiController
    {
        [HttpGet]
        [Route("~/api/Condiment/Get")]
        public HttpResponseMessage Get(string cond_code = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((cond_code == "" || cond_code == null) && (name == "" || name == null))
            {
                res = GetAllCondiment();
            }
            else if (name != "" && name != null)
            {
                res = GetCondimentByName(name);
            }
            else
            {
                res = GetCondimentByCode(cond_code);
            }
            return res;
        }

        [HttpGet]
        private HttpResponseMessage GetAllCondiment()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Condiment obj = new BLL_Condiment();
            DataTable objList = obj.BindCondiment();
            objList.TableName = "Condiment";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/Condiment/GetCondimentByCode")]
        private HttpResponseMessage GetCondimentByCode(string condimentCode)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Condiment obj = new BLL_Condiment();
            DataTable objList = obj.BindCondimentByCode(condimentCode);
            objList.TableName = "Condiment";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/Condiment/GetCondimentByName")]
        private HttpResponseMessage GetCondimentByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Condiment obj = new BLL_Condiment();
            DataTable objList = obj.BindCondimentByName(name);
            objList.TableName = "Condiment";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/Condiment
        public HttpResponseMessage Post([FromBody]string value)
        {
            BLL_Condiment obj = new BLL_Condiment();
            List<BOL_Condiment> objList = new List<BOL_Condiment>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_Condiment>>(requestFromPost);
            string result = "";
            foreach (BOL_Condiment temp in objList)
            {
                result += obj.InserCondiment(temp) + ";";
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