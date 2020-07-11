using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReviewsAPI.Models;
using ReviewsAPI.DTO.Review;

namespace ReviewsAPI.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>().AfterMap((source, dest) =>
            {
                dest.Id = source.Id;
                dest.Cons = source.Cons;
                dest.CreatedAt = source.CreatedAt.GetValueOrDefault(DateTime.Now);
                dest.CreatedBy = source.RegularUser.Email;
                dest.Text = source.Text;
                dest.Model = source.Model;
                dest.Pros = source.Pros;
                dest.IsRecommended = source.IsRecommended;

            });
            CreateMap<ReviewCreateDto, Review>().AfterMap((source, dest) =>
            {
                dest.IsRecommended = source.IsRecommended;
                dest.Model = source.Model;
                dest.Pros = source.Pros;
                dest.Cons = source.Cons;
                dest.Text = source.Text;
                dest.Status = ReviewStatus.NotConfirmed;
                dest.RegularUserId = 14;//currentUser.Id               // FAKE USER | FIX THIS
            });
        }
    }
}
