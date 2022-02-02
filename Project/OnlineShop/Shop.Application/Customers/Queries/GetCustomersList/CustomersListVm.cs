using System.Collections.Generic;

namespace Shop.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public IList<CustomersLookupDto> Customers { get; set; }
    }
}