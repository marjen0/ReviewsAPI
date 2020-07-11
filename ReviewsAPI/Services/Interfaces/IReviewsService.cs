using ReviewsAPI.DTO;
using ReviewsAPI.DTO.Review;
using ReviewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Services.Interfaces
{
    public interface IReviewsService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsByStatus(string status);
        Task<IEnumerable<ReviewDto>> GetAllReviews();
        Task<ReviewDto> GetByIdAsync(long id);
        Task<long> CreateAsync(ReviewCreateDto reviewDto);
        Task DeleteAsync(long id);
        Task UpdateAsync(long id, ReviewUpdateDto review);
        Task ConfirmReviewAsync(long id);
        
        
    }
}
