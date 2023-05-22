using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using QSSAPI.Helpers;
using QSSAPI.BOL;
using QSSAPI.BLL;

using System.Configuration;

namespace QSSAPI.Controllers
{
    public class SalesOrderController : ApiController
    {
        Generic gl_Generic;
        int last_sd_id_for_discount = 0;
        int combo_parent_id = 0;
        // GET: api/SalesOrder
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // GET: api/SalesOrder/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SalesOrder
        [Route("~/api/SalesOrder/Order")]
        [HttpPost]
        public HttpResponseMessage Post(string remoteId, string order, string branch, string rvc, string deliverychannel, string salestype)
        {
            HttpResponseMessage res = new HttpResponseMessage();

            BOL_ResponseToThirdParty lc_obj_response_to_thirdparty = new BOL_ResponseToThirdParty();

            HttpStatusCode http_statuscode = new HttpStatusCode();

            string message = "";


            int lc_int_order_raw_data_id = 0, lc_int_result = 0;
            try
            {

                //remoteId = remoteId.Replace('%', ' ');

                HelperClass.WriteLog("remoteID:" + remoteId + "::branch:" + branch);

                HelperClass.DB_Conn = ConfigurationManager.AppSettings["SQLConn"].ToString();
                gl_Generic = new Generic();

                Retrieve_RVCInfo();
                Retrieve_BranchInfo();
                Bind_Sale_Type_and_Service_charge(salestype);


                if (gl_Generic.gl_str_Branch_Code != branch)
                {
                    http_statuscode = HttpStatusCode.InternalServerError;
                    lc_obj_response_to_thirdparty.reason = "Data forwarded to wrong branch!";
                    goto skiphere;
                }



                BLL_Order_Raw_Data bll_order_raw = new BLL_Order_Raw_Data();
                //List<BOL_Order_Raw_Data> objList_order_raw = new List<BOL_Order_Raw_Data>();

                StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
                reader.BaseStream.Position = 0;
                string str_raw_data = reader.ReadToEnd();


                HttpHeaders headers = Request.Headers;
                res.Headers.Date = DateTime.Now;

                HelperClass.Write_Payload_Log(str_raw_data, DateTime.Now.ToString("yyyyMMdd") + "_Payload_Log", DateTime.Now.ToString("yyyyMMdd") + "_" + remoteId + "_" + order);

                if (str_raw_data != "")
                {
                    gl_Generic.gl_str_uid = getUIDNo();
                    gl_Generic.gl_str_checkno = order; //inserting order number from DeliveryHero as check no //getCheckno(gl_Generic.gl_int_RVC_ID.ToString());

                    HelperClass.DB_Conn = ConfigurationManager.AppSettings["SQLConn_OrderDB"].ToString();

                    //message = bll_order_raw.Insert_Order_Raw_Data(obj_bol);
                    BOL_Order_Raw_Data obj_bol = new BOL_Order_Raw_Data();
                    obj_bol.ord_RVCID = gl_Generic.gl_int_RVC_ID.ToString();
                    obj_bol.ord_RVCName = gl_Generic.gl_str_RVC_Desc;
                    obj_bol.ord_BranchCode = gl_Generic.gl_str_Branch_Code;
                    obj_bol.ord_BranchName = gl_Generic.gl_str_Branch_Name;
                    obj_bol.ord_DeliveryTypeCode = deliverychannel;
                    obj_bol.ord_DeliveryTypeDesc = gl_Generic.gl_str_TransType_Desc;
                    obj_bol.ord_uid = gl_Generic.gl_str_uid;
                    obj_bol.ord_RawData = str_raw_data;


                    message = bll_order_raw.Insert_Order_Raw_Data(obj_bol, out lc_int_order_raw_data_id);

                    HelperClass.DB_Conn = ConfigurationManager.AppSettings["SQLConn"].ToString();

                    BOL_Order_Object bol_order = JsonConvert.DeserializeObject<BOL_Order_Object>(str_raw_data);
                    TranslateToPOSDB(bol_order); //do transaction insert here


                    HelperClass.DB_Conn = ConfigurationManager.AppSettings["SQLConn_OrderDB"].ToString();

                    BOL_Order_Notification bol_order_noti = new BOL_Order_Notification();
                    bol_order_noti.ordernoti_OrderRawDataID = lc_int_order_raw_data_id.ToString();
                    bol_order_noti.ordernoti_uid = gl_Generic.gl_str_uid;
                    bol_order_noti.ordernoti_DeliveryTypeCode = deliverychannel;

                    BLL_Order_Notification bll_order_noti = new BLL_Order_Notification();
                    lc_int_result = bll_order_noti.Insert_Order_Notification(bol_order_noti);

                    if (String.IsNullOrWhiteSpace(gl_Generic.gl_str_uid))
                    {
                        http_statuscode = HttpStatusCode.InternalServerError;
                        lc_obj_response_to_thirdparty.reason = "Could not translate order to POS";
                        HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, UIDError details: uid was not generated!:End Batch///");

                        goto skiphere;
                    }
                    else
                    {
                        lc_obj_response_to_thirdparty.remoteResponse = new BOL_RemoteOrder();
                        lc_obj_response_to_thirdparty.remoteResponse.remoteOrderId = gl_Generic.gl_str_uid;
                        http_statuscode = HttpStatusCode.Accepted;
                    }

                }
                else
                {
                    http_statuscode = HttpStatusCode.BadRequest;
                    lc_obj_response_to_thirdparty.reason = "Content not found in Payload";
                    HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, PayloadError details: Content not found in Payload!:End Batch///");

                }

            }
            catch (HttpException ex)
            {
                http_statuscode = HttpStatusCode.InternalServerError;//(HttpStatusCode)ex.GetHttpCode();
                lc_obj_response_to_thirdparty.reason = "Error dispatching order";

                HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, HttpError details: " + ex.Message + " :End Batch///");
                if (ex.InnerException != null)
                    HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, HttpError details: " + ex.InnerException.InnerException + " :End Batch///");
                else
                    HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, HttpError details: " + ex.Message + " :End Batch///");
            }
            catch (Exception ex)
            {
                http_statuscode = HttpStatusCode.InternalServerError;
                lc_obj_response_to_thirdparty.reason = "Error dispatching order";

                HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, Error details: " + ex.Message + " :End Batch///");
                if (ex.InnerException != null)
                    HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, Error details: " + ex.InnerException.InnerException + " :End Batch///");
                else
                    HelperClass.WriteLog("///Start Batch: " + HelperClass.FuncGetDateTime("yyyyMMddHHmmss") + ", POST, Error details: " + ex.Message + " :End Batch///");

            }


        skiphere:
            message = JsonConvert.SerializeObject(lc_obj_response_to_thirdparty, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            res = Request.CreateResponse(http_statuscode);
            res.Content = new StringContent(message, System.Text.Encoding.UTF8, "application/json");

            return res;
        }


        private void TranslateToPOSDB(BOL_Order_Object bol_order)
        {

            #region Hide for a while
            //= JsonConvert.DeserializeObject<BOL_Order_Object>(HelperClass.StringTest());
            BLL_Generic bll_generic = new BLL_Generic();
            BLL_GetMenu bll_getmenu = new BLL_GetMenu();

            List<Product> main_product = new List<Product>();
            main_product = bol_order.products;

            HelperClass.DB_Conn = ConfigurationManager.AppSettings["SQLConn"].ToString();

            int lc_int_packageparentid = 0;
            int result = 0;
            bool lc_bool_discount_include = false;
            gl_Generic.gl_str_expeditionType = bol_order.expeditionType;

            if (bol_order.discounts != null && bol_order.discounts.Count > 0)
            {
                Discount order_discount = new Discount();
                gl_Generic.gl_discount = new BOL_Discount();


                if (bol_order.discounts.Count > 0)
                {
                    foreach (Discount discount in bol_order.discounts)
                    {
                        order_discount = discount;
                    }

                    lc_bool_discount_include = true;

                    gl_Generic.gl_discount = bll_generic.Get_Discount_By_Name(order_discount.name);
                    gl_Generic.gl_discount.str_disctype = "SubTotal Discount";
                    gl_Generic.gl_discount.is_item_discount = false;
                    gl_Generic.gl_discount.is_autoservicecharge = false;

                    if (gl_Generic.gl_discount.disc_typedef.Contains("disc_3;;"))
                    {
                        gl_Generic.gl_discount.is_item_discount = true;
                        gl_Generic.gl_discount.str_disctype = "Item Discount";
                    }
                    if (gl_Generic.gl_discount.disc_typedef.Contains("disc_2;;")) //check if On-Percentage  Off-Amount
                    {
                        gl_Generic.gl_discount.is_percentage = true;
                    }

                    if (gl_Generic.gl_discount.disc_typedef.Contains("disc_6;;")) //check if auto service charge
                    {
                        gl_Generic.gl_discount.is_autoservicecharge = true;
                    }
                }

            }

            string str_for_combo_or_condi = "", str_for_combopatternqty = "";

            foreach (Product temp_product in main_product)
            {
                str_for_combo_or_condi = "";
                str_for_combopatternqty = "";

                lc_int_packageparentid = Insert_Sales_Details(temp_product.remoteCode, HelperClass.ConvertInteger(temp_product.quantity), temp_product.unitPrice, "0", 0, 0, 0, 0, 0);
                combo_parent_id = lc_int_packageparentid;

                if (temp_product.selectedToppings != null && temp_product.selectedToppings.Count > 0) //combogroup or condiment group start 'com-1234' || 'con-1234'
                {
                    List<SelectedTopping> sc_list_selectedToppings = temp_product.selectedToppings;

                    foreach (SelectedTopping temp_selectedToppings in sc_list_selectedToppings)
                    {
                        int sc_int_iscondi = 0;

                        if (bll_getmenu.Get_Stock_Description2_For_MenuFlow(temp_selectedToppings.remoteCode).Contains("com"))
                        {
                            str_for_combo_or_condi = "combo";
                        }

                        else if (bll_getmenu.Get_Stock_Description2_For_MenuFlow(temp_selectedToppings.remoteCode).Contains("condr"))
                        {
                            str_for_combo_or_condi = "condr";
                            sc_int_iscondi = 1;
                        }

                        else if (bll_getmenu.Get_Stock_Description2_For_MenuFlow(temp_selectedToppings.remoteCode).Contains("conda"))
                        {
                            str_for_combo_or_condi = "conda";
                            sc_int_iscondi = 1;
                        }
                        ///////////////////////

                        //if (temp_selectedToppings.remoteCode.Contains("con-"))
                        //{
                        //    str_for_combo_or_condi = "condi";
                        //    sc_int_iscondi = 1;
                        //}
                        //if (temp_selectedToppings.remoteCode.Contains("com-"))
                        //{
                        //    str_for_combo_or_condi = "combo";
                        //}

                        if (temp_selectedToppings.children != null)
                        {

                            Extract_Child(temp_selectedToppings, lc_int_packageparentid, sc_int_iscondi, combo_parent_id, str_for_combo_or_condi);
                        }


                    }


                }

                if (str_for_combo_or_condi != "")
                {
                    str_for_combopatternqty = bll_generic.Get_ComboPatternQty(temp_product.remoteCode, str_for_combo_or_condi);

                    result = bll_generic.Update_Sales_Details_ComboPatternQty(lc_int_packageparentid, gl_Generic.gl_str_uid, str_for_combopatternqty);
                }
            }

            bll_generic.Update_SalesDetails_Discount_For_DisplayAfter_sdID(last_sd_id_for_discount, gl_Generic.gl_str_uid);

            Insert_Sales(bol_order.token, bol_order.code);

            if (bol_order.delivery != null)
            {
                Insert_Delivery_Info(bol_order.delivery, bol_order.customer);
            }

            #endregion Hide for a while

        }

        private void Insert_Delivery_Info(Delivery prm_del_info, Customer prm_cus_info)
        {
            BOL_Delivery_Info bol_del_info = new BOL_Delivery_Info();

            bol_del_info.delinfo_uid = gl_Generic.gl_str_uid;
            bol_del_info.delinfo_email = prm_cus_info.email;
            bol_del_info.delinfo_firstName = prm_cus_info.firstName;
            bol_del_info.delinfo_lastName = prm_cus_info.lastName;
            bol_del_info.delinfo_mobilePhone = prm_cus_info.mobilePhone;
            bol_del_info.delinfo_postcode = prm_del_info.address.postcode;
            bol_del_info.delinfo_city = prm_del_info.address.city;
            bol_del_info.delinfo_street = prm_del_info.address.street;
            bol_del_info.delinfo_number = prm_del_info.address.number;
            bol_del_info.delinfo_expectedDeliveryTime = prm_del_info.expectedDeliveryTime;
            bol_del_info.delinfo_expressDelivery = prm_del_info.expressDelivery;
            bol_del_info.delinfo_riderPickUpTime = prm_del_info.riderPickupTime;

            BLL_Delivery_Info bll_del_info = new BLL_Delivery_Info();
            int result = bll_del_info.Insert_Delivery_Info(bol_del_info);
        }
        /// <summary>
        /// Insert Sales Detail
        /// </summary>
        /// <param name="prm_Children"></param>
        /// <param name="packageparentid"></param>
        /// <param name="sc_int_iscondi"></param>
        /// <param name="prm_comboparentid"></param>
        /// <param name="menulevel"></param>
        private void Extract_Child(SelectedTopping prm_Children, int packageparentid, int sc_int_iscondi = 0, int prm_comboparentid = 0, string menulevel = "")
        {
            int lc_int_inserted_sd_ID = 0, result = 0;
            string str_for_combopatternqty = "";
            BLL_Generic bll_gen = new BLL_Generic();

            lc_int_inserted_sd_ID = Insert_Sales_Details(prm_Children.remoteCode, prm_Children.quantity, prm_Children.price, "0", packageparentid, 0, 0, sc_int_iscondi, prm_comboparentid);

            //list_menu_flow.Add(temp_Child.name);

            str_for_combopatternqty = bll_gen.Get_ComboPatternQty(prm_Children.remoteCode, menulevel);
            if (str_for_combopatternqty != "")
                result = bll_gen.Update_Sales_Details_ComboPatternQty(lc_int_inserted_sd_ID, gl_Generic.gl_str_uid, str_for_combopatternqty);
        }

        private void Extract_Child_Old(List<Child> prm_Children, int packageparentid, int sc_int_iscondi = 0, int prm_comboparentid = 0)
        {
            int lc_int_inserted_sd_ID = 0, result = 0;
            string str_for_combopatternqty = "";
            BLL_Generic bll_gen = new BLL_Generic();

            foreach (Child temp_Child in prm_Children)
            {
                if (!(temp_Child.remoteCode.Contains("com-") || temp_Child.remoteCode.Contains("con-")))
                {
                    lc_int_inserted_sd_ID = Insert_Sales_Details(temp_Child.remoteCode, temp_Child.quantity, temp_Child.price, "0", packageparentid, 0, 0, sc_int_iscondi, prm_comboparentid);

                }
                else
                    lc_int_inserted_sd_ID = packageparentid;

                //list_menu_flow.Add(temp_Child.name);

                str_for_combopatternqty = bll_gen.Get_ComboPatternQty(temp_Child.remoteCode, "condi");
                if (str_for_combopatternqty != "")
                    result = bll_gen.Update_Sales_Details_ComboPatternQty(lc_int_inserted_sd_ID, gl_Generic.gl_str_uid, str_for_combopatternqty);


                if (temp_Child.children != null)
                {
                    if (temp_Child.remoteCode.Contains("con-"))
                    {
                        sc_int_iscondi = 1;
                        prm_comboparentid = combo_parent_id;
                    }
                    else
                        sc_int_iscondi = 0;

                    Extract_Child_Old(temp_Child.children, lc_int_inserted_sd_ID, sc_int_iscondi, prm_comboparentid);
                }
            }
        }

        private void Retrieve_RVCInfo()
        {
            BLL_Generic bll = new BLL_Generic();
            DataTable dt = bll.Get_mstr_RVC();

            if (dt.Rows.Count > 0)
            {
                gl_Generic.gl_int_RVC_ID = HelperClass.ConvertInteger(dt.Rows[0]["rvc_id"].ToString());
                gl_Generic.gl_str_RVC_Desc = dt.Rows[0]["rvc_name1"].ToString();
                gl_Generic.gl_str_RVC_TypeDef = dt.Rows[0]["rvc_typedef"].ToString();
            }
        }
        private void Retrieve_BranchInfo()
        {
            BLL_Generic bll = new BLL_Generic();
            DataTable dt = bll.Get_master_branch();

            if (dt.Rows.Count > 0)
            {
                gl_Generic.gl_int_Branch_ID = HelperClass.ConvertInteger(dt.Rows[0]["br_ID"].ToString());
                gl_Generic.gl_str_Branch_Code = dt.Rows[0]["br_Code"].ToString();
                gl_Generic.gl_str_Branch_Name = dt.Rows[0]["br_Name"].ToString();

                gl_Generic.gl_date_BusinessDate = HelperClass.ConvertDateTime(dt.Rows[0]["mb_dayend"].ToString());
                gl_Generic.gl_str_Branch_TypeDef = dt.Rows[0]["br_typedef"].ToString();
                gl_Generic.gl_str_Branch_RoundingDue = dt.Rows[0]["br_Code"].ToString();

                gl_Generic.gl_str_Branch_SubGroup = dt.Rows[0]["br_subgroup"].ToString();
                gl_Generic.gl_str_Branch_PriceGroup = dt.Rows[0]["br_Pricegroup"].ToString();

                gl_Generic.gl_int_Branch_Group_ID = HelperClass.ConvertInteger(dt.Rows[0]["brg_ID"].ToString());
                gl_Generic.gl_str_Branch_Group_Name = dt.Rows[0]["brg_Description"].ToString();
            }


        }

        private string getUIDNo()
        {
            string str_uid = "";
            string message = "";
            try
            {
                DateTime now = DateTime.Now;
                string str2 = (now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day).ToString();
                string str3 = now.ToString("HHmss");
                string str4 = str2 + str3;
                BLL_Generic bll = new BLL_Generic();
                DataTable dt = bll.Get_Seqnumberuid(gl_Generic.gl_int_Branch_ID);

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        str_uid = dt.Rows[0]["uidsn_branchid"].ToString() + dt.Rows[0]["uidsn_id"].ToString() + String.Format(dt.Rows[0]["uidsn_format"].ToString(), dt.Rows[0]["uidsn_docno"].ToString()) + str4;

                    }
                    finally
                    {
                        dt.Dispose();
                    }
                }
                else
                {
                    message = "Seqnumberuid is empty to generate uid!";
                }
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(ex.Message);
            }
            return str_uid;
        }

        private string getCheckno(string _p_rvcid)
        {
            string str_checknext = "";
            string str_checkmin = "";
            string str_checkmax = "";
            string str4 = "";
            try
            {
                BLL_Generic bll = new BLL_Generic();
                DataTable dt = bll.Get_RVC_CheckNumber(gl_Generic.gl_int_RVC_ID);

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        str_checknext = dt.Rows[0]["rvc_checknext"].ToString();
                        str_checkmin = dt.Rows[0]["rvc_checkmin"].ToString();
                        str_checkmax = dt.Rows[0]["rvc_checkmax"].ToString();
                        if (str_checkmin == str_checkmax)
                            str_checknext = dt.Rows[0]["rvc_checkmin"].ToString();
                    }
                    finally
                    {

                    }
                }
                else
                    str_checknext = "";

                dt.Clear();
                dt.Dispose();

                if (gl_Generic.gl_str_RVC_TypeDef.Contains("rvc_71;;") & gl_Generic.gl_str_RVC_TypeDef.Contains("rvc_119"))
                {
                    str4 = (getCheckno_Random(HelperClass.ConvertInteger(str_checkmin), HelperClass.ConvertInteger(str_checkmax))).ToString();
                }
                else
                {
                    str4 = str_checknext;
                }
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(ex.Message);
            }
            return str4;
        }

        private string getCheckno_Random(int nLower, int nHigher)
        {
            string str_checkno = "";
            try
            {
                BLL_Generic bll = new BLL_Generic();

                string str2 = "SELECT TOP 1 rnd_number FROM random_checkno ";
                str2 += "where isnull(rnd_used,'') <> 'Y' ";
                str2 += "and rnd_number >= " + nLower + " ";
                str2 += "and rnd_number <= " + nHigher + " " + "ORDER BY NEWID() ";

                DataTable dt = bll.SQL_Retrieve_By_String(str2);

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        string str_update_checkno_used = "update Random_Checkno set rnd_used = 'Y' where rnd_number = " + dt.Rows[0]["rnd_number"].ToString();

                        int result = bll.SQL_DML_By_String(str_update_checkno_used);

                        str_checkno = dt.Rows[0]["rnd_number"].ToString();
                    }
                    finally
                    {

                    }
                }
                dt.Clear();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(ex.Message);
            }
            return str_checkno;
        }

        private void Bind_Sale_Type_and_Service_charge(string salestype)
        {
            BLL_Generic bLL_Generic = new BLL_Generic();
            DataTable dt = bLL_Generic.Get_SalesType_and_TransType_Info(salestype);

            if (dt.Rows.Count > 0)
            {
                gl_Generic.gl_str_SalesTypeSuffix = dt.Rows[0]["sat_suffix"].ToString();
                gl_Generic.gl_str_SalesType_Code = dt.Rows[0]["sat_code"].ToString();
                gl_Generic.gl_str_SalesType_Desc = dt.Rows[0]["sat_description"].ToString();
                gl_Generic.gl_str_SalesType_TypeDef = dt.Rows[0]["sat_typedef"].ToString();
                gl_Generic.gl_str_Price_Group = dt.Rows[0]["sat_price"].ToString();
                gl_Generic.gl_int_SalesType_TaxID = HelperClass.ConvertInteger(dt.Rows[0]["stt_taxid"].ToString());

                gl_Generic.gl_str_TransType_Code = dt.Rows[0]["tat_code"].ToString();
                gl_Generic.gl_str_TransType_Desc = dt.Rows[0]["tat_description"].ToString();


            }

            if (gl_Generic.gl_str_SalesType_TypeDef.Contains("sat_1;;"))
            {
                DataTable dt_servicecharge = bLL_Generic.Get_ServiceCharge();

                if (dt_servicecharge.Rows.Count == 0)
                    return;

                gl_Generic.gl_servicecharge.sc_id = HelperClass.ConvertInteger(dt_servicecharge.Rows[0]["sc_id"].ToString());
                gl_Generic.gl_servicecharge.sc_number = dt_servicecharge.Rows[0]["sc_number"].ToString();
                gl_Generic.gl_servicecharge.sc_desc = dt_servicecharge.Rows[0]["sc_desc"].ToString();
                gl_Generic.gl_servicecharge.sc_type = dt_servicecharge.Rows[0]["sc_type"].ToString();
                gl_Generic.gl_servicecharge.sc_accountcode = dt_servicecharge.Rows[0]["sc_accountcode"].ToString();
                gl_Generic.gl_servicecharge.sc_percentage = HelperClass.ConvertDecimal(dt_servicecharge.Rows[0]["sc_percentage"].ToString());
                gl_Generic.gl_servicecharge.sc_startamount = HelperClass.ConvertDecimal(dt_servicecharge.Rows[0]["sc_startamount"].ToString());
                gl_Generic.gl_servicecharge.sc_typedef = dt_servicecharge.Rows[0]["sc_typedef"].ToString();

                dt_servicecharge.Dispose();
                GC.Collect();
            }
            else
            {
                gl_Generic.gl_servicecharge = new BOL_ServiceCharge();
            }

            dt.Dispose();
        }

        #region Sales

        private string Insert_Sales(string prm_sa_token, string prm_sa_code)
        {
            BLL_Sales bll_sa = new BLL_Sales();
            BOL_Sales bol_sa = new BOL_Sales();

            bol_sa.sa_ReceiptNo = gl_Generic.gl_str_uid;
            bol_sa.sa_Casher = "";
            bol_sa.sa_SalesPerson = "";
            bol_sa.sa_SalesDate = DateTime.Now.Date.ToString("yyyyMMdd");
            bol_sa.sa_memberno = "";

            bol_sa.sa_Status = "Suspend";
            bol_sa.sa_CreateDate = DateTime.Now.Date.ToString("yyyyMMdd");
            bol_sa.sa_Station = "0";
            bol_sa.sa_CancelBy = null;
            bol_sa.sa_CancelDT = null;

            bol_sa.sa_CancelReason = null;
            bol_sa.sa_uid = gl_Generic.gl_str_uid;
            bol_sa.sa_CustCode = "Cash";
            bol_sa.sa_DealerCode = "";
            bol_sa.sa_Commission = 0;

            bol_sa.sa_BranchID = gl_Generic.gl_int_Branch_ID;
            bol_sa.sa_LoyaltyTypeid = 0;
            bol_sa.sa_LoyaltyCardno = "";
            bol_sa.sa_HDSerialNo = "";
            bol_sa.sa_roundingvariance = gl_Generic.gl_dec_roundingvariance; //to change

            bol_sa.sa_InvoiceNo = null;
            bol_sa.sa_pmuploaded = null;
            bol_sa.sa_pmvoiduploaded = null;
            bol_sa.sa_custom1 = "";
            bol_sa.sa_custom2 = "";

            bol_sa.sa_custom3 = "";
            bol_sa.sa_SMPid = 0;
            bol_sa.sa_SMPcode = "";
            bol_sa.sa_SMPname = "";
            bol_sa.sa_businessdate = gl_Generic.gl_date_BusinessDate.Date.ToString("yyyyMMdd");

            bol_sa.sa_SuspendDate = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            bol_sa.sa_SuspendDateDayEnd = gl_Generic.gl_date_BusinessDate.Date.ToString("yyyyMMdd");
            bol_sa.sa_servicecharge = gl_Generic.gl_dec_servicecharge;
            bol_sa.sa_tax = gl_Generic.gl_dec_tax;
            bol_sa.sa_clearbill = null;

            bol_sa.sa_cancelDTbusinessdate = null;
            bol_sa.sa_SalesTime = "19000101 " + DateTime.Now.ToString("HH:mm:ss");
            bol_sa.sa_custom4 = "0";
            bol_sa.sa_kdsok = null;
            bol_sa.sa_kdstime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");

            bol_sa.sa_kdsdt = null;
            bol_sa.sa_transtype = gl_Generic.gl_str_TransType_Code;
            bol_sa.sa_salestype = gl_Generic.gl_str_SalesType_Code;
            bol_sa.sa_SuspendBySalesPerson = "";
            bol_sa.sa_split = null;

            bol_sa.sa_splitfrom = null;
            bol_sa.sa_splitseq = null;
            bol_sa.sa_splitseatno = null;
            bol_sa.sa_BranchDesc = gl_Generic.gl_str_Branch_Name;
            bol_sa.sa_BranchGrpID = gl_Generic.gl_int_Branch_Group_ID;

            bol_sa.sa_BranchGrpDesc = gl_Generic.gl_str_Branch_Group_Name;
            bol_sa.sa_RVCID = gl_Generic.gl_int_RVC_ID;
            bol_sa.sa_RVCDesc = gl_Generic.gl_str_RVC_Desc;
            bol_sa.sa_PCID = null;
            bol_sa.sa_checkno = gl_Generic.gl_str_checkno;

            bol_sa.sa_iid = null;
            bol_sa.sa_printcopy = null;
            bol_sa.sa_SalesTypeSuffix = gl_Generic.gl_str_SalesTypeSuffix;
            bol_sa.sa_datasource = null;
            bol_sa.sa_printstatus = null;

            bol_sa.sa_printengine = null;
            bol_sa.sa_printdt = null;
            bol_sa.sa_billtoname = null;
            bol_sa.sa_billtoadd1 = null;
            bol_sa.sa_billtoadd2 = null;

            bol_sa.sa_billtoadd3 = null;
            bol_sa.sa_billtoadd4 = null;
            bol_sa.sa_billtoTelno = null;
            bol_sa.sa_billtoFaxno = null;
            bol_sa.sa_closecheckrpt = null;

            bol_sa.sa_shiftid = 0;
            bol_sa.sa_shiftno = 0;
            bol_sa.sa_shiftrefno = "";
            bol_sa.sa_sosorderstart = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            bol_sa.sa_sossubtotalstart = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");

            bol_sa.sa_soslastpaymentstart = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            bol_sa.sa_sosclosedrawer = null;
            bol_sa.sa_salespersonname = null;
            //bol_sa.sa_mobile = null;
            //bol_sa.sa_syncdata = null;

            //bol_sa.sa_syncvoiddata = "";
            bol_sa.sa_expeditionType = gl_Generic.gl_str_expeditionType.ToUpper();
            bol_sa.sa_token = prm_sa_token;
            bol_sa.sa_code = prm_sa_code;
            return bll_sa.Insert_Sales(bol_sa);
        }

        #endregion Sales


        #region Sales_Details
        private int Insert_Sales_Details(string stockNumber, int quantity, string unitprice, string discountamount, int sd_packageparentid, int sd_packageparentstockid, int sd_combogroup, int sd_iscondi, int sd_comboparentid)
        {
            BOL_Sales_Details bol_sd = new BOL_Sales_Details();
            BOL_SalesDetails_Discount bol_sdd = new BOL_SalesDetails_Discount();
            BLL_Sales_Details bll_sd = new BLL_Sales_Details();
            BLL_GetMenu bll_getmenu = new BLL_GetMenu();
            BLL_Generic bll_generic = new BLL_Generic();

            DataTable dt_menu = bll_getmenu.Get_Stock(stockNumber);
            decimal lc_dec_sprice = HelperClass.ConvertDecimal(unitprice);
            decimal lc_dec_discount_sprice = lc_dec_sprice;
            bool lc_bool_calculate_discount = false;

            int inserted_sd_ID = 0;
            if (dt_menu.Rows.Count > 0)
            {
                int lc_int_stockid = HelperClass.ConvertInteger(dt_menu.Rows[0]["st_id"].ToString());
                BOL_Tax bol_tax = new BOL_Tax();
                BOL_Tax_and_SVC_Amount bol_tax_and_svc = new BOL_Tax_and_SVC_Amount();

                if (gl_Generic.gl_discount != null)
                    lc_bool_calculate_discount = bll_generic.Check_Discount_Itemize_with_Stocks(stockNumber, gl_Generic.gl_discount.disc_name1);

                if (lc_bool_calculate_discount)
                {
                    if (gl_Generic.gl_discount.is_percentage)
                    {
                        bol_sdd.sdd_discamount = (lc_dec_sprice * gl_Generic.gl_discount.disc_amount) / 100M;
                    }
                    else
                    {
                        bol_sdd.sdd_discamount = lc_dec_sprice - gl_Generic.gl_discount.disc_amount;
                    }

                    lc_dec_discount_sprice = lc_dec_sprice - bol_sdd.sdd_discamount;
                }


                if (dt_menu.Rows[0]["st_typedef"].ToString().Contains("item_8;;"))
                {
                    bol_tax = CalculateTax_and_ServiceCharge_forMenuItem(lc_int_stockid, true, lc_dec_sprice, lc_dec_discount_sprice, out bol_tax_and_svc);
                }
                else
                {
                    bol_tax = CalculateTax_and_ServiceCharge_forMenuItem(lc_int_stockid, false, lc_dec_sprice, lc_dec_discount_sprice, out bol_tax_and_svc);
                }

                gl_Generic.gl_dec_tax += bol_tax_and_svc.sd_TaxAmountActual;
                gl_Generic.gl_dec_servicecharge += bol_tax_and_svc.sd_svcamountactual;


                bol_sd.sd_StockID = lc_int_stockid.ToString();
                bol_sd.sd_Qty = quantity.ToString();
                bol_sd.sd_SPrice = lc_dec_sprice;
                bol_sd.sd_DiscPercent = bol_sdd.sdd_discpercent;
                bol_sd.sd_Disc = bol_tax_and_svc.discount_amount_without_Tax;//bol_sdd.sdd_discamount;


                bol_sd.sd_uid = gl_Generic.gl_str_uid;
                bol_sd.sd_CostPrice = 0;
                bol_sd.sd_pType = "";
                bol_sd.sd_VoucherNo = "";
                bol_sd.sd_UOM = "UNIT";

                bol_sd.sd_Contain = 1;
                bol_sd.sd_branchid = gl_Generic.gl_int_Branch_ID;
                bol_sd.sd_sn = stockNumber;
                bol_sd.sd_linepoints = lc_dec_discount_sprice; //it is from Stock Price
                bol_sd.sd_Description = dt_menu.Rows[0]["st_Description"].ToString();

                bol_sd.sd_att1 = "";
                bol_sd.sd_att2 = "";
                bol_sd.sd_returnfrom = "0";
                bol_sd.sd_hd = null;
                bol_sd.sd_HDSerialNo = "";

                bol_sd.sd_updateST = null;
                bol_sd.sd_location = "";
                bol_sd.sd_export = null;
                bol_sd.sd_sono = "";
                bol_sd.sd_promotype = "";

                bol_sd.sd_promoparentid = "";
                bol_sd.sd_promosdid = "";
                bol_sd.sd_spriceBeforeMK = HelperClass.ConvertDecimal(unitprice);
                bol_sd.sd_markdownpercent = 0;
                bol_sd.sd_voucheruid = "";

                bol_sd.sd_productvoucher = "";
                bol_sd.sd_commissionCompPercent = 0;
                bol_sd.sd_commissionCompValue = 0;
                bol_sd.sd_commissionTravelPercent = 0;
                bol_sd.sd_commissionTravelValue = 0;

                bol_sd.sd_commissionPercent = 0;
                bol_sd.sd_commissionValue = 0;
                bol_sd.sd_commission = 0;
                bol_sd.sd_TaxPercent = bol_tax.tax_percentage; //to edit
                bol_sd.sd_TaxAmount = bol_tax_and_svc.sd_TaxAmount; // to edit

                bol_sd.sd_CommissionCalculationAmt = 0;
                bol_sd.sd_DiscountType = null; //to check and edit
                bol_sd.sd_SPromo = null;
                bol_sd.sd_lineextra = "";
                bol_sd.sd_packageparentid = sd_packageparentid.ToString();

                bol_sd.sd_kitchenhold = "0";
                bol_sd.sd_kitchenfire = true;
                bol_sd.sd_kitchenbump = null;
                bol_sd.sd_kitchenfireon = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                bol_sd.sd_kitchenfireby = null;

                bol_sd.sd_kitchenbumpon = null;
                bol_sd.sd_kitchenbumpby = null;
                bol_sd.sd_salestype = gl_Generic.gl_str_SalesType_Code;
                bol_sd.sd_combopattern = dt_menu.Rows[0]["st_combopattern"].ToString();
                bol_sd.sd_combogroup = sd_combogroup.ToString();

                bol_sd.sd_cook = null;
                bol_sd.sd_collect = null;
                bol_sd.sd_actualproduct = 0;
                bol_sd.sd_kitchenprint = null;
                bol_sd.sd_kitchenprinton = null;

                bol_sd.sd_printengine = null;
                bol_sd.sd_enterby = "";
                bol_sd.sd_auto = "1";
                bol_sd.sd_refund = "N";
                bol_sd.sd_taxtype = bol_tax.tax_type;

                bol_sd.sd_TaxAmountActual = bol_tax_and_svc.sd_TaxAmountActual;
                bol_sd.sd_svcpercent = 0; //edit
                bol_sd.sd_svcamount = bol_tax_and_svc.sd_svcamount;
                bol_sd.sd_svcamountactual = bol_tax_and_svc.sd_svcamountactual;
                bol_sd.sd_svctype = "";

                bol_sd.sd_voidremarks = "";
                bol_sd.sd_discountDesc = null;
                bol_sd.sd_resume = null;
                bol_sd.sd_ItemTaxAmount = bol_tax_and_svc.sd_ItemTaxAmount;
                bol_sd.sd_ItemTaxAmountActual = bol_tax_and_svc.sd_ItemTaxAmountActual;  //edit

                bol_sd.sd_SVCTaxAmount = 0; //edit
                bol_sd.sd_SVCTaxAmountActual = 0;//edit
                bol_sd.sd_seatno = null;
                bol_sd.sd_splitfrom = null;
                bol_sd.sd_checkno = gl_Generic.gl_str_checkno; //edit to check from foodpanda

                bol_sd.sd_notallowdiscountagain = null;
                bol_sd.sd_AddOnTaxAmountActual = bol_tax_and_svc.sd_AddOnTaxAmountActual;
                bol_sd.sd_InclusiveTaxAmountActual = bol_tax_and_svc.sd_InclusiveTaxAmountActual;
                bol_sd.sd_ItemAddOnTaxAmountActual = bol_tax_and_svc.sd_ItemAddOnTaxAmountActual;
                bol_sd.sd_ItemInclusiveTaxAmountActual = bol_tax_and_svc.sd_ItemInclusiveTaxAmountActual;

                bol_sd.sd_SVCAddOnTaxAmountActual = bol_tax_and_svc.sd_SVCAddOnTaxAmountActual;
                bol_sd.sd_SVCInclusiveTaxAmountActual = bol_tax_and_svc.sd_SVCInclusiveTaxAmountActual;
                bol_sd.sd_iscondi = sd_iscondi.ToString();
                bol_sd.sd_AmtForCalcSVC = HelperClass.ConvertDecimal(unitprice);
                bol_sd.sd_AmtForCalcTax = HelperClass.ConvertDecimal(unitprice);

                bol_sd.sd_combopatterncbosid = dt_menu.Rows[0]["st_combopatterncbosid"].ToString();
                bol_sd.sd_combocbosid = ""; //edit, split from sd_combopatterncbosid if it is child menu
                bol_sd.sd_condiparentid = sd_iscondi == 1 ? sd_packageparentid.ToString() : null;
                bol_sd.sd_comboparentid = sd_iscondi == 1 ? sd_comboparentid.ToString() : null; //only if menu is condiment
                bol_sd.sd_combopatterncount = null;

                bol_sd.sd_packageparentstockid = null; //fill parent stockid if only wish
                bol_sd.sd_iid = null;
                bol_sd.sd_SalesTypeSuffix = gl_Generic.gl_str_SalesTypeSuffix; //edit
                bol_sd.sd_Casher = "";
                bol_sd.sd_CasherName = "";

                bol_sd.sd_SalesPerson = "";
                bol_sd.sd_SalesPersonName = "";
                bol_sd.sd_prttokitchen = null;
                bol_sd.sd_recipestatus = null;
                bol_sd.sd_updaterecipe = null;

                bol_sd.sd_prttoprinter = null;
                bol_sd.sd_weight = 1;
                bol_sd.sd_spriceBeforeWeight = HelperClass.ConvertDecimal(unitprice);
                bol_sd.sd_WeightItem = "N";
                bol_sd.sd_servicechargeid = "0";

                bol_sd.sd_servicechargename = "";
                bol_sd.sd_shiftid = "0";
                bol_sd.sd_shiftno = "0";
                bol_sd.sd_shiftrefno = "";
                bol_sd.sd_pcscount = "0";

                bol_sd.sd_ComboPatternQty = "";
                bol_sd.sd_TotalInclusivePercentage = bol_tax.tax_type == "Inclusive Tax" ? bol_tax.tax_percentage : 0;

                bol_sd.sd_Nett = HelperClass.ConvertDecimal(unitprice) - bol_tax_and_svc.sd_ItemInclusiveTaxAmountActual;

                if (lc_bool_calculate_discount)
                    bol_sd.sd_NettAfterDiscountForCalcTax = bol_sd.sd_Nett - bol_tax_and_svc.discount_amount_without_Tax;//bol_sd.sd_Nett - bol_sd.sd_Disc;


                bol_sd.sd_fireonthefly = "N";

                bol_sd.sd_fireontheflytime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                bol_sd.sd_kdsend = false;
                bol_sd.sd_businessdate = gl_Generic.gl_date_BusinessDate.Date.ToString("yyyyMMdd");
                bol_sd.sd_UniqueSDID = GenerateGUID().ToString();
                bol_sd.sd_kdsendonthefly = null;

                bol_sd.sd_mobiletemp = null;
                //bol_sd.sd_syncdata = "";
                //bol_sd.sd_syncvoiddata = "";

                bll_sd.Insert_Sales_Detail(bol_sd, out inserted_sd_ID);

                //Sales Details _Discount
                if (lc_bool_calculate_discount)
                {
                    bol_sdd.sdd_qty = HelperClass.ConvertInteger(bol_sd.sd_Qty);
                    bol_sdd.sdd_sdid = inserted_sd_ID;
                    bol_sdd.sdd_Nett = bol_sd.sd_Nett;
                    bol_sdd.sdd_sprice = bol_sd.sd_SPrice;
                    bol_sdd.sdd_TotalAfterDiscount = bol_sd.sd_NettAfterDiscountForCalcTax;

                    bol_sdd.sdd_discid = gl_Generic.gl_discount.disc_id;
                    bol_sdd.sdd_discname1 = gl_Generic.gl_discount.disc_name1;
                    bol_sdd.sdd_discname2 = gl_Generic.gl_discount.disc_name2;
                    bol_sdd.sdd_discname3 = gl_Generic.gl_discount.disc_name3;
                    bol_sdd.sdd_discno = gl_Generic.gl_discount.disc_number;

                    bol_sdd.sdd_disctype = gl_Generic.gl_discount.str_disctype;
                    bol_sdd.sdd_discpercent = gl_Generic.gl_discount.disc_amount;
                    bol_sdd.sdd_sn = bol_sd.sd_sn;
                    bol_sdd.sdd_stockid = bol_sd.sd_StockID;
                    bol_sdd.discountamountwithtax = bol_sdd.sdd_discamount;

                    bol_sdd.sdd_discamount = bol_tax_and_svc.discount_amount_without_Tax;

                    Insert_SalesDetails_Discount(bol_sdd);
                }

                last_sd_id_for_discount = inserted_sd_ID;

            }

            return inserted_sd_ID;
        }

        /// <summary>
        /// Calculate tax for menu item here, YHA
        /// </summary>
        private BOL_Tax CalculateTax_and_ServiceCharge_forMenuItem(int stock_id, bool is_svc_calc, decimal stock_price, decimal discount_stock_price, out BOL_Tax_and_SVC_Amount _out_tax_and_svc_amount)
        {
            BLL_Generic bll = new BLL_Generic();
            BOL_Tax objbol_tax = bll.Get_Tax_By_Stock(stock_id, gl_Generic.gl_int_SalesType_TaxID);
            BOL_Tax_and_SVC_Amount bol_tax_and_svc = new BOL_Tax_and_SVC_Amount();

            decimal _lc_dec_st_price = stock_price;
            decimal _lc_dec_disc_st_price = discount_stock_price;
            decimal _lc_dec_amount_for_discount_tax = _lc_dec_st_price - _lc_dec_disc_st_price;
            decimal _lc_tax_amount = 0, _lc_disc_tax_amount = 0, _lc_dec_servicecharges = 0, _lc_dec_servicecharges_tax = 0;

            if (is_svc_calc)
            {
                _lc_dec_servicecharges = Math.Round((_lc_dec_st_price * gl_Generic.gl_servicecharge.sc_percentage) / 100M, 4);
                _lc_dec_st_price = _lc_dec_st_price + _lc_dec_servicecharges;
            }

            if (objbol_tax.tax_type == "Inclusive Tax")
            {
                bol_tax_and_svc.disc_tax = Math.Round(_lc_dec_amount_for_discount_tax / ((objbol_tax.tax_percentage + 100M) / objbol_tax.tax_percentage), 4);
                bol_tax_and_svc.discount_amount_without_Tax = _lc_dec_amount_for_discount_tax - bol_tax_and_svc.disc_tax;

                _lc_tax_amount = Math.Round(_lc_dec_st_price / ((objbol_tax.tax_percentage + 100M) / objbol_tax.tax_percentage), 4);

                _lc_disc_tax_amount = Math.Round(_lc_dec_disc_st_price / ((objbol_tax.tax_percentage + 100M) / objbol_tax.tax_percentage), 4);

                _lc_dec_servicecharges_tax = Math.Round(_lc_dec_servicecharges / ((objbol_tax.tax_percentage + 100M) / objbol_tax.tax_percentage), 4);

                bol_tax_and_svc.sd_InclusiveTaxAmountActual = _lc_disc_tax_amount;
                bol_tax_and_svc.sd_ItemInclusiveTaxAmountActual = _lc_tax_amount;

                bol_tax_and_svc.sd_SVCInclusiveTaxAmountActual = _lc_dec_servicecharges_tax;

            }
            else if (objbol_tax.tax_type == "Add On" || objbol_tax.tax_type == "VAT")
            {
                bol_tax_and_svc.disc_tax = Math.Round((_lc_dec_amount_for_discount_tax / 100M) * objbol_tax.tax_percentage, 4);

                _lc_tax_amount = Math.Round((_lc_dec_st_price / 100M) * objbol_tax.tax_percentage, 4);

                _lc_disc_tax_amount = Math.Round((_lc_dec_disc_st_price / 100M) * objbol_tax.tax_percentage, 4);

                _lc_dec_servicecharges_tax = Math.Round((_lc_dec_servicecharges / 100M) * objbol_tax.tax_percentage, 4);

                bol_tax_and_svc.sd_AddOnTaxAmountActual = _lc_disc_tax_amount;
                bol_tax_and_svc.sd_ItemAddOnTaxAmountActual = _lc_tax_amount;

                bol_tax_and_svc.sd_SVCAddOnTaxAmountActual = _lc_dec_servicecharges_tax;
            }

            bol_tax_and_svc.sd_TaxAmountActual = _lc_disc_tax_amount;
            bol_tax_and_svc.sd_ItemTaxAmountActual = _lc_disc_tax_amount;

            bol_tax_and_svc.sd_svcamount = _lc_dec_servicecharges;
            bol_tax_and_svc.sd_svcamountactual = _lc_dec_servicecharges;
            bol_tax_and_svc.sd_SVCTaxAmount = _lc_dec_servicecharges_tax;
            bol_tax_and_svc.sd_SVCTaxAmountActual = _lc_dec_servicecharges_tax;

            _out_tax_and_svc_amount = bol_tax_and_svc;

            return objbol_tax;
        }

        public static object GenerateGUID()
        {
            return (DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day) + DateTime.Now.ToString("HHmmssfffffff");
        }

        #endregion Sales_Details


        #region SalesDetails_Discount

        private void Insert_SalesDetails_Discount(BOL_SalesDetails_Discount prm_obj_sdd)
        {
            BLL_SalesDetails_Discount bll_sdd = new BLL_SalesDetails_Discount();
            BOL_SalesDetails_Discount bol_sdd = new BOL_SalesDetails_Discount();

            bol_sdd.sdd_uid = gl_Generic.gl_str_uid;
            bol_sdd.sdd_DisplayAftersdid = null;
            bol_sdd.sdd_sdid = prm_obj_sdd.sdd_sdid;
            bol_sdd.sdd_discidsequence = "1";
            bol_sdd.sdd_discid = prm_obj_sdd.sdd_discid;
            bol_sdd.sdd_discno = prm_obj_sdd.sdd_discno;
            bol_sdd.sdd_discname1 = prm_obj_sdd.sdd_discname1;
            bol_sdd.sdd_disctype = gl_Generic.gl_discount.str_disctype;
            bol_sdd.sdd_discpercent = prm_obj_sdd.sdd_discpercent;
            bol_sdd.sdd_discamount = prm_obj_sdd.sdd_discamount;
            bol_sdd.sdd_sn = prm_obj_sdd.sdd_sn;
            bol_sdd.sdd_stockid = prm_obj_sdd.sdd_stockid;
            bol_sdd.sdd_uom = "UNIT";
            bol_sdd.sdd_contain = 1;
            bol_sdd.sdd_att1 = "";
            bol_sdd.sdd_att2 = "";
            bol_sdd.sdd_sprice = prm_obj_sdd.sdd_sprice;
            bol_sdd.sdd_qty = prm_obj_sdd.sdd_qty;
            bol_sdd.sdd_businessdate = gl_Generic.gl_date_BusinessDate.Date.ToString("yyyyMMdd");
            bol_sdd.sdd_createdate = DateTime.Now.Date.ToString("yyyyMMdd HH:mm:ss");
            bol_sdd.sdd_createby = "";
            bol_sdd.sdd_createbyname = "";
            bol_sdd.sdd_discname2 = prm_obj_sdd.sdd_discname2;
            bol_sdd.sdd_discname3 = prm_obj_sdd.sdd_discname3;
            //bol_sdd.sdd_AmtForCalcSVC = "";
            //bol_sdd.sdd_AmtForCalcTax = "";
            bol_sdd.sdd_remarks = "";
            bol_sdd.sdd_resume = null;
            bol_sdd.sdd_SubtotalDiscByValue = gl_Generic.gl_discount.is_percentage ? "N" : "Y";
            bol_sdd.sdd_SubtotalDiscValue = prm_obj_sdd.discountamountwithtax;
            bol_sdd.sdd_branchid = gl_Generic.gl_int_Branch_ID;
            bol_sdd.sdd_iid = null;
            bol_sdd.sdd_shiftid = "0";
            bol_sdd.sdd_shiftno = "0";
            bol_sdd.sdd_shiftrefno = "";
            bol_sdd.sdd_Nett = prm_obj_sdd.sdd_Nett;
            bol_sdd.sdd_TotalAfterDiscount = prm_obj_sdd.sdd_TotalAfterDiscount;
            bol_sdd.sdd_syncdata = null;
            bol_sdd.sdd_syncvoiddata = null;

            string result = bll_sdd.Insert_Sales_Detail(bol_sdd);
        }

        #endregion SalesDetails_Discount
        // PUT: api/SalesOrder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalesOrder/5
        public void Delete(int id)
        {
        }
    }
}
