namespace DemoApi.Models.CommentModel
{
    public class CreateCommentModel
    {
        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public string Comments { get; set; }
    }
}
