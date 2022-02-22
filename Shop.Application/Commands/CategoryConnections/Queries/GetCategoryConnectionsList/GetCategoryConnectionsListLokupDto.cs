using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.CategoryConnections.Queries.GetCategoryConnectionsList
{
    public class GetCategoryConnectionsListLokupDto
        : IMapWith<CategoryConnection>
    {

        public long Id { get; set; }
        public long ParentCategoryId { get; set; }
        public Category ChildCategory { get; set; }
        

        public void Mapping(Profile profile)
        {

            profile.CreateMap<CategoryConnection, GetCategoryConnectionsListLokupDto>()
                .ForMember(categoryConnectionVm => categoryConnectionVm.Id,
                    opt =>
                        opt.MapFrom(categoryConnection => categoryConnection.Id))
                .ForMember(categoryConnectionVm => categoryConnectionVm.ChildCategory,
                    opt =>
                        opt.MapFrom(categoryConnection =>
                            categoryConnection.Category))
                .ForMember(categoryConnectionVm => categoryConnectionVm.ParentCategoryId,
                    opt =>
                        opt.MapFrom(categoryConnection =>
                            categoryConnection.ParentId));
        }
    }
}
