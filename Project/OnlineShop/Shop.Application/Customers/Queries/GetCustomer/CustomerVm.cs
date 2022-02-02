using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomer
{
    public class CustomerVm : IMapWith<Customer>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerVm>()
                .ForMember(customerVm => customerVm.Id,
                    opt => opt.MapFrom(customer => customer.Id))
                .ForMember(customerVm => customerVm.Name,
                    opt => opt.MapFrom(customer => customer.Name))
                .ForMember(customerVm => customerVm.Email,
                    opt => opt.MapFrom(customer => customer.Email))
                .ForMember(customerVm => customerVm.PhoneNumber,
                    opt => opt.MapFrom(customer => customer.PhoneNumber)); 
        }
    }
}
