using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Added 'required' modifier for non-nullable property
        public required string FullName { get; set; }
    }
}
