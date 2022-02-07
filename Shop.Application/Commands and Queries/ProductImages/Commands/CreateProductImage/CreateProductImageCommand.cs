using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommand 
        : IRequest<long>
    {       
        public string Image { get; set; }
        public int? SortOrder { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
