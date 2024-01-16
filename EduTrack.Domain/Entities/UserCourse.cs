using EduTrack.Domain.Common;
using EduTrack.Domain.Identity;

namespace EduTrack.Domain.Entities
{
    public class UserCourse : ICreatedByEntity
    {
       
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public DateTimeOffset EnrollmentDate { get; set; }
        public bool isFinished { get; set; }
        public string CreatedByUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset CreatedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}