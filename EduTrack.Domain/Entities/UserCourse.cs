using EduTrack.Domain.Identity;

namespace EduTrack.Domain.Entities
{
    public class UserCourse
    {
       
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
    }
}