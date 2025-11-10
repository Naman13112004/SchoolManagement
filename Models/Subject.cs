using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
