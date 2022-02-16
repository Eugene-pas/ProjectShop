using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.SearchByCategoriesAndProduct
{
    public class GetSearchQuery : IRequest<SearchVm>
    {
        public string Serach { get; set; }
    }
}
