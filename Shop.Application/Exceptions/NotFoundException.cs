using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, Object key)
            : base($"Entity\"{name}\" ({key}) not found") 
        {            
        }
    }

}


