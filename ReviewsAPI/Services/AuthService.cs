using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReviewsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using ReviewsAPI.Models;
using ReviewsAPI.DTO;
using ReviewsAPI.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;

namespace ReviewsAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthService(IUsersRepository usersRepository,IConfiguration config, SignInManager<User> signInManager, IMapper mapper, UserManager<User> userManager)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        /// <summary>
        /// Logs in user by returning a jwt token
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>JWT token</returns>
        public async Task<string> AuthenticateUser(UserLoginDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
                throw new ArgumentNullException("email or password is empty");

            User user = await AuthenticateCredentials(userDto.Email, userDto.Password);

            if (user == null)
                throw new ArgumentException("password and/or password is invalid");

            string jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? _config["Jwt:Key"];
            string token = GenerateJwtToken(user, jwtSecret);

            return token;

        }
        /// <summary>
        /// Generates JWT token
        /// </summary>
        /// <param name="user">user to encode</param>
        /// <param name="secret">secret key for token generation</param>
        /// <returns>JWT token</returns>
        private string GenerateJwtToken(User user, string secret)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                // data which is encoded to the token
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Checks if user with given email exists and password is correct
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <returns>
        ///     user object if credentials are valid
        ///     null if credentials are invalid
        ///     exception if user does not exist
        /// </returns>
        private async Task<User> AuthenticateCredentials(string email, string password)
        {       
            User user = await _usersRepository.GetByConditionSingleAsync(u => u.Email == email);
            if (user == null)
                throw new Exception("user not found");
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user,user.Password,password);
            if (result.ToString() == "Success")
                return user;
            return null;
        }
        /// <summary>
        /// Adds new user to the database
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task<UserDto> CreateUser(UserRegisterDto userDto)
        {
            User user = await _usersRepository.GetByConditionSingleAsync(u => u.Email == userDto.Email);
            if (user != null)
                throw new ArgumentException("user already exists");

            //map userdto to user
            User newUser = _mapper.Map<User>(userDto);
 
            newUser.Password = _userManager.PasswordHasher.HashPassword(newUser, userDto.Password1);

            await _usersRepository.CreateAsync(newUser);

            return _mapper.Map<UserDto>(newUser);
        }
    }
}
