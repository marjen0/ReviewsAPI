using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ReviewsAPI.DTO
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "E. pašto adresas per ilgas. Maksimalus ilgis 100 simbolių")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Slaptažodis per ilgas. Maksimalus ilgis 100 simbolių")]
        public string Password1 { get; set; }
        [Required]
        [Compare("Password1", ErrorMessage = "Passwords do not match")]
        [MaxLength(100, ErrorMessage = "Slaptažodis per ilgas. Maksimalus ilgis 100 simbolių")]
        public string Password2 { get; set; }


    }
}
