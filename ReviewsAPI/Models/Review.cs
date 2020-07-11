using ReviewsAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Models
{
    
    public class Review : IEntity
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Nepateiktas modelis")]
        [MaxLength(50, ErrorMessage = "Pavadinimas per Ilgas. Pavadinimą gali sudaryti daugausiai 50 simbolių")]
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
        public DateTime? CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        [Required]
        public ReviewStatus Status { get; set; }
        [Required(ErrorMessage = "Naudotojo Id negali būti tuščias")]
        public long RegularUserId { get; set; }
        public long? AdminId { get; set; }

        public virtual RegularUser RegularUser { get; set; }
        public virtual Admin Admin { get; set; }


    }
}
