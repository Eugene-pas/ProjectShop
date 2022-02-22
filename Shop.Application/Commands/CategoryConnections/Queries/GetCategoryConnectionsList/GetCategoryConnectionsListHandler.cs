using System.Collections.Generic;
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
            //var liscConnection = await _dbContext.CategoryConnection
            //    .ProjectTo<GetCategoryConnectionsListLokupDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);

            //return new GetCategoryConnectionsListVm { CategoryConnections = liscConnection };
            var listConection = new List<ConnectionVm>();
            
            var list = await _dbContext.CategoryConnection
                .Include(x => x.Category)
                .ToListAsync(cancellationToken);
            foreach (var item in list)
            {
                listConection.Add(new ConnectionVm
                {
                    Id = item.Id,
                    ParentCategory = await _dbContext.Category
                        .FirstOrDefaultAsync(x => x.Id == item.ParentId),
                    ChildCategory = item.Category
                });
            }

            return new GetCategoryConnectionsListVm {CategoryConnections = listConection};
        }
    }
}
