using System.ComponentModel;

namespace managementorder.Models
{
    public class ProductViewModelToClient
    {
        public int Id { get; set; }
        [DisplayName("Nombre del Producto")]
        public string Name { get; set; }
        [DisplayName("Precio")]
        public decimal Price { get; set; }
        [DisplayName("Cantidad")]
        public int Stock { get; set; }

        [DisplayName("Descripcion")]
        public string Description { get; set; }
    }
}
