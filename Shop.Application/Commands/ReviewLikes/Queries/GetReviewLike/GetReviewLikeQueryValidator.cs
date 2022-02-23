using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLike
{
    public class GetReviewLikesForReviewQueryValidator
          : AbstractValidator<GetReviewLikeQuery>
    {
        private readonly IDataBaseContext _dbContext;

        public GetReviewLikesForReviewQueryValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .NotNull().WithMessage("ID can not be equeal null.")
                .GreaterThan(0).WithMessage("ID must be greater than zero.")
                .MustAsync(ReviewLikeExist).WithMessage("There is no field with this ID.")
                .WithMessage("The specified ReviewLikeId doesn't exist.");
        }

        public async Task<bool> ReviewLikeExist(long Id, CancellationToken cancellationToken)
        {
            return await _dbContext.ReviewLike.AnyAsync(x => x.Id == Id, cancellationToken: cancellationToken);
        }
    }
}
