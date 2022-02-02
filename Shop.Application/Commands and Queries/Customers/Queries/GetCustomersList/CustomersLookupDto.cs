using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Customers.Queries.GetCustomersList
{
    public class CustomersLookupDto : IMapWith<Customer>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomersLookupDto>()
                .ForMember(customerDto => customerDto.Id,
                    opt => opt.MapFrom(customer => customer.Id))
                .ForMember(customerDto => customerDto.Name,
                    opt => opt.MapFrom(customer => customer.Name))
                .ForMember(customerDto => customerDto.Email,
                    opt => opt.MapFrom(customer => customer.Email))
                .ForMember(customerDto => customerDto.PhoneNumber,
                    opt => opt.MapFrom(customer => customer.PhoneNumber));
        }
    }
}