using DemoApi.Models.CommentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Application.Commands.ReviewComments.Commands.CreateComment;
using Shop.Application.Commands.ReviewComments.Commands.DeleteReviewComment;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewCommentController : BaseController
    {
        public ReviewCommentController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<ReviewCommentVm> Create([FromBody] CreateReviewCommentModel comment)
        {
            return await _mediator.Send(new CreateReviewCommentCommand
            {
                ReviewId = comment.ReviewId,
                CustomerId = comment.CustomerId,
                Comments = comment.Comments,
            });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ReviewCommentVm>> Delete(long id)
        {
            return await _mediator.Send(new DeleteReviewCommentCommand { Id = id });
        }
    }
}
