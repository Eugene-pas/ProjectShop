using MediatR;
using Shop.Application.Sellers.Queries.GetSeller;
using System;

namespace Shop.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommand : IRequest<SellerVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
    }
}
