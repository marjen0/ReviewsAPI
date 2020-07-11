using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Models
{
    public class RegularUser : User
    {
        // EF navigation properties
        public ICollection<Review> PostedReviews { get; set; }
    }
}
