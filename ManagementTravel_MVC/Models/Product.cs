namespace Project_Travel.Areas.Client.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PictureUrl { get; set; }
        public int Type { get; set; }
        public int Brand { get; set; }
        public int QuantityInStock { get; set; }
        public string PublicId { get; set; }
        public string Discount { get; set; }
    }
}
