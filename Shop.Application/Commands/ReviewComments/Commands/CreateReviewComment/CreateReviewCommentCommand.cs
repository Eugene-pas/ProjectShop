using System;
using MediatR;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommand : IRequest<ReviewCommentVm>
    {
        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public string Comment { get; set; }
    }
}
