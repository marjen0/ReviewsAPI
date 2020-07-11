using System;
using System.Collections.Generic;
using System.Linq;
using ReviewsAPI.DTO;
using System.Threading.Tasks;
using ReviewsAPI.Models;

namespace ReviewsAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> CreateUser(UserRegisterDto userDto);
        Task<string> AuthenticateUser(UserLoginDto userDto);
        
    }
}
