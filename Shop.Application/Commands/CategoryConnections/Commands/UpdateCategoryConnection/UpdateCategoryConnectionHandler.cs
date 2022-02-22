using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

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
            connection.Category = _dbContext.Category.Find(request.ChildId);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new CategoryConnectionVm
            {
                Id = connection.Id,
                ParentCategory = _dbContext.Category.Find(connection.ParentId),
                ChildCategory = connection.Category
            };
            //return _mapper.Map<CategoryConnectionVm>(connection);
        }
    }
}
