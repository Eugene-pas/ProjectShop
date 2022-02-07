using DemoApi.Models.ProductImageModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.ProductImages.Queries;
using Shop.Application.ProductImages.Commands.CreateProductImage;
using Shop.Application.ProductImages.Commands.DeleteProductImage;
using Shop.Application.ProductImages.Commands.UpdateProductImage;
using Shop.Application.ProductImages.Queries.GetProducImagesList;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController
    {
        public ProductImageController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<ActionResult<long>> CreateProductImage([FromBody] ProductImageModel customer)
        {
            return Ok(await _mediator.Send(
                new CreateProductImageCommand
                {
                    Image = customer.Image,
                    SortOrder = customer.SortOrder,
                    ProductId = customer.ProductId                    
                }));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteProductImage([FromBody] ProductImageModel id)
        {
            return Ok(await _mediator.Send(new DeleteProductImageCommand { Id = id.Id }));
        }

        [HttpPut("update")]
        public async Task<Unit> UpdateProductImage([FromBody] ProductImageModel productImage)
        {
            return await _mediator.Send(
                new UpdateProductImageCommand
                {
                    Id = productImage.Id,
                    Image = productImage.Image,
                    SortOrder = productImage.SortOrder,
                    ProductId = productImage.ProductId
                });
        }

        [HttpGet("GetProductImagesList")]
        public async Task<ActionResult<ProductImageVm>> GetAllIdProductImage()
        {
            return await _mediator.Send(new GetProductImagesListQuery { });
        }

    }
}
