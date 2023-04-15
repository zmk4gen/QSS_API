using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
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
    
    public class MenuController : ApiController
    {
        // GET: api/Menu
        [Route("~/api/Menu/Get")]
        [HttpGet]
        public HttpResponseMessage Get(string stockno = null, string Desc = null)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            if ((stockno == "" || stockno ==null) && (Desc == ""|| Desc==null ))
            {
                res = GetAllMenuItem();
            }
            else if (Desc != "" && Desc !=null)
            {
                res = GetMenuItemByDesc(Desc);
            }
            else
            {
                res = GetMenuItemByStockNo(stockno);
            }
            return res;
        }
        [HttpGet]
        private HttpResponseMessage GetAllMenuItem()
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.BindMenuItem_List();
            DataTable objList = obj.BindMenuItem();
            objList.TableName = "MenuItem";
            //String message = "success";
            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        [HttpGet]
        [Route("~/api/Menu/GetMenuItemByID")]
        private HttpResponseMessage GetMenuItemByStockNo(string stockno)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.SelectByMenuItem_List(Helper.ConvertInteger(ID));
            DataTable objList = obj.SelectbyMenuItem(stockno);
            objList.TableName = "MenuItem";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }
        [Route("~/api/Menu/GetMenuItemByDesc")]
        [HttpGet]
        private HttpResponseMessage GetMenuItemByDesc(string Desc)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            BLL_Menu obj = new BLL_Menu();
            //List<BOLMenuItem> objList = obj.SearchByMenuItem_List(Desc);
            DataTable objList = obj.SearchByMenuItem(Desc);
            objList.TableName = "MenuItem";

            res = Request.CreateResponse(HttpStatusCode.OK, objList);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return res;
        }

        // POST: api/Menu
        public HttpResponseMessage Post()
        {

            BLL_Menu obj = new BLL_Menu();
            List<BOL_stock> objList = new List<BOL_stock>();
            StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            reader.BaseStream.Position = 0;
            
            string requestFromPost = reader.ReadToEnd();

            var format = "dd/MM/yyyy"; // your datetime format
            var dateTimeConverter = new Helper() ;



            objList = JsonConvert.DeserializeObject<List<BOL_stock>>(requestFromPost);//may raise exception because of the json string => format error

            string result = "";
            foreach (BOL_stock temp in objList)
            {
                result += obj.InsertMenuItem(temp) + ";";

            }

            if (result != null)
            {

            }


            return Request.CreateResponse(result);
        }

        // PUT: api/Menu/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
        }
    }
}
