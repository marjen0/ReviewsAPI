using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Data;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories;
using ReviewsAPI.Repositories.Interfaces;

namespace ReviewsAPI.Repositories
{
    public class ReviewsRepository : GenericRepository<Review>, IReviewsRepository
    {
        private readonly ReviewsContext _context;

        public ReviewsRepository(ReviewsContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Review>> GetAllReviewsWithUser()
        {
            return await _context.Reviews
                .AsNoTracking()
                .Include(review => review.RegularUser)
                .ToListAsync();
        }
        public async Task<IEnumerable<Review>> GetReviewsByStatusAsync(string status)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(r => status == "unconfirmed"? r.AdminId == null: r.AdminId != null)
                .ToListAsync();
        }

        public async Task SetConfirmedAsync(long id)
        {
            var review = await GetByIdAsync(id);
            review.AdminId = 2;
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserAsync(long id)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Where(r => r.RegularUserId == id)
                .Include(review => review.RegularUser)
                .ToListAsync();
        }

        public async Task<Review> GetSingleReviewWithUser(long id)
        {
            return await _context.Reviews
                .AsNoTracking()
                .Include(r => r.RegularUser)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
