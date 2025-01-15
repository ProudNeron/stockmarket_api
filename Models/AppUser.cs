using Microsoft.AspNetCore.Identity;

namespace SimpleAPI.Models
{
    public class AppUser : IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = [];
    }
}