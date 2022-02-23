using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLike
{
    public class GetReviewLikeQueryHandler
        : HandlersBase, IRequestHandler<GetReviewLikeQuery, ReviewLikeVm>
    {
        public GetReviewLikeQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewLikeVm> Handle(GetReviewLikeQuery request,
            CancellationToken cancellationToken)
        {
            var reviewlike = await _dbContext.ReviewLike
                .Include(x => x.Review)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _ = reviewlike ?? throw new NotFoundException(nameof(ReviewLike), request.Id);

            return _mapper.Map<ReviewLikeVm>(reviewlike);
        }
    }
}
