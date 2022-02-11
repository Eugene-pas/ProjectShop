using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommand 
        : IRequest<long>
    {              
        public int? SortOrder { get; set; }
        public long ProductId { get; set; }
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]       
        public IFormFile FormFiles { get; set; }       

        public virtual Product Product { get; set; }

    }
}
