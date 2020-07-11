using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.DTO;
using ReviewsAPI.Models;
using ReviewsAPI.Services.Interfaces;

namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(registerDto);
            try
            {
                UserDto createdUser = await _authService.CreateUser(registerDto);
                return Ok(createdUser);
            }
            catch (Exception e)
            {
                return BadRequest(new {message =  e.Message});
            }
            
        }

        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> SignIn(UserLoginDto userDto)
        {
            try
            {
                string token  = await _authService.AuthenticateUser(userDto);
                return Ok(new { token});
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}