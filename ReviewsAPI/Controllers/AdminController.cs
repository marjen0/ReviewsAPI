using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsAPI.Repositories.Interfaces;

namespace ReviewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IReviewsRepository _reviewsRepository;

        public AdminController(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository ?? throw new ArgumentNullException(nameof(reviewsRepository));
        }
        
    }
}