using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SimpleAPI.Constants.AccountConstants;

namespace SimpleAPI.Dtos.Account
{
    public class NewUserDto
    {
        [Required]
        [MinLength(MinLengthUsername, ErrorMessage = MinUsernameErrorMessage)]
        [MaxLength(MaxLengthUsername, ErrorMessage = MaxUsernameErrorMessage)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}