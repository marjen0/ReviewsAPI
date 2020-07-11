using Microsoft.AspNetCore.Identity;
using ReviewsAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Models
{
    public class User : IdentityUser<long>, IEntity
    {
        public long Id { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100,ErrorMessage = "E. pašto adresas per ilgas. Maksimalus ilgis 100 simbolių")]
        public override string Email { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Slaptažodis per ilgas. Maksimalus ilgis 100 simbolių")]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; }
        
    }
}
