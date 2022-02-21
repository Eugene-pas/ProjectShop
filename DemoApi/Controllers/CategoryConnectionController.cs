using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.CategoryConnections;
using Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection;
using Shop.Application.Commands.CategoryConnections.Commands.DeleteCategoryConnection;
using Shop.Application.Commands.CategoryConnections.Commands.UpdateCategoryConnection;
using Shop.Application.Commands.CategoryConnections.Queries.GetCategoryConnectionsList;
using System.Threading.Tasks;
using Shop.Application.Commands.CategoryConnections.Queries.GetSubcategoriesList;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryConnectionController : BaseController
    {
        public CategoryConnectionController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<CategoryConnectionVm> Create(long parentId,long childId)
        {
            return await _mediator.Send(
                new CreateCategoryConnectionCommand
                {
                    ParentId = parentId,
                    ChildId = childId
                });
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<GetCategoryConnectionsListVm>> GetAll()
        {
            return await _mediator.Send(new GetCategoryConnectionsListQuery { });
        }

        [HttpGet("getSubcategoriesList")]
        public async Task<ActionResult<SubcategoriesListVm>> GetAllSubcategories(long parentId)
        {
            return await _mediator.Send(new GetSubcategoriesListQuery {ParentId = parentId});
        }

        [HttpPost("update")]
        public async Task<CategoryConnectionVm> Update(long id, long parentId, long childId)
        {
            return await _mediator.Send(new UpdateCategoryConnectionCommand
            {
                Id = id,
                ParentId = parentId,
                ChildId = childId
            });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<CategoryConnectionVm>> Delete(long id)
        {
            return await _mediator.Send(new DeleteCategoryConnectionCommand { Id = id });
        }
    }
}
