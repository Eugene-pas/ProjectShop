namespace DemoApi.Models.CategoryModels
{
    public class UpdateCategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentCategoryId { get; set; }
    }
}
