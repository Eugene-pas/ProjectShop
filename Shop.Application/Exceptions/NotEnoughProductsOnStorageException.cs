using System;

namespace Shop.Application.Exceptions
{
    public class NotEnoughProductsOnStorageException : Exception
    {
        public NotEnoughProductsOnStorageException(object name, object count)
            : base($"Not enough Product \"{name}\" on storage. We have only <{count}>")
        { }
    }
}
