using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.ProductImages.Queries;
using Shop.Application.Commands_and_Queries.ProductImages.Queries.GetProductImageListForProduct;
using Shop.Application.ProductImages.Commands.CreateProductImage;
using Shop.Application.ProductImages.Commands.DeleteProductImage;
using Shop.Application.ProductImages.Queries.GetProducImagesList;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController
    {       
        public ProductImageController(IMediator mediator) : base(mediator)
        {           
        }

        [HttpPost("create")]

        public async Task<ActionResult<long>> CreateProductImage([Required] IFormFile formFiles, int sortOrder, long productId)
        {
            return Ok(await _mediator.Send(
            new CreateProductImageCommand
            {
                FormFiles = formFiles,
                SortOrder = sortOrder,
                ProductId = productId
            }));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteProductImage(long id)
        {

            return Ok(await _mediator.Send(new DeleteProductImageCommand { Id = id }));
        }

        [HttpGet("GetProductImagesList")]
        public async Task<ActionResult<ProductImageVm>> GetAllIdProductImage()
        {
            return await _mediator.Send(new GetProductImagesListQuery { });
        }

        [HttpGet("GetProductImagesListForProduct")]
        public async Task<ActionResult<ProductImageForProductVm>> GetAllIdProductImageForProduct(long productId)
        {
            return await _mediator.Send(new GetProductImagesListForPruductQuery { ProductId = productId });
        }

    }
}
