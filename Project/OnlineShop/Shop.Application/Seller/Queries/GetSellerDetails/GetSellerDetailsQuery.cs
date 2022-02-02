using MediatR;

namespace Shop.Application.Seller.Queries.GetSellerDetails
{
    public class GetSellerDetailsQuery : IRequest<SellerDetailsVm>
    {
        public long Id { get; set; }
    }
}
