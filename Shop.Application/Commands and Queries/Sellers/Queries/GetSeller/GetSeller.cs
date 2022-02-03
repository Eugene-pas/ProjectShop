using MediatR;

namespace Shop.Application.Sellers.Queries.GetSellerDetails
{
    public class GetSeller : IRequest<SellerVm>
    {
        public long Id { get; set; }
    }
}
