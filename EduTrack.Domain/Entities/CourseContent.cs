using EduTrack.Domain.Common;
using EduTrack.Domain.Enum;

namespace EduTrack.Domain.Entities
{
    public class CourseContent : EntityBase<Guid>
    {
        public Guid CourseContentId { get; set; }
        public Guid CourseId { get; set; }
        public CourseContentType Type { get; set; } // Kitap, Video, Sunum, Makale, Mini Proje

        // Navigation Property
        public Course Course { get; set; }
    }
}