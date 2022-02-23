using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQueryHandler
        : HandlersBase, IRequestHandler<GetReviewsListQuery, ReviewsListVm>
    {
        public GetReviewsListQueryHandler(IDataBaseContext dbContext, IMapper mapper)
               : base(dbContext, mapper) { }

        public async Task<ReviewsListVm> Handle(GetReviewsListQuery request,
               CancellationToken cancellationToken)
        {
            var reviewsQuery = await _dbContext.Review
                .ProjectTo<ReviewsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReviewsListVm { Reviews = reviewsQuery };
        }
    }
}
