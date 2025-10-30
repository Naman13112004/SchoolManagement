using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}