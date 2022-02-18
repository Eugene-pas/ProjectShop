namespace DemoApi.Models.ProductModels
{
    public class UpdateProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? OnStorageCount { get; set; }
        public double Rating { get; set; }
        public long CategoryId { get; set; }
        public long SellerId { get; set; }
    }
}
