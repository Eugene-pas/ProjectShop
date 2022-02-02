using System.Collections.Generic;

namespace Shop.Application.Sellers.Queries.GetSellerList
{
    public class SellerListVm
    {
        public IList<SellerLookupDto> Sellers { get; set; }
    }
}
