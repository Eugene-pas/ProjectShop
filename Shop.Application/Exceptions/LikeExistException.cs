using FluentValidation.Results;
using System;

namespace Shop.Application.Exceptions
{
    public class LikeExistException : Exception
    {
        public LikeExistException()
            : base($"Like exist")
        {}
    }
}