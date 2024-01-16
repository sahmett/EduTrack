using EduTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Domain.Entities
{
    public class Course : EntityBase<Guid>
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InternalTrainer { get; set; } // if true, then the course is taught by an internal trainer, if false, then the course is taught by an external trainer
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
        public TimeSpan Duration { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<CourseContent> CourseContents { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
    }
}