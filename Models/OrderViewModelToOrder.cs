namespace managementorder.Models
{
    public class OrderViewModelToOrder
    {
        public string orderNumber { get; set; }
        public string OrderDate { get; set; }
        // New properties for calculations is total QuantityProd
        public int TotalQuantityProd { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }
        public string StatusId { get; set; }

        public string StatusName { get; set; }
        public string SupplyName { get; set; }
        public string ContactInfo { get; set; }
        public string QuantityProd { get; set; }
        public string DiscountProd { get; set; }
        // Relación muchos-a-muchos con Product
        public List<ProductViewModelToOrder> Products { get; set; } = new List<ProductViewModelToOrder>();
    }
}
