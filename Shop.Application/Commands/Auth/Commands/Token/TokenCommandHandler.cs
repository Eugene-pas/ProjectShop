using AutoMapper;
using MediatR;
using Shop.Application.Commands.Auth.Commands.Login;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Auth.Commands.Token
{
    public class TokenCommandHandler
        : HandlersBase, IRequestHandler<LoginCommand, TokenVm>
    {
        public TokenCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public Task<TokenVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
