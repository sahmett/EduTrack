namespace EduTrack.MVC.Models.Course
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InternalTrainer { get; set; }
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
        public TimeSpan Duration { get; set; }
        public string CategoryId { get; set; }
    }
}
