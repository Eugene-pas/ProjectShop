namespace DemoApi.Models.CategoryModels
{
    public class CreateCategoryModel
    {
        public string Name { get; set; }
        public long ParentCategoryId { get; set; }
    }
}
