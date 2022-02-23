using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Sellers.Queries.GetSeller
{
    public class SellerVm : IMapWith<Seller>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seller, SellerVm>()
                .ForMember(SellerVm => SellerVm.Id, 
                   opt => opt.MapFrom(Seller => Seller.Id))
                .ForMember(SellerVm => SellerVm.Name, 
                   opt => opt.MapFrom(Seller => Seller.StoreName))
                .ForMember(SellerVm => SellerVm.Description, 
                   opt => opt.MapFrom(Seller => Seller.Description))
                .ForMember(SellerVm => SellerVm.Contact, 
                   opt => opt.MapFrom(Seller => Seller.Contact));
                
        }
    }
}
