using System.ComponentModel.DataAnnotations;
using static SimpleAPI.Constants.AccountConstants;

namespace SimpleAPI.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [MinLength(MinLengthUsername, ErrorMessage = MinUsernameErrorMessage)]
        [MaxLength(MaxLengthUsername, ErrorMessage = MaxUsernameErrorMessage)]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set;}
        [Required]
        public string? Password { get; set; }
    }
}