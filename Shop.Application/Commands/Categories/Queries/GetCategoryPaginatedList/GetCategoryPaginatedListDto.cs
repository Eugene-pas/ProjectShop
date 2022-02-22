using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Categories.Queries.GetCategoryPaginatedList
{
    public class GetCategoryPaginatedListDto
        : IMapWith<Category>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryPaginatedListDto>()
                .ForMember(CategoryVm => CategoryVm.Id,
                    opt => opt.MapFrom(category => category.Id))
                .ForMember(CategoryVm => CategoryVm.Name,
                    opt => opt.MapFrom(category => category.Name));
        }
    }
}
