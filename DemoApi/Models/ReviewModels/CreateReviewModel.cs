namespace DemoApi.Models.ReviewModels
{
    public class CreateReviewModel
    {
        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
