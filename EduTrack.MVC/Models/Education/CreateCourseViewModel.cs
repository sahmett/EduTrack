using EduTrack.MVC.Models.Content;

namespace EduTrack.MVC.Models.Education
{
    public class CreateCourseViewModel
    {
        public List<CourseContentViewModel> CourseContents { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
