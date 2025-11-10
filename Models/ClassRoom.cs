using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; } // e.g., "Grade 10 - A"

        // Made Section nullable (string?) as it might not be strictly required, or use 'required'
        // Given your original model had no [Required], I'll make it nullable if not required.
        public string? Section { get; set; }

        // Initialized collection to an empty list to prevent warning
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
