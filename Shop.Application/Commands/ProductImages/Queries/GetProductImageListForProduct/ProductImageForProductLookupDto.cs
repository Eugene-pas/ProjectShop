﻿using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImageListForProduct
{
    public class ProductImageForProductLookupDto
        : IMapWith<ProductImage>
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public int? SortOrder { get; set; }

        public virtual Product Product { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductImage, ProductImageForProductLookupDto>()
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
