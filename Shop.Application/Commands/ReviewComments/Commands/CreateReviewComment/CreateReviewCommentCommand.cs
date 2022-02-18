using System;
using MediatR;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Commands.CreateComment
{
    public class CreateReviewCommentCommand : IRequest<ReviewCommentVm>
    {
        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public string Comments { get; set; }
    }
}
