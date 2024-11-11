namespace managementorder.Models
{
    public class OrderViewModelToOrder
    {
        public string orderNumber { get; set; }
        public string OrderDate { get; set; }
        // Relación muchos-a-muchos con Product
        public List<ProductViewModelToOrder> Products { get; set; } = new List<ProductViewModelToOrder>();
    }
}
