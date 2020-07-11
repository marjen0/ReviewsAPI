using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.DTO.Review
{
    public class ReviewCreateDto
    {
        public string Model { get; set; }
        [Required(ErrorMessage = "Nepateiktas tekstas")]
        [MaxLength(2000, ErrorMessage = "Tekstas per ilgas. Tekstą gali sudaryti daugiausiai 2000 simbolių")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Nepateiktas pliusų sąrašas")]
        [MaxLength(100, ErrorMessage = "Pliusų sąrašas per ilgas. Sąrašą gali sudaryti daugiausiai 100 simbolių")]
        public string Pros { get; set; }
        [Required(ErrorMessage = "Nepateiktas minusų sąrašas")]
        [MaxLength(100, ErrorMessage = "Minusų sąrašas per ilgas. Sąrašą gali sudaryti daugiausiai 100 simbolių")]
        public string Cons { get; set; }
        [Required(ErrorMessage = "Nepateiktas rekomendavimas")]
        public bool IsRecommended { get; set; }
    }
}
