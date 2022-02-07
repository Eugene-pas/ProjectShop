using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries
{
    public class ProductImageLookupDto
        : IMapWith<ProductImage>
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public int? SortOrder { get; set; }

        public virtual Product Product { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductImage, ProductImageLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Image,
                opt => opt.MapFrom(x => x.Image))
                .ForMember(x => x.SortOrder,
                opt => opt.MapFrom(x => x.SortOrder))
                .ForMember(x => x.Product,
                opt => opt.MapFrom(x => x.Product));               
        }
    }
}
