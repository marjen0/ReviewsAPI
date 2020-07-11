using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.DTO.Review
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public string Text { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public bool IsRecommended { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
