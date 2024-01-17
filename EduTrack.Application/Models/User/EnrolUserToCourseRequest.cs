using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application.Models.User
{
    public class EnrolUserToCourseRequest
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
