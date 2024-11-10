namespace managementorder.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Relación uno-a-muchos: un cliente puede tener varias órdenes
        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
}
