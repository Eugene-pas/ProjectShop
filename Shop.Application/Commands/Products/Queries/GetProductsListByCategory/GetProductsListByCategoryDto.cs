using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Application.Commands.Reviews.Queries;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryDto
        : IMapWith<Product>
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public long SellerId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

        public int? OnStorageCount { get; set; }

        public virtual ICollection<Review> Review { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductsListByCategoryDto>()
                .ForMember(productVm => productVm.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(productVm => productVm.CategoryId,
                    opt => opt.MapFrom(product => product.Category.Id))
                .ForMember(productVm => productVm.SellerId,
                    opt => opt.MapFrom(product => product.Seller.Id))
                .ForMember(productVm => productVm.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Rating,
                    opt => opt.MapFrom(product =>
                        Math.Round((double)product.Review.Sum(x => x.Rating) / (product.Review.Count == 0 ? 1 : product.Review.Count), 1)))
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
