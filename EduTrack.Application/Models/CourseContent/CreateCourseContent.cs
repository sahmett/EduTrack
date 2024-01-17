using EduTrack.Domain.Enum;

namespace EduTrack.Application.Models.CourseContent
{
    public class CreateCourseContent
    {
        //properties for course content object
        public Guid CourseId { get; set; }
        public string Name { get; set; }

        public string Link { get; set; }
        public CourseContentType Type { get; set; }

    }
}