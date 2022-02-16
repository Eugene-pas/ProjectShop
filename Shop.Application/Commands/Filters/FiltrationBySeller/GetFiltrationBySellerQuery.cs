using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.Commands.Filters.FiltrationBySeller
{
    public class GetFiltrationBySellerQuery : IRequest<FilteredProductsListVm>
    {
    }
}
