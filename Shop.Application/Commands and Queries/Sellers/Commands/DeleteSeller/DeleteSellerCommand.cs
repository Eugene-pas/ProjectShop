using MediatR;
using System;

namespace Shop.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
    }
}
