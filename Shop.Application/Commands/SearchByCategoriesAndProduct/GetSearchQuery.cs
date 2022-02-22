using MediatR;

namespace Shop.Application.Commands.SearchByCategoriesAndProduct
{
    public class GetSearchQuery : IRequest<SearchVm>
    {
        public string Serach { get; set; }
    }
}
