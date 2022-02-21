using MediatR;

namespace Shop.Application.Commands.Sellers.Queries.GetSeller
{
    public class GetSellerQuery : IRequest<SellerVm>
    {
        public long Id { get; set; }
    }
}
