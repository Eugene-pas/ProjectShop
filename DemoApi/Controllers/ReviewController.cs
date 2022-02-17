using DemoApi.Models.ReviewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.Reviews.Commands.CreateReview;
using Shop.Application.Commands.Reviews.Queries.GetReviewsList;
using Shop.Application.Commands.Reviews.Queries;
using System.Threading.Tasks;
using Shop.Application.Commands.Reviews.Queries.GetReviewsForProduct;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseController
    {
        public ReviewController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<ReviewsVm> Create([FromBody] CreateReviewModel review)
        {
            return await _mediator.Send(new CreateReviewCommand
            {
                CustomerName = review.CustomerName,
                Rating = review.Rating,
                Comments = review.Comments,
                ProductId = review.ProductId,
            });
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<ReviewsListVm>> GetAll()
        {
            return await _mediator.Send(new GetReviewsListQuery { });
        }

        [HttpGet("getlistforproduct")]
        public async Task<ActionResult<ReviewsForProductVm>> GetAll(long productId)
        {
            return await _mediator.Send(new GetReviewsForProductQuery { ProductId = productId });
        }
    }
}
