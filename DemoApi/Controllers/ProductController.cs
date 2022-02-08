using DemoApi.Models.ProductModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.Products;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.Queries.GetProduct;
using Shop.Application.Products.Queries.GetProductsList;
using Shop.Domain.Entities;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<ProductVm> Create([FromBody] CreateProductModel product)
        {
            return await _mediator.Send(new CreateProductCommand
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                OnStorageCount = product.OnStorageCount,
                Rating = product.Rating,
            });
        }
        [HttpDelete("delete/{id}")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteProductCommand { Id = id });
        }
        [HttpPost("update")]
        public async Task<ProductVm> Update([FromBody] UpdateProductModel product)
        {
            return await _mediator.Send(new UpdateProductCommand
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                OnStorageCount = product?.OnStorageCount,
                Rating = product?.Rating,
            });
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ProductVm>> Get(long id)
        {
            return await _mediator.Send(new GetProductQuery { Id = id });
        }
        [HttpGet("getList")]
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {
            return await _mediator.Send(new GetProductsListQuery { });
        }
    }
}
