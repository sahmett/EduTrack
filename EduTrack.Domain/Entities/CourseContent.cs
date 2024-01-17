using EduTrack.Domain.Common;
using EduTrack.Domain.Enum;

namespace EduTrack.Domain.Entities
{
    public class CourseContent : EntityBase<Guid>
    {
        public Guid Id { get; set; }
        public CourseContentType Type { get; set; } // Kitap, Video, Sunum, Makale, Mini Proje
        public string Name { get; set; }
        public string Link { get; set; }

        // Navigation Property
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
    }
}