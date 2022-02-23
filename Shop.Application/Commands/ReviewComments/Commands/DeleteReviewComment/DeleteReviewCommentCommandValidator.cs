using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.ReviewComments.Commands.DeleteReviewComment
{
    public class DeleteReviewLikeCommandValidator
        : AbstractValidator<DeleteReviewCommentCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public DeleteReviewLikeCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(CommentExist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified ReviewCommentId doesn't exist.");
        }

        public async Task<bool> CommentExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.ReviewComment.AnyAsync(x => x.Id == Id);
        }
    }
}
