using System;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.ReviewComments.Queries.GetReviewCommentList
{
    public class ReviewCommentsLookupDto : IMapWith<ReviewComment>
    {
        public long Id { get; set; }

        public long ReviewId { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ReviewComment, ReviewCommentsLookupDto>()
                .ForMember(x => x.Id,
                   opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ReviewId,
                   opt => opt.MapFrom(x => x.Review.Id))
                .ForMember(x => x.CustomerId,
                   opt => opt.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.CustomerName,
                   opt => opt.MapFrom(x => x.Customer.Name))
                .ForMember(x => x.Comment,
                   opt => opt.MapFrom(x => x.Comment))
                .ForMember(x => x.CreationDate,
                   opt => opt.MapFrom(x => x.CreationDate));
        }
    }
}
