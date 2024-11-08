namespace managementorder.Models
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }   // Stores the image in binary format
        public string ImageType { get; set; }   // MIME type of the image, e.g., "image/jpeg"

    }
}
