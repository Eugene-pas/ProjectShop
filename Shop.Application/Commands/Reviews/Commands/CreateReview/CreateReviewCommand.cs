using System;
using MediatR;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<ReviewsVm>
    {
        public string CustomerName { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public long ProductId { get; set; }
    }
}
