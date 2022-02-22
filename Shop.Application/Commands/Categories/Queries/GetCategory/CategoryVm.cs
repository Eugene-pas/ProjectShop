using System.Collections.Generic;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Categories.Queries.GetCategory
{
    public class CategoryVm 
        : IMapWith<Category>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryVm>()
                .ForMember(categoryVm => categoryVm.Id,
                    opt => opt.MapFrom(category => category.Id))
                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))
                .ForMember(categoryVm => categoryVm.Product,
                opt => opt.MapFrom(category => category.Product));
        }
    }
}
