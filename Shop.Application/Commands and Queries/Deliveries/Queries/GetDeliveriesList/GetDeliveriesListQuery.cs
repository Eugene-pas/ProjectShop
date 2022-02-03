using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Queries.GetDeliveriesList
{
    public class GetDeliveriesListQuery : IRequest<DeliveriesListVm>
    {
    }
}
