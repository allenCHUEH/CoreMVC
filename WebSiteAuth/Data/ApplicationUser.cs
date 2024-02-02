using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebSiteAuth.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(3)]
        public string? Country { get; set; }
    }
}
