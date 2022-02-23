using AutoMapper;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Commands.Products
{
    public class ProductVm : IMapWith<Product>
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public long SellerId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int? OnStorageCount { get; set; }

        public double Rating { get; set; }

        public virtual IList<ReviewsVm> Review { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>()
                .ForMember(productVm => productVm.Id,
                   opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.CategoryId,
                    opt => opt.MapFrom(product => product.Category.Id))
                .ForMember(productVm => productVm.SellerId,
                    opt => opt.MapFrom(product => product.Seller.Id))
                .ForMember(productVm => productVm.Name,
                   opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Rating,
                    opt => opt.MapFrom(product => Math.Round((double)product.Review
                                                      .Sum(x => x.Rating) / product.Review.Count, 1)))
                .ForMember(productVm => productVm.Price,
                    opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Description,
                    opt => opt.MapFrom(product => product.Description))
                .ForMember(productVm => productVm.OnStorageCount,
                    opt => opt.MapFrom(product => product.OnStorageCount))
                .ForMember(x => x.Review,
                   opt => opt.MapFrom(x => x.Review));
        }
    }
}
