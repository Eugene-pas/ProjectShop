using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.OrderProductConnections.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Commands.UpdateCategoryConnection
{
    public class UpdateCategoryConnectionHandler
        : HandlersBase, IRequestHandler<UpdateCategoryConnectionCommand, CategoryConnectionVm>
    {
        public UpdateCategoryConnectionHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<CategoryConnectionVm> Handle(UpdateCategoryConnectionCommand request,
            CancellationToken cancellationToken)
        {
            var connection = await _dbContext.CategoryConnection
                .FirstOrDefaultAsync(categoryConnection =>
                    categoryConnection.Id == request.Id, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(CategoryConnection), connection.Id);

            connection.ParentId = request.ParentId;
            connection.Child = _dbContext.Category.Find(request.ChildId);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new CategoryConnectionVm
            {
                Id = connection.Id,
                ParentCategory = _dbContext.Category.Find(connection.ParentId),
                ChildCategory = connection.Child
            };
            //return _mapper.Map<CategoryConnectionVm>(connection);
        }
    }
}
