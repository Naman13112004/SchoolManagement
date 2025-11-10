using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public required string RollNumber { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom? ClassRoom { get; set; }

        // Initialized collections
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
