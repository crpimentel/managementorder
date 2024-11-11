using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace managementorder.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nombre del Producto")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Precio")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Cantidad")]
        public int Stock { get; set; }
        [Required]
        [DisplayName("Descripcion")]
        public string Description { get; set; }
        // This will hold the uploaded images
        public List<IFormFile> Images { get; set; }

        [ValidateNever]
        public ICollection<ProductImageViewModel> ProductImages { get; set; }
    }
}
