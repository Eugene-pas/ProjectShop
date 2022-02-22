using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Application.Commands.SearchByCategoriesAndProduct;

namespace DemoApi.Controllers
{
    public class SearchController
    : BaseController
    {
        public SearchController(IMediator mediator) : base(mediator) { }

        [HttpGet("Search")]
        public async Task<SearchVm> Create(string search)
        {
            return await _mediator.Send(new GetSearchQuery
            {
                Serach = search,
            });
        }
    }
}
