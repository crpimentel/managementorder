namespace managementorder.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        // Relación muchos-a-muchos con Product
        public List<OrderProductView> OrderProducts { get; set; } = new List<OrderProductView>();
    }
}
