using EduTrack.Domain.Enum;

namespace EduTrack.MVC.Models.Content
{
    public class CreateCourseContentViewModel
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public CourseContentType Type { get; set; }
    }
}
