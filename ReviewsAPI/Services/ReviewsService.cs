using AutoMapper;
using ReviewsAPI.DTO;
using ReviewsAPI.DTO.Review;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories.Interfaces;
using ReviewsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IMapper _mapper;
        public ReviewsService(IReviewsRepository reviewsRepository, IMapper mapper)
        {
            _reviewsRepository = reviewsRepository ?? throw new ArgumentNullException(nameof(reviewsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// Changes review status to Confirmed asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ConfirmReviewAsync(long id)
        {
            await _reviewsRepository.SetConfirmedAsync(id);
        }
        /// <summary>
        /// Adds review to the database asynchronously
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public async Task<long> CreateAsync(ReviewCreateDto reviewDto)
        {
            Review review = _mapper.Map<Review>(reviewDto);
            return await _reviewsRepository.CreateAsync(review);
        }
        /// <summary>
        /// Deletes review from database asynchronously
        /// </summary>
        /// <param name="id">Id of review to delete</param>
        /// <returns></returns>
        public async Task DeleteAsync(long id)
        {
            var review = await _reviewsRepository.GetByIdAsync(id);
            if (review == null)
            {
                throw new ArgumentException($"User with id {id} could not be found", nameof(id));
            }
            await _reviewsRepository.DeleteAsync(review);
        }
        /// <summary>
        /// Returns all reviews from database
        /// </summary>
        /// <returns>IEnumerable of reviews</returns>
        public async Task<IEnumerable<ReviewDto>> GetAllReviews()
        {
            var reviews = await _reviewsRepository.GetAllReviewsWithUser();

            return reviews.Select(r => _mapper.Map<ReviewDto>(r));

        }
        /// <summary>
        /// Returns review by given id
        /// </summary>
        /// <param name="id">Id of review to return</param>
        /// <returns>Review object</returns>
        public async Task<ReviewDto> GetByIdAsync(long id)
        {
            Review review = await _reviewsRepository.GetSingleReviewWithUser(id);
            return _mapper.Map<ReviewDto>(review);
        }
        /// <summary>
        /// Returns review by given status
        /// </summary>
        /// <param name="status">status od reviews to return</param>
        /// <returns>IEnumerable of reviews</returns>
        public async Task<IEnumerable<ReviewDto>> GetReviewsByStatus(string status)
        {
            if (!Enum.IsDefined(typeof(ReviewStatus),status))
            {
                throw new ArgumentException(nameof(status));
            }
            IEnumerable<Review> reviews = await _reviewsRepository
                .GetByCondition(r => r.Status.ToString()
                .ToLowerInvariant() == status.ToLowerInvariant());

            return reviews.Select(r => _mapper.Map<ReviewDto>(r));
        }
        /// <summary>
        /// Updates review data asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <param name="review">Updated review</param>
        /// <returns></returns>
        public async Task UpdateAsync(long id, ReviewUpdateDto reviewDto)
        {
            // Map from DTO

            Review review = await _reviewsRepository.GetByIdAsync(id);
            
            review.Model = reviewDto.Model;
            review.Text = reviewDto.Text;
            review.Pros = reviewDto.Pros;
            review.Cons = reviewDto.Cons;
            review.IsRecommended = reviewDto.IsRecommended;
            await _reviewsRepository.UpdateAsync(review);
        }
    }
}
