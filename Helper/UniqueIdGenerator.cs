namespace managementorder.Helper
{
    public static class UniqueIdGenerator
    {
        public static int GetUniqueId(int customerId, int orderId, int productId)
        {
            // Assuming the ID limits
            return customerId * 100000000 + orderId * 10000 + productId;
        }
    }

}
