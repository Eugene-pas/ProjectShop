using System;

namespace DemoApi.Models.ProductImageModels
{
    public class CreateProductImageModel
    {
        public string Image { get; set; }
        public int? SortOrder { get; set; }
    }
}
