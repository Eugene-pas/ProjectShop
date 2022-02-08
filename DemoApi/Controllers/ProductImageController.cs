using DemoApi.Models.ProductImageModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.ProductImages.Queries;
using Shop.Application.ProductImages.Commands.CreateProductImage;
using Shop.Application.ProductImages.Commands.DeleteProductImage;
using Shop.Application.ProductImages.Commands.UpdateProductImage;
using Shop.Application.ProductImages.Queries.GetProducImagesList;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DemoApi.FileSrvice;
using System;
using System.Linq;
using Syroot.Windows.IO;


namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController
    {
        private readonly IFileService _fileService;
        public ProductImageController(IMediator mediator, IFileService fileService) : base(mediator) 
        { 
            _fileService = fileService;
        }

        #region Upload  
        [HttpPost(nameof(Upload))]
        public IActionResult Upload([Required] List<IFormFile> formFiles)
        {
            string subDirectory = new KnownFolder(KnownFolderType.Downloads).Path;
            try
            {
                _fileService.UploadFile(formFiles, subDirectory);

                return Ok(new { formFiles.Count, Size = _fileService.SizeConverter(formFiles.Sum(f => f.Length)) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Download File  
        [HttpGet(nameof(Download))]
        public IActionResult Download([Required] string subDirectory)
        {

            try
            {
                var (fileType, archiveData, archiveName) = _fileService.DownloadFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

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
