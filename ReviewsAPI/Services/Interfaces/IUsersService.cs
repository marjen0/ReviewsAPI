using ReviewsAPI.DTO;
using ReviewsAPI.DTO.Review;
using ReviewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Services.Interfaces
{
    public interface IUsersService
    {
        Task<UserDto> GetUserByIdAsync(long id);

        Task<User> GetUserByEmailAddressAsync(string email);
        Task CreateAsync(User user);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<ReviewDto>> GetReviewsByUserAsync(long id);
        
    }
}
