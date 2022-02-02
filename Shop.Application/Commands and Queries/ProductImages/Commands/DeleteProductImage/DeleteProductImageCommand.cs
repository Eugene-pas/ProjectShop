using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommand
        : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
