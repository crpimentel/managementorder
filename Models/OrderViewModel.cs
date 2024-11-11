namespace managementorder.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        //debo agregar propiedades nuevas
        // Relación muchos-a-muchos con Product
        public List<OrderProductView> OrderProducts { get; set; } = new List<OrderProductView>();

        // New properties for calculations
        public int QuantityProd { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountProd { get; set; }
        

        // New properties navigation
        public OrderStatuView OrderStatus { get; set; }

        public SupplierView Supplier { get; set; }
    }
}
