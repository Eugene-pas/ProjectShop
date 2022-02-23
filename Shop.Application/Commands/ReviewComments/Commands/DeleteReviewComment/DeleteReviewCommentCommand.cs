using System;
using MediatR;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Commands.DeleteReviewComment
{
    public class DeleteReviewCommentCommand : IRequest<ReviewCommentVm>
    {
        public long Id { get; set; }
    }
}
