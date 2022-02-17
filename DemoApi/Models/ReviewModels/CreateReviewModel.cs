namespace DemoApi.Models.ReviewModels
{
    public class CreateReviewModel
    {
        public string CustomerName { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public long ProductId { get; set; }
    }
}
