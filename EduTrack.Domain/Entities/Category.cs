using EduTrack.Domain.Common;

namespace EduTrack.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public ICollection<Course> Courses { get; set; }
    }
}