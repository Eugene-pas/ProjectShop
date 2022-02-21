using System.Collections.Generic;

namespace Shop.Application.Commands.Sellers.Queries.GetSellersList
{
    public class SellersListVm
    {
        public IList<SellersLookupDto> Sellers { get; set; }
    }
}
