using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Models
{
    public class Admin : User
    {
        public ICollection<Review> ConfirmedReviews { get; set; }
    }
}
