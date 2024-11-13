namespace managementorder.Helper
{
    public class OrderCalculationRequest
    {
        public List<ProductCalculationData> Products { get; set; }
    }

    public class ProductCalculationData
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
