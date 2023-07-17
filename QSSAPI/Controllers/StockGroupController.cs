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
    public class StockGroupController : ApiController
    {
        [HttpGet]
        [Route("~/api/StockGroup/Get")]
        public HttpResponseMessage Get(string stockGroupcode = null, string name = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((stockGroupcode == "" || stockGroupcode == null) && (name == "" || name == null))
            {
                res = GetAllStockGroup();
            }
            else if (name != "" && name != null)
            {
                res = GetStockGroupByName(name);
            }
            else if (stockGroupcode != "" && stockGroupcode != null)
            {
                res = GetStockGroupByCode(stockGroupcode);
            }
            else
            {
                res = GetStockGroupByCodeANDName(stockGroupcode, name);
            }
            return res;
        }

        [HttpGet]
        public HttpResponseMessage GetAllStockGroup()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroup();
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StockGroup/GetStockGroupByCode")]
        public HttpResponseMessage GetStockGroupByCode(string code)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroupByCode(code);
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return res;
        }

        [HttpGet]
        [Route("~/api/StockGroup/GetStockGroupByName")]
        public HttpResponseMessage GetStockGroupByName(string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroupByName(name);
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        [HttpGet]
        [Route("~/api/StockGroup/GetStockGroupByCodeANDName")]
        public HttpResponseMessage GetStockGroupByCodeANDName(string code, string name)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_StockGroup obj = new BLL_StockGroup();
            DataTable objList = obj.BindStockGroupByCodeANDName(code,name);
            objList.TableName = "Stock_Group";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST api/StockGroup
        [HttpPost]
        [Route("~/api/StockGroup/InsertStockGroup")]
        public HttpResponseMessage Post()
        {
            BLL_StockGroup obj = new BLL_StockGroup();
            List<BOL_StockGroup> objList = new List<BOL_StockGroup>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPost = reader.ReadToEnd();
            objList = JsonConvert.DeserializeObject<List<BOL_StockGroup>>(requestFromPost);
            string result = "";
            foreach (BOL_StockGroup temp in objList)
            {
                result += obj.InsertStockGroup(temp) + ";";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT api/StockGroup
        [HttpPut]
        [Route("~/api/StockGroup/UpdateStockGroup")]
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            BLL_StockGroup obj = new BLL_StockGroup();
            BOL_StockGroup objStockGroup = new BOL_StockGroup();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            string requestFromPut = reader.ReadToEnd();
            objStockGroup = JsonConvert.DeserializeObject<BOL_StockGroup>(requestFromPut);
            string result = "";
            result = obj.UpdateStockGroup(objStockGroup) + ";";

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}