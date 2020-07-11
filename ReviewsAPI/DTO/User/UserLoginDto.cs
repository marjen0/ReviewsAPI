using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.DTO
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "El. pašto adresas per ilgas. Maksimalus simbolių skaičius yra 100")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Slaptažodis per ilgas. Maksimalus simbolių skaičius yra 100")]
        public string Password { get; set; }
    }
}
