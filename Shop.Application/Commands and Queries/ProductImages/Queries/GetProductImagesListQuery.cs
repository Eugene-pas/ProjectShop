using MediatR;
using Shop.Application.Commands_and_Queries.ProductImages.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Queries.GetProducImagesList
{
    public class GetProductImagesListQuery
        : IRequest<ProductImageVm>
    {             
    }
}
