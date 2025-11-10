using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        public required string EmployeeNumber { get; set; }

        // Initialized collection
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
