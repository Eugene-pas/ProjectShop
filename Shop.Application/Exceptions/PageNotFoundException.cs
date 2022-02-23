using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Exceptions
{
    public class PageNotFoundException : Exception
    {
        public PageNotFoundException(int pageNumber)
            : base($"Page\"{pageNumber}\" not found")
        {
        }
    }
}
