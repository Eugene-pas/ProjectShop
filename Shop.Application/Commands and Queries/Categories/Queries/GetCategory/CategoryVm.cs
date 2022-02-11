using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Commands.Queries.GetCategory
{
    public class CategoryVm 
        : IMapWith<Category>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }       


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryVm>()
                .ForMember(categoryVm => categoryVm.Id,
                    opt => opt.MapFrom(category => category.Id))
                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))
                .ForMember(categoryVm => categoryVm.ParentCategory,
                opt => opt.MapFrom(category => category.ParentCategory));


        }
    }
}
