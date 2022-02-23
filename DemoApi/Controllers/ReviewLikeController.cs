using DemoApi.Models.ReviewLikeModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.ReviewLikes.Commands.CreateReviewLike;
using Shop.Application.Commands.ReviewLikes.Commands.DeleteReviewLike;
using Shop.Application.Commands.ReviewLikes.Queries;
using Shop.Application.Commands.ReviewLikes.Queries.GetReviewLike;
using Shop.Application.Commands.ReviewLikes.Queries.GetReviewLikesForReview;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewLikeController : BaseController
    {
        public ReviewLikeController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<ReviewLikeVm> Create([FromBody] CreateReviewLikeModel comment)
        {
            return await _mediator.Send(new CreateReviewLikeCommand
            {
                ReviewId = comment.ReviewId,
                CustomerId = comment.CustomerId,
                IsLike = comment.IsLike,
            });
        }

        [HttpGet("Get")]
        public async Task<ActionResult<ReviewLikeVm>> Get(long id)
        {
            return await _mediator.Send(new GetReviewLikeQuery { Id = id });
        }

        [HttpGet("GetLikesForReview")]
        public async Task<ActionResult<ReviewLikesVm>> GetAll(long reviewId)
        {
            return await _mediator.Send(new GetReviewCommentForReviewQuery { ReviewId = reviewId });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ReviewLikeVm>> Delete(long id)
        {
            return await _mediator.Send(new DeleteReviewLikeCommand { Id = id });
        }
    }
}
