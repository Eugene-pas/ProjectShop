using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Queries.GetAllProducImage
{
    public class GetAllProductImageCommand
        : IRequest<string[]>
    {
        public long IdProduct { get; set; }       
    }
}
