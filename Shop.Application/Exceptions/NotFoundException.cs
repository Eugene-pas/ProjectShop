using System;

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


