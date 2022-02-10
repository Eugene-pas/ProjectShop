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
        //public NotFoundException()
        //    : base("One or more validation failures have occurred.")
        //{
        //    Failures = new Dictionary<string, string[]>();
        //}
        //public NotFoundException(List<ValidationFailure> failures)
        //    : this()
        //{
        //    var propertyNames = failures
        //        .Select(e => e.PropertyName)
        //        .Distinct();
        //    foreach (var propertyName in propertyNames)
        //    {
        //        var propertyFailures = failures
        //            .Where(e => e.PropertyName == propertyName)
        //            .Select(e => e.ErrorMessage)
        //            .ToArray();

        //        Failures.Add(propertyName, propertyFailures);
        //    }
        //}
        //public IDictionary<string, string[]> Failures { get; }
    }

}


