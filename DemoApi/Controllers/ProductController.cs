using DemoApi.Models.ProductModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.Filters;
using Shop.Application.Commands.Filters.FiltrationByRating;
using Shop.Application.Commands.Filters.FiltrationBySeller;
using Shop.Application.Commands.Products;
using Shop.Application.Commands.Products.Commands.CreateProduct;
using Shop.Application.Commands.Products.Commands.DeleteProduct;
using Shop.Application.Commands.Products.Commands.UpdateProduct;
using Shop.Application.Commands.Products.Queries.GetProduct;
using Shop.Application.Commands.Products.Queries.GetProductsListByPrice;
using Shop.Application.Commands.Products.Queries.GetProductsListByRating;
using Shop.Application.Products.Queries.GetProductsList;
using System.Threading.Tasks;
using Shop.Application.Commands.Filters.FiltrationByPrice;

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
                CategoryId = product.CategoryId,
                OnStorageCount = product.OnStorageCount,
                Rating = product.Rating,
                SellerId = product.SellerId
            });
        }

        [HttpDelete("delete/{id:long}")]
        public async Task<ProductVm> Delete(long id)
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
                OnStorageCount = product.OnStorageCount,
                Rating = product.Rating
            });
        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<ProductVm>> Get(long id)
        {
            return await _mediator.Send(new GetProductQuery { Id = id });
        }

        [HttpGet("getList")]
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {
            return await _mediator.Send(new GetProductsListQuery());
        }

        [HttpGet("getSortListByPrice")]
        public async Task<ActionResult<ProductsListVm>> GetAllByPrice(long categoryId)
        {
            return await _mediator.Send(new GetProductsListByPriceQuery { CategoryId = categoryId});
        }

        [HttpGet("getSortListByRating")]
        public async Task<ActionResult<ProductsListVm>> GetAllByRating(long categoryId)
        {
            return await _mediator.Send(new GetProductsListByRatingQuery {CategoryId = categoryId});
        }
        
        [HttpGet("filterByRating")]
        public async Task<ActionResult<FilteredProductsListVm>> GetFilterByRating(long categoryId, int rating)
        {
            return await _mediator.Send(new GetFiltrationByRatingQuery { CategoryId = categoryId, Rating = rating });
        }

        [HttpGet("filterBySeller")]
        public async Task<ActionResult<FilteredProductsListVm>> GetFilterBySeller(long categoryId, long sellerId)
        {
            return await _mediator.Send(new GetFiltrationBySellerQuery
                { CategoryId = categoryId, SellerId = sellerId });
        }

        [HttpGet("filterByPrice")]
        public async Task<ActionResult<FilteredProductsListVm>> GetFilterByPrice(long categoryId, decimal minPrice, decimal maxPrice)
        {
            return await _mediator.Send(new GetFiltrationByPriceQuery
                { CategoryId = categoryId, MinPrice = minPrice, MaxPrice = maxPrice});
        }
    }
}
