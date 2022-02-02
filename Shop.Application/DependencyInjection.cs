﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public static class DependencyInjection
    {
        // регістрація для медіатора
        public static IServiceCollection AddApplication(
            this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
            return service;
        }
    }
}
