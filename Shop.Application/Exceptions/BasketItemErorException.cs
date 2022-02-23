using FluentValidation.Results;
using System;

namespace Shop.Application.Exceptions
{
    public class BasketItemErorException : Exception
    {
        public BasketItemErorException()
            : base($"Basket item eror exception")
        {}
    }
}