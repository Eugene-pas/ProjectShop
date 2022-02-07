using System;

namespace DemoApi.Models.ProductImageModels
{
    public class ProductImageModel
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public int SortOrder { get; set; }
        public long ProductId { get; set; }
    }
}
