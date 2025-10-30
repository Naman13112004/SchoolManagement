using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional common fields (optional)
        public string FullName { get; set; }
    }
}