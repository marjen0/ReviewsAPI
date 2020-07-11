using ReviewsAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Repositories.Interfaces
{
    public interface IReviewsRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByStatusAsync(string status);
        Task SetConfirmedAsync(long id);
        Task<IEnumerable<Review>> GetReviewsByUserAsync(long id);
        Task<IEnumerable<Review>> GetAllReviewsWithUser();
        Task<Review> GetSingleReviewWithUser(long id);
    }
}
