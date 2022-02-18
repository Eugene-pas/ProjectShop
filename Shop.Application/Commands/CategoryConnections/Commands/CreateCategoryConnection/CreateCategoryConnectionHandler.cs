using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections;
using Shop.Application.Common;
using Shop.Application.OrderProductConnections.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection
{
    public class CreateCategoryConnectionHandler
        : HandlersBase, IRequestHandler<CreateCategoryConnectionCommand, CategoryConnectionVm>
    {
        public CreateCategoryConnectionHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<CategoryConnectionVm> Handle(CreateCategoryConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = new CategoryConnection
            {
                ParentId = request.ParentId,
                Child = _dbContext.Category.Find(request.ChildId)
            };

            await _dbContext.CategoryConnection.AddAsync(connection, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            //return new CategoryConnectionVm
            //    {
            //        ParentCategory = _dbContext.Category.Find(request.ParentId),
            //        ChildCategory = _dbContext.Category.Find(request.ChildId)
            //    };
            return new CategoryConnectionVm
            {
                Id = connection.Id,
                ParentCategory =  _dbContext.Category.Find(request.ParentId),
                ChildCategory = connection.Child
            };
        } 
    }
}
