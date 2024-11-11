namespace managementorder.Models
{
    public class OrderProductView
    {
      
        public ProductViewModelToClient Product { get; set; }
        public int QuantityProd { get; set; }
        public decimal DiscountProd { get; set; }
    }
}
