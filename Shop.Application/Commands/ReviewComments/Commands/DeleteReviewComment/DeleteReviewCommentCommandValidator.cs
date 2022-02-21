using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewComments.Commands.DeleteReviewComment
{
    public class DeleteReviewCommentCommandValidator
        : AbstractValidator<DeleteReviewCommentCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public DeleteReviewCommentCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(deletereviewcommentcommandvalidator =>
                deletereviewcommentcommandvalidator.Id)
                 .NotEqual(0)
                 .WithMessage("The ReviewCommentId value must not equal to 0")
                 .MustAsync(CommentExist)
                 .WithMessage("The specified ReviewCommentId doesn't exist.");
        }

        public async Task<bool> CommentExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Review.AnyAsync(c => c.Id == Id);
        }
    }
}
