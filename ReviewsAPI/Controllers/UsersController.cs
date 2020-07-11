using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReviewsAPI.DTO;
using ReviewsAPI.DTO.Review;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories.Interfaces;
using ReviewsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IReviewsService _reviewsService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UsersController(IUsersService usersService, IReviewsService reviewsService, UserManager<User> userManager, IMapper mapper)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _reviewsService = reviewsService ?? throw new ArgumentNullException(nameof(reviewsService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            IEnumerable<UserDto> usersDto = await _usersService.GetAllUsersAsync();

            if (usersDto == null || usersDto.Count() == 0)
            {
                return NotFound(new { message = "users could not be found" });
            }
            else
            {
                return Ok(usersDto); 
            }
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> GetUser([FromRoute] long id)
        {
            UserDto user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = $"user with id {id} could not be found" });
            }
            else
            {
                return Ok(user); 
            }
        }
        [Authorize]
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            try
            {
                User currentUser = await GetCurrentUserAsync();
                // Map User to UserDto
                UserDto userDto = _mapper.Map<UserDto>(currentUser);
                return Ok(userDto);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /*
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(user);
            await _usersService.CreateAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        */

        [HttpGet("{id}/reviews")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDto>))]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetUserReviews(long id)
        {
            var reviews = await _usersService.GetReviewsByUserAsync(id);
            return Ok(reviews);
        }

        public async Task<User> GetCurrentUserAsync()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                throw new Exception("logged in user could not be found");
            }
            else
            {
                return user; 
            }
        }
    }
}