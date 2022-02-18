using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.OrderProductConnections.Queries;

namespace Shop.Application.Commands.CategoryConnections.Commands.DeleteCategoryConnection
{
    public class DeleteCategoryConnectionHandler
        : HandlersBase, IRequestHandler<DeleteCategoryConnectionCommand, CategoryConnectionVm>
    {
        public DeleteCategoryConnectionHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CategoryConnectionVm> Handle(DeleteCategoryConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.CategoryConnection
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(CategoryConnection), connection.Id);

            _dbContext.CategoryConnection.Remove(connection);
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
