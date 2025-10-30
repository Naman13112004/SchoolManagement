using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string RollNumber { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}