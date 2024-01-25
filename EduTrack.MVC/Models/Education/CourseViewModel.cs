using EduTrack.MVC.Models.Content;

namespace EduTrack.MVC.Models.Education
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InternalTrainer { get; set; }
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
        public TimeSpan Duration { get; set; }
       

        //public List<CourseContentViewModel> CourseContents { get; set; }
        //public List<CategoryViewModel> Categories { get; set; }
        public Guid CourseContentId { get; set; }
        public string CategoryId { get; set; }
    }
}
