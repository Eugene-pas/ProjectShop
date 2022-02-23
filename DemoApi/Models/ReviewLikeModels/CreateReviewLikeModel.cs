namespace DemoApi.Models.ReviewLikeModels
{
    public class CreateReviewLikeModel
    {
        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public bool IsLike { get; set; }
    }
}
