using System.Collections.Generic;

namespace Shop.Application.Sellers.Queries.GetSellerList
{
    public class SellersListVm
    {
        public IList<SellersLookupDto> Sellers { get; set; }
    }
}
