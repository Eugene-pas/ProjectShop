using System;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewLikes.Queries.GetReviewLikesForReview
{
    public class ReviewLikesLookupDto
                 : IMapWith<ReviewLike>
    {
        public long Id { get; set; }

        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public bool IsLike { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReviewLike, ReviewLikesLookupDto>()
                .ForMember(x => x.Id,
                   opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.ReviewId,
                   opt => opt.MapFrom(x => x.Review.Id))
                .ForMember(x => x.CustomerId,
                   opt => opt.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.IsLike,
                   opt => opt.MapFrom(x => x.IsLike));
        }
    }
}
