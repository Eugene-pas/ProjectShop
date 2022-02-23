using System;
using MediatR;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<ReviewsVm>
    {
        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
    }
}
