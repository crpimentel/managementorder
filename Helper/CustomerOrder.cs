using managementorder.Models;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace managementorder.Helper
{
    //public class CustomerOrder
    //{
    //    [JsonPropertyName("DT_RowId")]
    //    public string DT_RowId { get; set; }
    //    public string first_name { get; set; }
    //    public string last_name { get; set; }
    //    public string position { get; set; }
    //    public string office { get; set; }
    //    public string start_date { get; set; }
    //    public string salary { get; set; }
    //}
    //public class CustomerOrder
    //{
    //    [JsonPropertyName("DT_RowId")]
    //    public string DT_RowId { get; set; }
    //    public string name { get; set; }
    //    public string email { get; set; }
    //    public string orderDate { get; set; }

    //    public string productName { get; set; }
    //    public string productPrice { get; set; }
    //    public string productStock { get; set; }

    //    public string productDesc { get; set; }
    //    public string orderNumber { get; set; }

    //}
    public class CustomerOrder
    {
        [JsonPropertyName("DT_RowId")]
        public string DT_RowId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        // Relación uno-a-muchos: un cliente puede tener varias órdenes
        public List<OrderViewModelToOrder> Orders { get; set; } = new List<OrderViewModelToOrder>();
        //public string QuantityProd { get; set; }
        //public string TotalDiscount { get; set; }
        //public string SubTotal { get; set; }
        //public string Itebis { get; set; }
        //public string Total { get; set; }
        //public string StatusName { get; set; }
        //public string SupplyName { get; set; }
        //public string ContactInfo { get; set; }
    }
}
