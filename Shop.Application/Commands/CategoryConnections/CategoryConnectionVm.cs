using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Common;

namespace Shop.Application.Commands.CategoryConnections
{
    public class CategoryConnectionVm
        //: IMapWith<CategoryConnection>
    {

        public long Id { get; set; }
        public Category ParentCategory { get; set; }
        public Category ChildCategory { get; set; }
        public Category ParentCategoryId { get; set; }

        //public void Mapping(Profile profile)
        //{

        //    profile.CreateMap<CategoryConnection, CategoryConnectionVm>()
        //        .ForMember(categoryConnectionVm => categoryConnectionVm.Id,
        //            opt =>
        //                opt.MapFrom(categoryConnection => categoryConnection.Id))
        //        .ForMember(categoryConnectionVm => categoryConnectionVm.ChildCategory,
        //            opt =>
        //                opt.MapFrom(categoryConnection =>
        //                    categoryConnection.Child))
        //        .ForMember(categoryConnectionVm => categoryConnectionVm.ParentCategoryId,
        //        opt =>
        //            opt.MapFrom(categoryConnection =>
        //                categoryConnection.ParentId));
        //}
    }
}