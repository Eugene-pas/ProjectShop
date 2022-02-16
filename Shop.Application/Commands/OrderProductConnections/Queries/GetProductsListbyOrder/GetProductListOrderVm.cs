using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderVm
    {
        public IList<GetProductListOrderLookupDto> OrderProductConnection { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
