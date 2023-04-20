using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QSSAPI.BOL
{
    public class BOL_Order_Object
    {
        public string token { get; set; }
        public string code { get; set; }
        public Comments comments { get; set; }
        public DateTime createdAt { get; set; }
        public Customer customer { get; set; }
        public Delivery delivery { get; set; }
        public List<Discount> discounts { get; set; }
        public string expeditionType { get; set; }
        public DateTime expiryDate { get; set; }
        public ExtraParameters extraParameters { get; set; }
        public LocalInfo localInfo { get; set; }
        public Payment payment { get; set; }
        public bool test { get; set; }
        public string shortCode { get; set; }
        public string preOrder { get; set; } //had to edit to string from bool
        public object pickup { get; set; }
        public PlatformRestaurant platformRestaurant { get; set; }
        public Price price { get; set; }
        public List<Product> products { get; set; }
        public bool corporateOrder { get; set; }
        public string corporateTaxId { get; set; }
        public IntegrationInfo integrationInfo { get; set; }
        public bool mobileOrder { get; set; }
        public bool webOrder { get; set; }
        public List<object> vouchers { get; set; }
    }


    public class Address
    {
        public string postcode { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string number { get; set; }
    }

    public class Comments
    {
        public string customerComment { get; set; }
        public string vendorComment { get; set; }
    }

    public class Customer
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobilePhone { get; set; }
        public string code { get; set; }
        public string id { get; set; }
        public string mobilePhoneCountryCode { get; set; }
        public List<string> flags { get; set; }
    }

    public class Delivery
    {
        public Address address { get; set; }
        public DateTime expectedDeliveryTime { get; set; }
        public bool expressDelivery { get; set; }
        public Nullable<DateTime> riderPickupTime { get; set; }
    }

    public class DeliveryFee
    {
        public string name { get; set; }
        public double value { get; set; }
    }

    public class Discount
    {
        public string name { get; set; }
        public string amount { get; set; }
        public string type { get; set; }
    }

    public class ExtraParameters
    {
        public string property1 { get; set; }
        public string property2 { get; set; }
    }

    public class IntegrationInfo
    {
    }

    public class LocalInfo
    {
        public string countryCode { get; set; }
        public string currencySymbol { get; set; }
        public string platform { get; set; }
        public string platformKey { get; set; }
        public string currencySymbolPosition { get; set; }
        public string currencySymbolSpaces { get; set; }
        public string decimalDigits { get; set; }
        public string decimalSeparator { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string thousandsSeparator { get; set; }
        public string website { get; set; }
    }

    public class Payment
    {
        public string status { get; set; }
        public string type { get; set; }
        public string remoteCode { get; set; }
        public string requiredMoneyChange { get; set; }
        public string vatId { get; set; }
        public string vatName { get; set; }
    }

    public class PlatformRestaurant
    {
        public string id { get; set; }
    }

    public class Price
    {
        public List<DeliveryFee> deliveryFees { get; set; }
        public string grandTotal { get; set; }
        public string minimumDeliveryValue { get; set; }
        public string payRestaurant { get; set; }
        public string riderTip { get; set; }
        public string subTotal { get; set; }
        public string vatTotal { get; set; }
        public string comission { get; set; }
        public string containerCharge { get; set; }
        public string deliveryFee { get; set; }
        public string collectFromCustomer { get; set; }
        public string discountAmountTotal { get; set; }
        public string deliveryFeeDiscount { get; set; }
        public string serviceFeePercent { get; set; }
        public string serviceFeeTotal { get; set; }
        public int serviceTax { get; set; }
        public int serviceTaxValue { get; set; }
        public string differenceToMinimumDeliveryValue { get; set; }
        public bool vatVisible { get; set; }
        public string vatPercent { get; set; }
    }

    public class Product
    {
        public string categoryName { get; set; }
        public string name { get; set; }
        public string paidPrice { get; set; }
        public string quantity { get; set; }
        public string remoteCode { get; set; }
        public List<SelectedTopping> selectedToppings { get; set; }
        public string unitPrice { get; set; }
        public string comment { get; set; }
        public string description { get; set; }
        public string discountAmount { get; set; }
        public bool halfHalf { get; set; }
        public string id { get; set; }
        public List<object> selectedChoices { get; set; }
        public Variation variation { get; set; }
        public string vatPercentage { get; set; }
    }



    public class SelectedTopping
    {
        public List<Child> children { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
        public string id { get; set; }
        public string remoteCode { get; set; }
        public string type { get; set; }
    }

    public class Child
    {
        public List<Child> children { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
        public string id { get; set; }
        public string remoteCode { get; set; }
        public string type { get; set; }
    }

    public class Variation
    {
        public string name { get; set; }
    }

}