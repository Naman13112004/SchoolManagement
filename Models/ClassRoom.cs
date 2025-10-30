using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // e.g., "Grade 10 - A"

        public string Section { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}