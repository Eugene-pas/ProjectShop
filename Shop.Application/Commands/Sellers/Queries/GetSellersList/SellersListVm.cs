using System.Collections.Generic;

namespace Shop.Application.Sellers.Queries.GetSellersList
{
    public class SellersListVm
    {
        public IList<SellersLookupDto> Sellers { get; set; }
    }
}
