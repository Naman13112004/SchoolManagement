using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string EmployeeNumber { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}