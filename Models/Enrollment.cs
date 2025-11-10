namespace SchoolManagement.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        // Added 'required'
        public required Student Student { get; set; }

        public int SubjectId { get; set; }
        // Added 'required'
        public required Subject Subject { get; set; }
    }
}
