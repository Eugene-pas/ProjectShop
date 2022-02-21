using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetCategoryConnectionsList
{
    public class GetCategoryConnectionsListHandler
        : HandlersBase, IRequestHandler<GetCategoryConnectionsListQuery, GetCategoryConnectionsListVm>
    {
        public GetCategoryConnectionsListHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<GetCategoryConnectionsListVm> Handle(GetCategoryConnectionsListQuery request, CancellationToken cancellationToken)
        {
            var liscConnection = await _dbContext.CategoryConnection
                .ProjectTo<GetCategoryConnectionsListLokupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetCategoryConnectionsListVm { CategoryConnections = liscConnection };
        }
    }
}
