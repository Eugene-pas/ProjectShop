using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

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
                Category = _dbContext.Category.Find(request.ChildId)
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
                ChildCategory = connection.Category
            };
        } 
    }
}
