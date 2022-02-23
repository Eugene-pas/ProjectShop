namespace DemoApi.Models.CommentModel
{
    public class CreateReviewCommentModel
    {
        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public string Comment { get; set; }
    }
}
