using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "")]
        [MaxLength(100, ErrorMessage = "")]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set;}
        [Required]
        [MinLength(10, ErrorMessage = "")]
        public string? Password { get; set; }
    }
}