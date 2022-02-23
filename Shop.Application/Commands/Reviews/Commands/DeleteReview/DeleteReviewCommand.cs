using System;
using MediatR;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<ReviewsVm>
    {
        public long Id { get; set; }
    }
}
