
using DemoApi.Models;
using DemoApi.Models.ProductImageModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductImages.Commands.CreateProductImage;
using Shop.Application.ProductImages.Commands.DeleteProductImage;
using Shop.Application.ProductImages.Commands.UpdateProductImage;
using Shop.Application.ProductImages.Queries.GetAllProducImage;
using System;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController
    {
        public ProductImageController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<ActionResult<long>> CreateProductImage([FromBody] CreateProductImageModel customer)
        {
            return Ok(await _mediator.Send(
                new CreateProductImageCommand
                {
                    Image = customer.Image,
                    SortOrder = customer.SortOrder
                }));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteProductImage([FromBody] DeleteProductImageModel id)
        {
            return Ok(await _mediator.Send(new DeleteProductImageCommand { Id = id.Id }));
        }

        [HttpPut("update")]
        public async Task<Unit> UpdateProductImage([FromBody] UpdateProductImageModel productImage)
        {
            return await _mediator.Send(
                new UpdateProductImageCommand
                {
                    Id = productImage.Id,
                    Image = productImage.Image,
                    SortOrder = productImage.SortOrder,
                    Product = null
                });
        }

        [HttpPost("GetProductImageList")]
        public async Task<string[]> GetAllIdProductImage([FromBody] GetAllIdProductImageModel productImage)
        {
            return await _mediator.Send(
                new GetAllProductImageCommand
                {
                    IdProduct = productImage.Id
                });
        }

    }
}
