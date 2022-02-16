using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.SearchByCategoriesAndProduct;
using System.Threading.Tasks;

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
