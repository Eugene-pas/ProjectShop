using MediatR;
using Shop.Application.Sellers.Queries.GetSeller;

namespace Shop.Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommand : IRequest<SellerVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }

    }
}
