using System;
using System.Collections.Generic;
using AutoMapper;
using Shop.Application.Commands.ReviewComments.Queries;
using Shop.Application.Commands.ReviewLikes.Queries;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Reviews.Queries
{
    public class ReviewsVm : IMapWith<Review>
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual IList<ReviewCommentVm> ReviewComments { get; set; }

        public virtual IList<ReviewLikeVm> ReviewLikes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewsVm>()
                .ForMember(x => x.Id,
                   opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ProductId,
                   opt => opt.MapFrom(x => x.Product.Id))
                .ForMember(x => x.CustomerId,
                   opt => opt.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.CustomerName,
                   opt => opt.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.Rating,
                   opt => opt.MapFrom(x => x.Rating))
                .ForMember(x => x.CreationDate,
                   opt => opt.MapFrom(x => x.CreationDate))
                .ForMember(x => x.Comment,
                   opt => opt.MapFrom(x => x.Comment))
                .ForMember(x => x.ReviewComments,
                   opt => opt.MapFrom(x => x.ReviewComments))
                .ForMember(x => x.ReviewLikes,
                   opt => opt.MapFrom(x => x.ReviewLikes));
        }
    }
}
