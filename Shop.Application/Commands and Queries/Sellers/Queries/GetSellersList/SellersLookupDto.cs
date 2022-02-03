using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Sellers.Queries.GetSellersList
{
    public class SellersLookupDto : IMapWith<Seller>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seller, SellersLookupDto>()
                .ForMember(sellerDto => sellerDto.Id,
                opt => opt.MapFrom(seller => seller.Id))
                .ForMember(sellerDto => sellerDto.Name,
                opt => opt.MapFrom(seller => seller.Name))
                 .ForMember(sellerDto => sellerDto.Description,
                opt => opt.MapFrom(seller => seller.Description))
                 .ForMember(sellerDto => sellerDto.Contact,
                opt => opt.MapFrom(seller => seller.Contact));
        }
    }
}
