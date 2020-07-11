using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReviewsAPI.DTO;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories.Interfaces;
using ReviewsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ReviewsAPI.DTO.Review;

namespace ReviewsAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IReviewsRepository _reviewsRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository, IReviewsRepository reviewsRepository, UserManager<User> userManager, IMapper mapper)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _reviewsRepository = reviewsRepository ?? throw new ArgumentNullException(nameof(reviewsRepository));
            _userManager = userManager ?? throw new ArgumentException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        
        /// <summary>
        /// Adds new user to the database asynchronously
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateAsync(User user)
        {
            await _usersRepository.CreateAsync(user);
        }
        /// <summary>
        /// Returns all users from the database asynchronously
        /// </summary>
        /// <returns>IEnuerable of users</returns>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _usersRepository.GetAll();
            return users.Select(u => _mapper.Map<UserDto>(u));
        }
        /// <summary>
        /// Returns reviews by single user asynchronously
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns><list type="of reviews"</returns>
        public async Task<IEnumerable<ReviewDto>> GetReviewsByUserAsync(long id)
        {
            IEnumerable<Review> reviews = await _reviewsRepository.GetReviewsByUserAsync(id);
            return reviews.Select(r => _mapper.Map<ReviewDto>(r));
        }
        /// <summary>
        /// Returns single user by email asynchronously
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User object</returns>
        public async Task<User> GetUserByEmailAddressAsync(string email)
        {
            IEnumerable<User> users = await _usersRepository.GetByCondition(u => u.Email == email);
            return users.First();
        }
        /// <summary>
        /// Returns user by given id asynchronously
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User object</returns>
        public async Task<UserDto> GetUserByIdAsync(long id)
        {
            User user = await _usersRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

    }
}
