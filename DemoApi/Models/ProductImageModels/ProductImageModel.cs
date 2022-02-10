using System;

namespace DemoApi.Models.ProductImageModels
{
    public class ProductImageModel
    {
        public long Id { get; set; }        
        public int SortOrder { get; set; }
        public long ProductId { get; set; }        
    }
}
