using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReviewsAPI.Models;

namespace ReviewsAPI.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
