using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.DeleteOrderProductConnections
{
    public class DeleteOrderProductConnectionsCommandValidator
    : AbstractValidator<DeleteOrderProductConnectionsCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteOrderProductConnectionsCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(deleteConnection =>
            deleteConnection.Id).NotEmpty().NotEqual(0)
                .WithMessage("The CategoryId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified OrderProductConnectionId doesn't exist.");

        }
        public async Task<bool> Exist(long OrderProductConnectionId, CancellationToken cancellationToken)
        {
            return await _dbContext.OrderProductConnection
                .AnyAsync(c => c.Id == OrderProductConnectionId);
        }
    }
}
