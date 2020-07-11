using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Data;
using ReviewsAPI.DTO;
using ReviewsAPI.DTO.Review;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories;
using ReviewsAPI.Repositories.Interfaces;
using ReviewsAPI.Services.Interfaces;

namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;
        private readonly IUsersService _usersService;
        private readonly UserManager<User> _userManager;

        public ReviewsController(IReviewsService reviewService, IUsersService userService, UserManager<User> userManager)
        {
            _reviewsService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _usersService = userService ?? throw new ArgumentNullException(nameof(userService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews([FromQuery] string status)
        {

            if (status != null)
            {
                var reviewsByStatus = await _reviewsService.GetReviewsByStatus(status);
                if (reviewsByStatus == null || reviewsByStatus.Count() < 1)
                {
                    return NotFound(new { message = "no review could be found" });
                }
                else
                {
                    return Ok(reviewsByStatus); 
                }
            }

            var reviews = await _reviewsService.GetAllReviews();
            if (reviews == null || reviews.Count() < 1)
            {
                return NotFound(new { message = "No reviews could be found" });
            }
            else
            {
                return Ok(reviews); 
            }
        }
       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<ReviewDto>> GetReview([FromRoute] long id)
        {  
            ReviewDto reviewDto = await _reviewsService.GetByIdAsync(id);

            if (reviewDto == null)
            {
                return NotFound(new { message = $"Review with id {id} could not be found" });
            }
            else
            {
                return Ok(reviewDto); 
            }
        }

        //[Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReviewDto))]
        public async Task<ActionResult<Review>> CreateReview([FromBody] ReviewCreateDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(reviewDto);
            }
                
            User currentUser = await GetCurrentUserAsync();
   
            long createdReviewId = await _reviewsService.CreateAsync(reviewDto);
            return CreatedAtAction(nameof(GetReview), new {Id = createdReviewId});
        }

        //[Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete([FromRoute] long id)
        { 
            // should catch exceptions
            await _reviewsService.DeleteAsync(id);
            return Ok();
        }

        //[Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewUpdateDto))]
        public async Task<ActionResult<ReviewUpdateDto>> Edit([FromRoute] long id, [FromBody] ReviewUpdateDto reviewDto)
        {
            // Should check if user is review author

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                 
            await _reviewsService.UpdateAsync(id,reviewDto);

            return Ok(reviewDto);
        }

        //[Authorize]
        [HttpPut("{id}/confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConfirmReview([FromRoute] long id)
        {
            await _reviewsService.ConfirmReviewAsync(id);
            return Ok();
        }

        private async Task<User> GetCurrentUserAsync()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                throw new Exception("logged in user could not be found");
            return user;
        }
    }
}