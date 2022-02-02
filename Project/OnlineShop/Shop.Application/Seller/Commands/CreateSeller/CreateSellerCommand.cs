using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Shop.Application.Seller.Commands.CreateSeller
{
    internal class DeleteSellerCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; } 

    }
}
