using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewComment
{
    public class GetReviewCommentQueryValidator
          : AbstractValidator<GetReviewCommentQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetReviewCommentQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(getreviewcommentqueryvalidator =>
            getreviewcommentqueryvalidator.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(ReviewCommentExist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified ReviewCommentId doesn't exist.");
        }

        public async Task<bool> ReviewCommentExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.ReviewComment.AnyAsync(c => c.Id == Id);
        }
    }
}
