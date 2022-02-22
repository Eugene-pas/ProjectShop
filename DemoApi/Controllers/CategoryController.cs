using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.Categories.Commands.CreateCategories;
using Shop.Application.Commands.Categories.Commands.DeleteCategories;
using Shop.Application.Commands.Categories.Commands.UpdateCategories;
using Shop.Application.Commands.Categories.Queries.GetCategory;
using Shop.Application.Commands.Categories.Queries.GetCategoryList;
using Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<CategoryVm> Create(string name, long parentId)
        {
            var category = await _mediator.Send(
                new CreateCategoryCommand
                {
                    Name = name,
                    ParentId = parentId
                }
            );
            return category;

        }

        [HttpGet("get")]
        public async Task<ActionResult<CategoryVm>> Get(long id)
        {
            return await _mediator.Send(new GetCategoryQuery { Id = id });
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<CategoriesListVm>> GetAll()
        {
            return await _mediator.Send(new GetCategoriesListQuery { });
        }

        [HttpPost("update")]
        public async Task<CategoryVm> Update(long categoryId, string name)
        {
            return await _mediator.Send(new UpdateCategoryCommand
            {
                CategoryId = categoryId,
                Name = name
            });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<CategoryVm>> Delete(long id)
        {
            return await _mediator.Send(new DeleteCategoryCommand { Id = id });
        }
    }
}
