using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Commands.CreateCategories;
using Shop.Application.Categories.Commands.DeleteCategories;
using Shop.Application.Categories.Commands.Queries.GetCategory;
using Shop.Application.Categories.Commands.UpdateCategories;
using Shop.Application.Categories.Queries.GetCatagoryList;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            return await _mediator.Send(
            new CreateCategoryCommand
            {
                Name = name,
                ParentId = parentId
            });
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
        public async Task<CategoryVm> Update(string name, long parentId)
        {
            return await _mediator.Send(new UpdateCategoryCommand
            {
                Name = name,
                ParentId = parentId
            });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<CategoryVm>> Delete(long id)
        {
            return await _mediator.Send(new DeleteCategoryCommand { Id = id });
        }
    }
}
