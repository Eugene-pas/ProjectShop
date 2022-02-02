using System;

namespace DemoApi.Models.ProductImageModels
{
    public class UpdateProductImageModel
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public int? SortOrder { get; set; }
    }
}
