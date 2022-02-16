using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderQuery : IRequest<GetProductListOrderVm>
    {
        public long OrderId { get; set; }
    }
}
