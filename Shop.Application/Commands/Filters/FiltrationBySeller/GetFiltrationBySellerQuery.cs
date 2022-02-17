using MediatR;

namespace Shop.Application.Commands.Filters.FiltrationBySeller
{
    public class GetFiltrationBySellerQuery : IRequest<FilteredProductsListVm>
    {
        public long CategoryId { get; set; }

        public long SellerId { get; set; }
    }
}
