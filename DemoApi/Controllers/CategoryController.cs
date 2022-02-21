using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Commands.CreateCategories;
using Shop.Application.Categories.Commands.DeleteCategories;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Application.Categories.Commands.UpdateCategories;
using Shop.Application.Categories.Queries.GetCategoryList;
using Shop.Application.Commands.CategoryConnections.Commands.CreateCategoryConnection;
using System.Threading.Tasks;

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
                    Name = name
                }
            );
            if (parentId != 0)
            {
                await _mediator.Send(new CreateCategoryConnectionCommand
                {
                    ParentId = parentId,
                    ChildId = category.Id
                });

            }
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
