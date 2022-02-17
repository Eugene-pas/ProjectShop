using System;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Reviews.Queries.GetReviewsList
{
    public class ReviewsLookupDto : IMapWith<Review>
    {
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public DateTime Created { get; set; }

        public long ProductId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewsLookupDto>()
                .ForMember(x => x.Id,
                   opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.CustomerName,
                   opt => opt.MapFrom(x => x.CustomerName))
                .ForMember(x => x.Rating,
                   opt => opt.MapFrom(x => x.Rating))
                .ForMember(x => x.Comments,
                   opt => opt.MapFrom(x => x.Comments))
                .ForMember(x => x.Created,
                   opt => opt.MapFrom(x => x.Created))
                .ForMember(x => x.ProductId,
                   opt => opt.MapFrom(x => x.Product.Id));
        }
    }
}
